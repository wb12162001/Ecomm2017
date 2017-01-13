using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

using Quick.Framework.Common.ToolsHelper;
using Quick.Site.Common.Models;
using Ecomm.Domain.Models.EpSnell;
using System.Web.UI;
using Ecomm.Site.WebApp.Extension.Filters;
using Ecomm.Core.Service.MyOffice;
using System.ComponentModel.Composition.Hosting;
using Ecomm.Site.Models.MyOffice.SALES_EBASKET;

namespace Ecomm.Site.WebApp.Common
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BaseController : Controller
    {
        [Import]
        protected ISALES_EBASKETService SALES_EBASKETService { get; set; }
        public BaseController()
        {
            if (SALES_EBASKETService == null)
            {
                var container = System.Web.HttpContext.Current.Application["Container"] as CompositionContainer;
                SALES_EBASKETService = container.GetExportedValueOrDefault<ISALES_EBASKETService>();
            }

            ViewBag.UserName = string.Empty;
            if (this.CurrentUser != null)
            {
                ViewBag.UserName = this.CurrentUser.UserName;
            }
            //ShoppingCart
            ViewBag.ShoppingCartModel = InitSalesEbasket();
        }

        protected ShoppingCartViewModel InitSalesEbasket()
        {
            ShoppingCartViewModel cartModel = new ShoppingCartViewModel();
            //var user = SessionHelper.GetSession("CurrentSnellUser") as Rela_contact;
            if (CurrentUser != null)
            {
                var list = SALES_EBASKETService.SALES_EBASKETList
                    .Where(t => t.Status == 0 && t.ContactID == CurrentUser.Id)
                    .Select(t => new SALES_EBASKETModel
                    {
                        UnitPrice = t.UnitPrice,
                        Quantity = t.Quantity,
                        Status = t.Status,
                        ProductNo = t.ProductNo,
                        Unit = t.Unit,
                        UnitPType = t.UnitPType
                    })
                    .ToList();
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
        protected Rela_contact CurrentUser
        {
            get { return GetCurrentUser(); }
            set { Session["CurrentSnellUser"] = value; }
        }
        private Rela_contact GetCurrentUser()
        {
            var user = SessionHelper.GetSession("CurrentSnellUser") as Rela_contact;
            return user;
        }

    }
}