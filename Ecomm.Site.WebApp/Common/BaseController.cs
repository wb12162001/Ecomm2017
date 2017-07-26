using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System;

using Quick.Framework.Common.ToolsHelper;
using Quick.Site.Common.Models;
using Ecomm.Domain.Models.EpSnell;
using System.Web.UI;
using Ecomm.Site.WebApp.Extension.Filters;
using Ecomm.Core.Service.MyOffice;
using System.ComponentModel.Composition.Hosting;
using Ecomm.Site.Models.MyOffice.SALES_EBASKET;
using Ecomm.Site.Models.Product.PROD_CATEGORIES;
using Ecomm.Core.Service.Product;
using Ecomm.Core.Service.SysConfig;
using System.Linq.Expressions;
using Ecomm.Domain.Models.Product;
using Ecomm.Site.Models.MyOffice.SALES_ESIORDERFORM;

namespace Ecomm.Site.WebApp.Common
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [MyofficePermission(PermissionCustomMode.Enforce)]
    public class BaseController : Controller
    {
        [Import]
        protected ISALES_EBASKETService SALES_EBASKETService { get; set; }

        [Import]
        protected IPROD_CATEGORIESService PROD_CATEGORIESService { get; set; }

        [Import]
        protected ISYS_CONFIGService SYS_CONFIGService { get; set; }

        [Import]
        public ISALES_FAVFOLDERService SALES_FAVFOLDERService { get; set; }

        [Import]
        public Ecomm.Core.Service.Product.IPROD_MASTERService PROD_MASTERService { get; set; }

        [Import]
        public Ecomm.Core.Service.MyOffice.ISALES_CONTRACTPRICEService SALES_CONTRACTPRICEService { get; set; }

        public BaseController()
        {
            var container = System.Web.HttpContext.Current.Application["Container"] as CompositionContainer;
            if (SALES_EBASKETService == null)
            {
                SALES_EBASKETService = container.GetExportedValueOrDefault<ISALES_EBASKETService>();
            }
            if (PROD_CATEGORIESService == null)
            {
                PROD_CATEGORIESService = container.GetExportedValueOrDefault<IPROD_CATEGORIESService>();
            }
            if (SYS_CONFIGService == null)
            {
                SYS_CONFIGService = container.GetExportedValueOrDefault<ISYS_CONFIGService>();
            }
            if (SALES_FAVFOLDERService == null)
            {
                SALES_FAVFOLDERService = container.GetExportedValueOrDefault<ISALES_FAVFOLDERService>();
            }
            if (PROD_MASTERService == null)
            {
                PROD_MASTERService = container.GetExportedValueOrDefault<IPROD_MASTERService>();
            }
            if (SALES_CONTRACTPRICEService == null)
            {
                SALES_CONTRACTPRICEService = container.GetExportedValueOrDefault<ISALES_CONTRACTPRICEService>();
            }

            ViewBag.UserName = string.Empty;
            if (this.CurrentUser != null)
            {
                ViewBag.UserName = this.CurrentUser.UserName;
            }
            //ShoppingCart
            ViewBag.ShoppingCartModel = InitSalesEbasket();
            //Navigation 菜单
            ViewBag.MenuPackagingModel = InitNavMenu("P");
            ViewBag.MenuSafetyModel = InitNavMenu("S");
            //My Fav Folder
            ViewBag.MyFavFolders = InitMyFav();
        }

        protected ShoppingCartViewModel InitSalesEbasket()
        {
            ShoppingCartViewModel cartModel = new ShoppingCartViewModel();
            //var user = SessionHelper.GetSession("CurrentSnellUser") as Rela_contact;
            if (CurrentUser != null)
            {
                string strWhere = string.Format("a.Status = 0 and a.ContactID = '{0}' and a.MakeOrderID = ''", CurrentUser.Id);
                var list = SALES_EBASKETService.QueryEntities(0, strWhere, "")
                    //.Where(t => t.Status == 0 && t.ContactID == CurrentUser.Id && string.IsNullOrEmpty(t.MakeOrderID))
                    .Select(t => new SALES_EBASKET_RelaModel
                    {
                        StockType = t.StockType,
                        StndCost = t.StndCost,
                        UnitPrice = t.UnitPrice,
                        Quantity = t.Quantity,
                        Status = t.Status,
                        ProductNo = t.ProductNo,
                        Unit = t.Unit,
                        UnitPType = t.UnitPType,
                        ID = t.ID,
                        ProductID = t.ProductID,
                        ProductName = t.ProductName,
                        ProductPic = t.ProductPic
                    });
                    
                StringBuilder sb = new StringBuilder();
                StringBuilder sb_item = new StringBuilder();
                int item_count = list.Count();
                double item_subtotal = list.Sum(t => (t.Quantity * (double)t.UnitPrice));

                cartModel.ItemCount = item_count;
                cartModel.CartTotal = item_subtotal.ToString("N2");
                cartModel.Sales_Ebaskets = list;
                cartModel.Freight = SALES_EBASKETService.GetUserFreight(item_subtotal);
                cartModel.Miscellaneous = this.CurrentUser.Miscellaneous;
                cartModel.GST = SYS_CONFIGService.GetCalculatedGst(cartModel.Freight, cartModel.Miscellaneous, item_subtotal);
                cartModel.Total = item_subtotal + cartModel.Freight + cartModel.Miscellaneous + cartModel.GST;

                //Ben 2014-08-20 For the MinOrderValue
                if (CurrentUser.MinOrderValue > 0 && CurrentUser.MinOrderValue > item_subtotal)
                {
                    cartModel.Message = string.Format("We are unable to process as below ${0}/order threshold, please increase your order or contact the customers service team on 0800736557 to discuss options.", CurrentUser.MinOrderValue.ToString("N2"));
                }
                if (CurrentUser.MinOrderSize > 0 && CurrentUser.MinOrderSize > item_subtotal)
                {
                    cartModel.Misctitle = string.Format("Save ${1}! Simply by increasing your orders to ${0}, your small orders fee will be waived!", CurrentUser.MinOrderSize.ToString("N0"), CurrentUser.MinOrderMisc.ToString("N0"));
                }
            }
            return cartModel;
        }

        private Expression<Func<PROD_CATEGORIES, Boolean>> BuildStairCategories(string cateCode)
        {
            DynamicLambda<PROD_CATEGORIES> bulider = new DynamicLambda<PROD_CATEGORIES>();
            Expression<Func<PROD_CATEGORIES, Boolean>> expr = t => t.Status == 0 && t.IsAvailably;

            if (!string.IsNullOrEmpty(cateCode))
            {
                var list = PROD_CATEGORIESService.PROD_CATEGORIESList
                .Where(t => t.CategoryCode.Equals(cateCode))
                .Select(t => t.ID);
                Expression<Func<PROD_CATEGORIES, Boolean>> tmpSolid = t => list.Contains(t.ParentID);
                expr = bulider.BuildQueryAnd(expr, tmpSolid);
            }
            //if (!string.IsNullOrEmpty(parentID))
            //{
            //    Expression<Func<PROD_CATEGORIES, Boolean>> tmpP = t => t.ParentID.Contains(parentID);
            //    expr = bulider.BuildQueryAnd(expr, tmpP);
            //}
            return expr;
        }

        protected MenuViewModel InitNavMenu(string catecode)
        {
            MenuViewModel model = new MenuViewModel();
            var own = PROD_CATEGORIESService.PROD_CATEGORIESList.FirstOrDefault(t => t.CategoryCode.Equals(catecode));
            model.CurrCateName = Ecomm.Site.WebApp.Common.CommonHelper.GetCateName(own.MenuAlias, own.CategoryName);
            if (own.CLevel == 3)
            {
                own = own.ParentCategory;
                catecode = own.CategoryCode;
            }
            var list = PROD_CATEGORIESService.PROD_CATEGORIESList
                .Where(BuildStairCategories(catecode))
                .Select(t => new PROD_CATEGORIESModel
                {
                    ID = t.ID,
                    CategoryName = t.CategoryName,
                    CategoryCode = t.CategoryCode,
                    MenuAlias = t.MenuAlias,
                    CLevel = t.CLevel,
                    DisplayOrder = t.DisplayOrder
                }).OrderBy(t => t.DisplayOrder);
            
            if (own != null)
            {
                model.Category = new PROD_CATEGORIESModel
                {
                    ID = own.ID,
                    CategoryCode = own.CategoryCode,
                    CategoryName = own.CategoryName,
                    MenuAlias = own.MenuAlias,
                    CLevel = own.CLevel,
                    DisplayOrder = own.DisplayOrder,
                    ParentID = own.ParentID
                };
            }
            model.Menus = list;
            model.ItemCount = list.Count();
            
            return model;
        }
        protected Rela_contact CurrentUser
        {
            get { return SALES_EBASKETService.GetUser(); }
            set {
                //Session["CurrentSnellUser"] = value;
                SALES_EBASKETService.SetUser(value);
            }
        }

        protected ShoppingOrderViewModel ShoppingOrder
        {
            get { return (ShoppingOrderViewModel)Session["ShoppingOrderViewModel"]; }
            set { Session["ShoppingOrderViewModel"] = value; }
        }


        protected Models.MyOffice.SALES_FAVFOLDER.SALES_FAVFOLDER_ViewModel InitMyFav()
        {
            if (CurrentUser != null)
            {
                Models.MyOffice.SALES_FAVFOLDER.SALES_FAVFOLDER_ViewModel model = new Models.MyOffice.SALES_FAVFOLDER.SALES_FAVFOLDER_ViewModel();
                model.ActionTitle = "Add to favourite";
                var myfavs = SALES_FAVFOLDERService.GetFavFoldersAndItemCount(CurrentUser.AccountInfo.Account_no, CurrentUser.Id);
                model.MyFavList = myfavs.Select(t => new EOF_Favourite
                {
                    Count = t.itemCount,
                    Favourite = t.FolderName,
                    FavouriteID = t.ID
                }).ToList();

                return model;
            }
            return null;
        }

        protected int _AddCart(string pno, int qty)
        {
            int ret = 0;
            if (!string.IsNullOrEmpty(pno) && CurrentUser != null)
            {
                Domain.Models.Product.PROD_MASTER prod = PROD_MASTERService.GetProduct(pno);
                if (prod != null)
                {
                    if (CurrentUser.AccountInfo != null)
                    {
                        string unitPriceType = string.Empty;
                        double uPrice = 0;
                        PROD_MASTERService.GetSellingPrice(prod.ProductNo, CurrentUser.AccountInfo.Account_no, out uPrice, out unitPriceType);
                        if (uPrice == 0)
                        {
                            uPrice = (double)prod.ListPrice;
                        }
                        var model = new SALES_EBASKETModel
                        {
                            ID = Quick.Framework.Tool.CombHelper.NewComb().ToString(),
                            ContactID = CurrentUser.Id,
                            CreateDate = DateTime.Now,
                            Creator = CurrentUser.AccountInfo.Account_no,
                            CustomerID = CurrentUser.AccountInfo.Account_no,//request
                            ModiDate = DateTime.Now,
                            Modifier = CurrentUser.AccountInfo.Account_no,
                            ProductNo = prod.ProductNo,
                            Quantity = Convert.ToDouble(qty),
                            Unit = prod.BaseUOFM,
                            UnitPrice = uPrice,
                            UnitPType = unitPriceType,
                            Status = 0,
                            MakeOrderID = "",
                        };
                        if ((bool)CurrentUser.IsContractLimit && unitPriceType != "L")//only to purchase contract goods
                        {
                            if (unitPriceType == "S")//Special Price
                            {
                                bool hasContractPrice = SALES_CONTRACTPRICEService.IsExist(CurrentUser.AccountInfo.Account_no, prod.ProductNo);
                                if (!hasContractPrice)
                                {
                                    return -10;
                                    //return Json(new { success = false, message = "You need to purchase contract goods." });
                                }
                            }
                        }
                        ret = SALES_EBASKETService.ModificationCart(model); //成功了
                        //ret = SALES_EBASKETService.ModificationByProce(model);//有问题不可以使用
                    }
                }
            }
            return ret;

        }


    }
}