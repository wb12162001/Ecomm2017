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
using System.Linq.Expressions;
using Ecomm.Domain.Models.Product;

namespace Ecomm.Site.WebApp.Common
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BaseController : Controller
    {
        [Import]
        protected ISALES_EBASKETService SALES_EBASKETService { get; set; }

        [Import]
        protected IPROD_CATEGORIESService PROD_CATEGORIESService { get; set; }
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
        }

        protected ShoppingCartViewModel InitSalesEbasket()
        {
            ShoppingCartViewModel cartModel = new ShoppingCartViewModel();
            //var user = SessionHelper.GetSession("CurrentSnellUser") as Rela_contact;
            if (CurrentUser != null)
            {
                var list = SALES_EBASKETService.SALES_EBASKETList.ToList()
                    .Where(t => t.Status == 0 && t.ContactID == CurrentUser.Id && string.IsNullOrEmpty(t.MakeOrderID))
                    .Select(t => new SALES_EBASKETModel
                    {
                        UnitPrice = t.UnitPrice,
                        Quantity = t.Quantity,
                        Status = t.Status,
                        ProductNo = t.ProductNo,
                        Unit = t.Unit,
                        UnitPType = t.UnitPType,
                        ID = t.ID,
                    });
                    
                StringBuilder sb = new StringBuilder();
                StringBuilder sb_item = new StringBuilder();
                int item_count = list.Count();
                double item_subtotal = list.Sum(t => (t.Quantity * (double)t.UnitPrice));

                cartModel.ItemCount = item_count;
                cartModel.CartTotal = item_subtotal.ToString("N2");
                cartModel.Sales_Ebaskets = list;
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
            var list = PROD_CATEGORIESService.PROD_CATEGORIESList
                .Where(BuildStairCategories(catecode))
                .Select(t => new PROD_CATEGORIESModel
                {
                    ID = t.ID,
                    CategoryName = t.CategoryName,
                    CategoryCode = t.CategoryCode,
                    MenuAlias = t.MenuAlias,
                    DisplayOrder = t.DisplayOrder
                }).OrderBy(t => t.DisplayOrder);
            var own = PROD_CATEGORIESService.PROD_CATEGORIESList.FirstOrDefault(t => t.CategoryCode.Equals(catecode));
            if (own != null)
            {
                model.Category = new PROD_CATEGORIESModel
                {
                    ID = own.ID,
                    CategoryCode = own.CategoryCode,
                    CategoryName = own.CategoryName,
                    MenuAlias = own.MenuAlias,
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
            set { Session["CurrentSnellUser"] = value; }
        }
       

    }
}