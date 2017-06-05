using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quick.Framework.Tool;
using Quick.Framework.Common.ToolsHelper;
using Ecomm.Site.Models.Authen.Admin_user;
using Ecomm.Core.Service.Authen;
using Ecomm.Site.Models;

using System.Web.UI;
using System.IO;
using System.Text;
using Ecomm.Site.Models.MyOffice.SALES_EBASKET;
using Quick.Site.Common.Models;
using Ecomm.Site.WebApp.Extension.Filters;

namespace Ecomm.Site.WebApp.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [MyofficePermission(PermissionCustomMode.Ignore)]
    public class HomeController : Ecomm.Site.WebApp.Common.BaseController
    {
        [Import]
        public Ecomm.Core.Service.EpSnell.IRela_contactService Rela_contactService { get; set; }

        [Import]
        public Ecomm.Core.Service.SysConfig.IINFOR_MASTERService INFOR_MASTERService { get; set; }

        [Import]
        public Ecomm.Core.Service.Product.IPROD_GROUP_ITEMService PROD_GROUP_ITEMService { get; set; }

        [Import]
        public Ecomm.Core.Service.Product.IPROD_GROUP_INDEXService PROD_GROUP_INDEXService { get; set; }

        [Import]
        public Ecomm.Core.Service.Product.IPROD_MASTERService PROD_MASTERService { get; set; }

        [Import]
        public Ecomm.Core.Service.MyOffice.ISALES_CONTRACTPRICEService SALES_CONTRACTPRICEService { get; set; }

        [Import]
        public Ecomm.Core.Service.InetApp.IEOrderService EOrderService { get; set; }

        [Import]
        protected Ecomm.Core.Service.GPSPS.IDBService DBService { get; set; }

        public ActionResult Index()
        {
            //IndexPageModel model = new IndexPageModel();
            InitSlides();
            InitAd();

            InitToday();
            InitPopProducts();
            InitBestSellers();

            //Recommoned
            InitRecommoned("RecommendedProducts01");
            InitRecommoned("RecommendedProducts02");

            InitLinks();
            InitThepress();
            return View();
        }
        private void InitSlides()
        {
            var list = INFOR_MASTERService.INFOR_MASTERList
                .Where(t => t.InforCategory.InforCategoryName.Contains("2017HomeBanner") && t.Status == 0)
                .Select(t => new Models.SysConfig.INFOR_MASTER.INFOR_MASTERModel
                {
                    Item01 = t.Item01
                }
                ).ToList();
            int sortId = 0;
            StringBuilder sb = new StringBuilder();
            StringBuilder sb_ol = new StringBuilder();
            StringBuilder sb_item = new StringBuilder();
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item.Item01))
                {
                    string act = "";
                    if (sortId == 0)
                    {
                        act = "active";
                    }
                    sb_ol.AppendFormat("<li data-target='#carousel-example-generic' data-slide-to='{0}' class='{1}'></li>", sortId, act).AppendLine();
                    sb_item.AppendFormat(@"
                    <div class='item {0}'>
                <img src = '{1}' alt='...'>
                <div class='carousel-caption'>

                </div>
            </div>", act, item.Item01).AppendLine();
                    sortId++;
                }

            }

            if (!string.IsNullOrEmpty(sb_ol.ToString()))
            {
                sb.AppendFormat(@"
<div class='banner'>
    <div id='carousel-example-generic' class='carousel slide' data-ride='carousel'>
        <!-- Indicators -->
        <ol class='carousel-indicators'>
            {0}
        </ol>

        <!-- Wrapper for slides -->
        <div class='carousel-inner' role='listbox'>
           {1}
        </div>

        <!-- Controls -->
        <a class='left carousel-control' href='#carousel-example-generic' role='button' data-slide='prev'>
            <span class='glyphicon glyphicon-chevron-left'></span>
            <span class='sr-only'>Previous</span>
        </a>
        <a class='right carousel-control' href='#carousel-example-generic' role='button' data-slide='next'>
            <span class='glyphicon glyphicon-chevron-right'></span>
            <span class='sr-only'>Next</span>
        </a>
    </div>
</div>
", sb_ol.ToString(),sb_item.ToString()).AppendLine();
                ViewBag.Slides = sb.ToString();
            }
        }

        private void InitAd()
        {
            var list = INFOR_MASTERService.INFOR_MASTERList
                .Where(t => t.InforCategory.InforCategoryName.Contains("2017HomePicList") && t.Status == 0)
                .Select(t => new Models.SysConfig.INFOR_MASTER.INFOR_MASTERModel
                {
                    Item01 = t.Item01
                }
                ).ToList();
            StringBuilder sb = new StringBuilder();
            StringBuilder sb_item = new StringBuilder();
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item.Item01))
                {
                    sb_item.AppendFormat(@"
<div class='col-md-3 col-xs-3 col-lg-3'>
        <a href=''>
            <img src='{0}'>
        </a>
    </div>
", item.Item01).AppendLine();
                }
            }
            if (!string.IsNullOrEmpty(sb_item.ToString()))
            {
                sb.AppendFormat(@"
 <div class='middle-adv'>
            <div class='row'>
                    {0}
            </div>
 </div>
<div class='clearfix'></div>
", sb_item.ToString()).AppendLine();
                ViewBag.mid_Ad = sb.ToString();
            }
        }

        private void InitToday()
        {
            var obj = PROD_GROUP_ITEMService.PROD_GROUP_ITEMList.FirstOrDefault(t => t.Group.Name.Contains("TODAY DEALS") && t.Status == 1);
            StringBuilder sb = new StringBuilder();
            if(obj != null && obj.Product != null){
                sb.AppendFormat(@"
            <h4><span class='badge'>-9%</span></h4>
            <a href='{4}'><img class='product-img' src='{0}'></a>
            <p class='star-line'>
                <img src='/Content/snell/images/star-4.png'>
            </p>
            <a href='{4}'><p class='product-title'>{1}</p></a>
            <p class='old-price'>${2}</p>
            <p class='new-price'>${3}</p>
            <div class='countdown'>
                <div class='days '>
                    <div class='num days-num'>00</div>
                    <div class='date-text'>days</div>
                </div>
                <div class='hrs '>
                    <div class='num days-num'>00</div>
                    <div class='date-text'>hrs</div>
                </div>
                <div class='mins '>
                    <div class='num days-num'>00</div>
                    <div class='date-text'>mins</div>
                </div>
                <div class='secs '>
                    <div class='num days-num'>00</div>
                    <div class='date-text'>secs</div>
                </div>
            </div>
", obj.Picture, obj.Product.ProductName, obj.Product.ListPrice.Value.ToString("N2"), obj.Product.StndCost.Value.ToString("N2"), Url.Action("Detail", "Prod", new { id = obj.Product.ID })).AppendLine();
                ViewBag.Today = sb.ToString();
            }
        }

        private void InitPopProducts()
        {
            var list = PROD_GROUP_ITEMService.PROD_GROUP_ITEMList
                .Where(t => t.Group.Name.Contains("POPULAR PRODUCTS") && t.Status == 1)
                .Select(t => new
                {
                    Picture = t.Picture,
                    Product = t.Product,
                }
                ).ToList();
            StringBuilder sb_item = new StringBuilder();
            foreach (var item in list)
            {
                if (item.Product != null)
                {
                    sb_item.AppendFormat(@"
<div class='item pull-left product-box'>
                <a href='{4}'><img class='pro-img lazyOwl' data-src='{0}' /></a>
                <p class='star-line'>
                    <img src='/Content/snell/images/star-4.png'>
                </p>
                <a href='{4}'><p class='product-name'>{1}</p></a>
                <div class='price-cart'>
                    <div class='price pull-left'>
                        <p class='old-price'>${2}</p>
                        <p class='new-price'>${3}</p>
                    </div>
                    <div class='pull-right'>
                        <a href='javascript:void(0);' class='cart' data-pno='{5}' >
                            <img src='/Content/snell/images/cart_03.png'>
                        </a>
                    </div>
                </div>
                <div class='wishlist-compare'>
                    <div class='wishlist pull-left'><a href='javascript:void(0);' class='add_fav' data-pno='{5}'><i class='fa fa-heart-o'></i> <span>wishlist</span></a></div>
                </div>
                <div class='clearfix'></div>

            </div>
", item.Picture, item.Product.ProductName, item.Product.ListPrice.Value.ToString("N2"), item.Product.ListPrice.Value.ToString("N2"), Url.Action("Detail", "Prod", new { id = item.Product.ID }), item.Product.ProductNo.Trim()).AppendLine();
                }
            }
            if (!string.IsNullOrEmpty(sb_item.ToString()))
            {
                ViewBag.PopularProducts = sb_item.ToString();
            }
        }

        private string setTabID(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return name.Trim().ToLower().Replace(" ", "");
            }
            return name;
        }
        private void InitBestSellers()  //BEST SELLERS
        {
            var list = PROD_GROUP_ITEMService.PROD_GROUP_ITEMList
                .Where(t => t.Group.Name.Contains("BEST SELLERS") && t.Status == 1)
                .Select(t => new
                {
                    Picture = t.Picture,
                    Product = t.Product,
                }
                ).ToList();
            StringBuilder sb_item = new StringBuilder();
            foreach (var item in list)
            {
                if (item.Product != null)
                {
                    sb_item.AppendFormat(@"
<div class='item pull-left sellers-box'>
                <div class='pull-left sellers-img'>
                    <a href='{4}'><img src='{0}'></a>
                </div>
                <div class='pull-left sellers-desc'>
                    <a href='{4}'><p class='sellers-name'>{1}</p></a>
                    <div class='price'>
                        <p class='old-price'>${2}</p>
                        <p class='new-price'>${3}</p>
                    </div>
                </div>
            </div>
", item.Picture, item.Product.ProductName, item.Product.ListPrice.Value.ToString("N2"), item.Product.StndCost.Value.ToString("N2"), Url.Action("Detail", "Prod", new { id = item.Product.ID })).AppendLine();
                }
            }
            if (!string.IsNullOrEmpty(sb_item.ToString()))
            {
                ViewBag.BestSellers = sb_item.ToString();
            }
        }

        private void InitRecommoned(string recommoned)
        {
            var obj = PROD_GROUP_INDEXService.PROD_GROUP_INDEXList
                .FirstOrDefault(t => t.Name.Contains(recommoned) && t.Status == 1);
            int sortId = 0;
            StringBuilder sb = new StringBuilder();
            StringBuilder sb_ol = new StringBuilder();
            StringBuilder sb_item = new StringBuilder();
            if (obj != null)
            {
                var list = PROD_GROUP_INDEXService.PROD_GROUP_INDEXList
                    .Where(t => t.ParentID == obj.ID)
                    .Select(t=>new {
                        ID = t.ID,
                        Picture = t.Picture,
                        Name = t.Name,
                        ColorText = t.ColorText
                    });
                foreach (var item in list)
                {
                    if (!string.IsNullOrEmpty(item.Name))
                    {
                        string context = GetRecommonedTabItem(item.ID);
                        string act = "";
                        if (sortId == 0)
                        {
                            act = "active";
                        }
                        sb_ol.AppendFormat("<li class='{1}'><a href='#{2}' data-toggle='tab'>{0}</a></li>",item.Name, act, setTabID(item.Name)).AppendLine();
                        sb_item.AppendFormat(@"
<div class='personal-protection-list tab-pane fade in {0}' id='{1}'>
                <div class='model-show pull-left'>
                    <img src='{2}' />
                </div>
                {3}
</div>
", act, setTabID(item.Name), item.Picture, context).AppendLine();
                        sortId++;
                    }

                }

                sb.AppendFormat(@"
<div class='personal-protection'>
        <div class='personal-protection-title'>
            <h3>{0}</h3>
            <div class='tab-right'>
                <ul class='nav nav-tabs'>
		{1}
                </ul>  
            </div>
        </div>
	
	<div class='tab-content'>
		{2}
	</div
</div>
", obj.ColorText, sb_ol.ToString(), sb_item.ToString()).AppendLine();
                ViewData[recommoned] = sb.ToString();
            }
            
        }

        private void InitLinks()
        {
            var list = INFOR_MASTERService.INFOR_MASTERList
                .Where(t => t.InforCategory.InforCategoryName.Contains("2017HomeLinks") && t.Status == 0)
                .ToList();
            int sortId = 0;
            StringBuilder sb = new StringBuilder();
            StringBuilder sb_ol = new StringBuilder();
            sb_ol.AppendLine(@"
                <div class='item active'>
                    <ul class='registered-box'>
                    ");
            foreach (var item in list)
            {
                if (item != null)
                {
                    sb_ol.AppendFormat("<li><img src='{0}'></li>", item.Item01).AppendLine();
                    sortId++;
                }
                if(sortId%6 == 0)
                {
                    sb_ol.AppendLine(@"
                </ul>
                </div>
                <div class='item'>
                    <ul class='registered-box'>
                    ");
                }
            }

            sb_ol.AppendLine(@"
                </ul>
                </div>
                    ");
            sb.AppendFormat(@"
    <div class='registered'>
        <div id='registered' class='carousel slide' data-ride='carousel'>
            <!-- Wrapper for slides -->
{0}
            <!-- Controls -->
            <a style='background-image:none;width:5%;color:#525252' class='left carousel-control' href='#registered' role='button' data-slide='prev'>
                <span style='font-size:18px;' class='glyphicon glyphicon-chevron-left'></span>
                <span class='sr-only'>Previous</span>
            </a>
            <a style='background-image:none;width:5%;color:#525252' class='right carousel-control custom-angle' href='#registered' role='button' data-slide='next'>
                <span style='font-size:18px;' class='glyphicon glyphicon-chevron-right'></span>
                <span class='sr-only'>Next</span>
            </a>
        </div>
    </div>
", sb_ol.ToString());
            ViewBag.Links = sb.ToString();
        }

        private void InitThepress()
        {
            var list = INFOR_MASTERService.INFOR_MASTERList
                .Where(t => t.InforCategory.InforCategoryName.Contains("2017HomeThePress") && t.Status == 0)
                .ToList();
            StringBuilder sb = new StringBuilder();
            StringBuilder sb_item = new StringBuilder();
            foreach (var item in list)
            {
                sb_item.AppendFormat(@"
                    <div class='press-box pull-left'>
                <a href='{5}'><img src='{0}'></a>
                <a href='{5}'><p class='press-title'>{1}</p></a>
                <p class='press-content'>{2}</p>
                <div class='post-by'>
                    <span class='s-1'>Post by</span>
                    <span class='author'>{3} {4}</span>
                </div>
            </div>
                    ", item.Item01, item.InforSubject, item.Introduction, item.Author, item.CreateDate.ToString(), "#").AppendLine();
            }
            if (!string.IsNullOrEmpty(sb_item.ToString()))
            {
                sb.AppendFormat(@"
<div class='the-press'>
        <div class='the-press-title'>
            <h3>HOT OFF THE PRESS</h3>
        </div>
        <div class='the-press-list'>
	{0}
	</div>
</div>
", sb_item.ToString()).AppendLine();
                ViewBag.ThePress = sb.ToString();
            }
        }

        private string GetRecommonedTabItem(string groupID)
        {
            var list = PROD_GROUP_ITEMService.PROD_GROUP_ITEMList
                .Where(t => t.GROUP_INDEX == groupID && t.Status == 1)
                .Select(t => new
                {
                    Picture = t.Picture,
                    Product = t.Product,
                }
                ).ToList();
            StringBuilder sb_item = new StringBuilder();
            foreach (var item in list)
            {
                if (item.Product != null)
                {
                    sb_item.AppendFormat(@"
<div class='equipment-box pull-left'>
                    <a href='{4}'><img class='pro-img' src='{0}' /></a>
                    <p class='star-line'>
                        <img src='/Content/snell/images/star-4.png'>
                    </p>
                    <a href='{4}'><p class='equipment-name'>{1}</p></a>
                    <div class='price-cart'>
                        <div class='price pull-left'>
                            <p class='old-price'>${2}</p>
                            <p class='new-price'>${3}</p>
                        </div>
                        <div class='pull-right'>
                            <a href='javascript:void(0);' class='cart' data-pno='{5}' >
                                <img src='/Content/snell/images/cart_03.png'>
                            </a>
                        </div>
                    </div>
                    <div class='wishlist-compare'>
                        <div class='wishlist pull-left'><a href='javascript:void(0);' class='add_fav' data-pno='{5}'><i class='fa fa-heart-o'></i> <span>wishlist</span></a></div>
                    </div>
                    <div class='clearfix'></div>
                </div>
", item.Picture, item.Product.ProductName, item.Product.ListPrice.Value.ToString("N2"), item.Product.StndCost.Value.ToString("N2"), Url.Action("Detail", "Prod", new { id = item.Product.ID }),item.Product.ProductNo.Trim()).AppendLine();
                }
            }
            return sb_item.ToString();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(LoginModel model)
        {
            OperationResult result = new OperationResult(OperationResultType.Warning, "Wrong username or password");
            var user = Rela_contactService.Rela_contactList.FirstOrDefault(t => t.UserName == model.LoginName);
            if (user != null)
            {
                if (user.Password == model.LoginPwd)
                {
                    result = new OperationResult(OperationResultType.Success, "login successful");
                    Session["CurrentSnellUser"] = user;
                    Session.Timeout = 20;

                    float frt = 0;
                    float acost = 0;
                    DBService.GetFreightByCust(user.AccountInfo.Account_no, out frt, out acost);
                    user.Freight = frt;
                    user.Miscellaneous = acost;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            ViewBag.UserName = string.Empty;
            base.CurrentUser = null;
            return PartialView("_Top");
        }

        [OutputCache(NoStore = true, Location = OutputCacheLocation.Client, Duration = 1)]
        public ActionResult Top()
        {
            ViewBag.UserName = string.Empty;
            if (base.CurrentUser != null)
            {
                ViewBag.UserName = base.CurrentUser.UserName;
            }
            return PartialView("_Top");
        }
        
        [OutputCache(NoStore = true, Location = OutputCacheLocation.Client, Duration = 1)]
        public ActionResult ShoppingCart()
        {
            //ShoppingCart
            ViewBag.ShoppingCartModel = base.InitSalesEbasket();
            return PartialView("_ShoppingCart");
            //return Json(cartModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddCart(string pno,int qty)
        {
            int ret = 0;
            if (!string.IsNullOrEmpty(pno) && base.CurrentUser != null) {
                Domain.Models.Product.PROD_MASTER prod = PROD_MASTERService.GetProduct(pno);
                if (prod != null)
                {
                    if (base.CurrentUser.AccountInfo != null)
                    {
                        string unitPriceType = string.Empty;
                        double uPrice = 0;
                        PROD_MASTERService.GetSellingPrice(prod.ProductNo, base.CurrentUser.AccountInfo.Account_no, out uPrice, out unitPriceType);
                        if (uPrice == 0)
                        {
                            uPrice = (double)prod.ListPrice;
                        }
                        var model = new SALES_EBASKETModel
                        {
                            ID = CombHelper.NewComb().ToString(),
                            ContactID = base.CurrentUser.Id,
                            CreateDate = DateTime.Now,
                            Creator = base.CurrentUser.AccountInfo.Account_no,
                            CustomerID = base.CurrentUser.AccountInfo.Account_no,//request
                            ModiDate = DateTime.Now,
                            Modifier = base.CurrentUser.AccountInfo.Account_no,
                            ProductNo = prod.ProductNo,
                            Quantity = Convert.ToDouble(qty),
                            Unit = prod.BaseUOFM,
                            UnitPrice = uPrice,
                            UnitPType = unitPriceType,
                            Status = 0,
                            MakeOrderID = "",
                        };
                        if ((bool)base.CurrentUser.IsContractLimit && unitPriceType != "L")//only to purchase contract goods
                        {
                            if (unitPriceType == "S")//Special Price
                            {
                                bool hasContractPrice = SALES_CONTRACTPRICEService.IsExist(base.CurrentUser.AccountInfo.Account_no, prod.ProductNo);
                                if (!hasContractPrice)
                                {
                                    return Json(new { success = false, message = "You need to purchase contract goods." });
                                }
                            }
                        }
                        ret = SALES_EBASKETService.ModificationCart(model); //成功了
                        //ret = SALES_EBASKETService.ModificationByProce(model);//有问题不可以使用
                    }
                }
            }


            if (ret > 0)
            {
                return Json(new { success = true, message = "successfull added to cart" });
            }
            else
            {
                return Json(new { success = false, message = "added to cart failed." });
            }
        }

        [HttpPost]
        public JsonResult DeleCart(string id)
        {
            int ret = 0;
            if (!string.IsNullOrEmpty(id) && base.CurrentUser != null)
            {
                if (base.CurrentUser.AccountInfo != null)
                {
                    ret = SALES_EBASKETService.DeleteItem(id);
                }
            }
            if (ret > 0)
            {
                //ShoppingCart
                ViewBag.ShoppingCartModel = InitSalesEbasket(); //重新计算购物车信息

                return Json(new { success = true, message = "successfull delete cart item", shoppingCart = ViewBag.ShoppingCartModel });
            }
            else
            {
                return Json(new { success = false, message = "delete cart item failed." });
            }
        }

        [HttpPost]
        public JsonResult UpdateCartItem(string sku, string qty)
        {
            int ret = 0;
            //string sku = Request.Params["sku"].ToString();
            int q = ConvertHelper.ObjToInt(qty);
            if (!string.IsNullOrEmpty(sku) && base.CurrentUser != null)
            {
                if (base.CurrentUser.AccountInfo != null)
                {
                    ret = SALES_EBASKETService.UpdateEBasketQuantity(base.CurrentUser.AccountInfo.Account_no, base.CurrentUser.Id, sku, (float)q);
                }
            }
            if (ret > 0)
            {
                //ShoppingCart
                ViewBag.ShoppingCartModel = InitSalesEbasket(); //重新计算购物车信息

                return Json(new { success = true, message = "successfull update to cart" , shoppingCart = ViewBag.ShoppingCartModel });
            }
            else
            {
                return Json(new { success = false, message = "update cart failed." });
            }
        }

        public JsonResult Search(string query)
        {
            //[
            //{ "id":"Perdix perdix","label":"Grey Partridge","value":"Grey Partridge"},
            //{ "id":"Passer domesticus","label":"House Sparrow","value":"House Sparrow"},
            //{ "id":"Passer montanus","label":"Eurasian Tree Sparrow","value":"Eurasian Tree Sparrow"},
            //{ "id":"Accipiter nisus","label":"Eurasian Sparrow Hawk","value":"Eurasian Sparrow Hawk"},
            //{ "id":"Stercorarius parasiticus","label":"Parasitic Jaeger","value":"Parasitic Jaeger"},
            //{ "id":"Alectoris graeca","label":"Rock Partridge","value":"Rock Partridge"}
            //....]
            var list = PROD_MASTERService.PROD_MASTERList.Where(t => t.ProductNo.Contains(query))
                .AsEnumerable()
                .Select(t => new Ecomm.Site.Models.Product.PROD_MASTER.DataItemModel
                {

                    value = t.ProductNo.Trim(),
                    data = new Models.Product.PROD_MASTER.SearchItemModel
                    {
                        ProductId = t.ID.Trim(),
                        ProductNo = t.ProductNo.Trim(),
                        ProductName = Server.UrlEncode(t.ProductName.Trim())
                    }
                });
            
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}