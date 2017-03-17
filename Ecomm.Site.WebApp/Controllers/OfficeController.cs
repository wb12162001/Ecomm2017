using Ecomm.Site.Models.EpSnell.Rela_account_location;
using Ecomm.Site.Models.MyOffice.SALES_EBASKET;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecomm.Site.WebApp.Controllers
{
    public class OfficeController : Ecomm.Site.WebApp.Common.BaseController
    {
        [Import]
        public Ecomm.Core.Service.GPSPS.IDBService DBService { get; set; }

        [Import]
        public Ecomm.Core.Service.EpSnell.IRela_account_locationService Rela_account_locationService { get; set; }

        [Import]
        public Ecomm.Core.Service.EpSnell.IRela_contact_locationService Rela_contact_locationService { get; set; }
        // GET: Office
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShoppingCart()
        {
            if (ShoppingOrder == null)
            {
                ShoppingOrder = new ShoppingOrderViewModel();
            }
            return View();
        }

        public ActionResult ShoppingInformation()
        {
            var contact_shipto = Rela_contact_locationService.Rela_contact_locationList.Where(t => t.Account_no == CurrentUser.AccountInfo.Account_no && t.Contact_id == CurrentUser.Id)
                    .Select(t => t.Address_no);

            var shipto = Rela_account_locationService.Rela_account_locationList.Where(t => t.Account_no == CurrentUser.AccountInfo.Account_no && contact_shipto.Contains(t.Address_id))
                .Select(t => new Rela_account_locationModel
                {
                    Account_no = t.Account_no,
                    Address_id = t.Address_id,
                    Name = t.Name,
                    Description = t.Description,
                    Contact_id = t.Contact_id,
                    Address1 = t.Address1,
                    Address2 = t.Address2,
                    City = t.City,
                    State = t.State,
                    Country = t.Country,
                    Zip = t.Zip,
                    P_address1 = t.P_address1,
                    P_address2 = t.P_address2,
                    P_city = t.P_city,
                    P_state = t.P_state,
                    P_country = t.P_country,
                    P_zip = t.P_zip,
                    Phone1 = t.Phone1,
                    Phone2 = t.Phone2,
                    Fax = t.Fax,
                    Email = t.Email,
                    Www = t.Www,
                    Isort = t.Isort,
                    Pic_s = t.Pic_s,
                    Pic_b = t.Pic_b,
                    Detail = t.Detail,
                    Status = t.Status,
                    Cretuser = t.Cretuser,
                    Cretdate = t.Cretdate,
                    Modidate = t.Modidate,
                    Modiuser = t.Modiuser,
                    Row_id = t.Row_id,
                }
                );
            ViewBag.ShoppingInfor_Shoptos = shipto;
            ViewBag.ShoppingInfor_User = CurrentUser;

            //ShoppingOrder.ShoppingInfo.PurchaseNO = "test 001";

            //ViewBag.ShoppingInforModel = ShoppingOrder.ShoppingInfo;
            //ShoppingOrder.ShoppingCart = (ShoppingCartViewModel)ViewBag.ShoppingCartModel;
            if (ShoppingOrder.ShoppingInfo.ShipTo != "SHIPTONEW")
            {
                ShoppingOrder.ShoppingInfo.Company = string.Empty;
                ShoppingOrder.ShoppingInfo.Contact = string.Empty;
                ShoppingOrder.ShoppingInfo.City = string.Empty;
                ShoppingOrder.ShoppingInfo.Suburb = string.Empty;
                ShoppingOrder.ShoppingInfo.Address = string.Empty;
            }
            string btn_js = "return CheckShipTo();";
            if (!string.IsNullOrEmpty(CurrentUser.AccountInfo.Item6))
            {
                string[] limit = CurrentUser.AccountInfo.Item6.Split(new char[] { ';', ',', ':' });
                if (Array.IndexOf<string>(limit, "PurchaseNo") > -1)
                {
                    btn_js = "return CheckShipTo(true);";
                }
            }
            ViewBag.form_js = btn_js;

            return View(ShoppingOrder.ShoppingInfo);
        }
        [HttpPost]
        public ActionResult ConfirmOrder(ShoppingInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ShipTo != "SHIPTONEW") {
                    
                    var info = Rela_account_locationService.Rela_account_locationList.FirstOrDefault(t => t.Account_no == CurrentUser.AccountInfo.Account_no && t.Address_id == model.ShipTo);
                    model.Company = info.Address1;
                    model.Contact = info.Contact_id;
                    model.City = info.City;
                    model.Suburb = info.State;
                    model.Address = info.Address2;
                }
                ShoppingOrder.ShoppingInfo = model;
                
            }

            ShoppingOrder.ShoppingCart = (ShoppingCartViewModel)ViewBag.ShoppingCartModel;
            ViewBag.ShoppingOrderModel = ShoppingOrder;
            return View();
        }

        public ActionResult PrintOrder()
        {
            ViewBag.ShoppingOrderModel = ShoppingOrder;
            return View();
        }
    }
}