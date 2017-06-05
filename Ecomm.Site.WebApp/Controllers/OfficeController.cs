using Ecomm.Site.Models.EpSnell.Rela_account_location;
using Ecomm.Site.Models.MyOffice.SALES_EBASKET;
using Ecomm.Site.Models.MyOffice.SALES_EORDERS;
using Ecomm.Site.Models.MyOffice.SALES_EORDERDETAILS;
using Ecomm.Site.Models.InetApp.EOrder;
using Ecomm.Site.Models.InetApp.EOrderDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;
using System.Text;
using System.IO;
using Quick.Framework.Tool;
using Ecomm.Site.Models.MyOffice.SALES_ESIORDERFORM;
using Ecomm.Site.Models.EpSnell.Rela_contact;
using System.Threading;
using Ecomm.Domain.Models.MyOffice;
using Newtonsoft.Json;
using Ecomm.Site.Models.EpSnell.Rela_contact_location;

namespace Ecomm.Site.WebApp.Controllers
{
    public class OfficeController : Ecomm.Site.WebApp.Common.BaseController
    {
        [Import]
        public Ecomm.Core.Service.GPSPS.IDBService DBService { get; set; }
        [Import]
        public Ecomm.Core.Service.EpSnell.IRela_contactService Rela_contactService { get; set; }

        [Import]
        public Ecomm.Core.Service.EpSnell.IRela_account_locationService Rela_account_locationService { get; set; }

        [Import]
        public Ecomm.Core.Service.EpSnell.IRela_contact_locationService Rela_contact_locationService { get; set; }

        [Import]
        public Ecomm.Core.Service.EpSnell.IRela_location_limitService Rela_location_limitService { get; set; }

        [Import]
        public Ecomm.Core.Service.MyOffice.ISALES_EORDERSService SALES_EORDERSService { get; set; }

        [Import]
        public Ecomm.Core.Service.MyOffice.ISALES_EORDERDETAILSService SALES_EORDERDETAILSService { get; set; }

        [Import]
        public Ecomm.Core.Service.InetApp.IEOrderService EOrderService { get; set; }

        [Import]
        public Ecomm.Core.Service.InetApp.IEOrderDetailService EOrderDetailService { get; set; }

        [Import]
        public Ecomm.Core.Service.MyOffice.ISALES_ESIORDERFORMService SALES_ESIORDERFORMService { get; set; }

        [Import]
        public Ecomm.Core.Service.MyOffice.ISALES_FAVFOLDERService SALES_FAVFOLDERService { get; set; }

        [Import]
        public Ecomm.Core.Service.MyOffice.ISALES_FAVORITEService SALES_FAVORITEService { get; set; }

        [Import]
        public Ecomm.Core.Service.MyOffice.ISALES_CONTRACTPRICEService SALES_CONTRACTPRICEService { get; set; }

        [Import]
        public Ecomm.Core.Service.Product.IPROD_MASTERService PROD_MASTERService { get; set; }

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
            ShoppingCartViewModel ShoppingCart = (ShoppingCartViewModel)ViewBag.ShoppingCartModel;
            string msg = string.Empty;
            string misc_msg = string.Empty;
            //Ben 2014-08-20 For the MinOrderValue 页面一直有这个消息;只是判断是否显示;
            if (CurrentUser.MinOrderValue > 0)
            {
                msg = string.Format("We are unable to process as below ${0}/order threshold, please increase your order or contact the customers service team on 0800736557 to discuss options.", CurrentUser.MinOrderValue.ToString("N2"));

            }
            if (CurrentUser.MinOrderSize > 0)
            {
                misc_msg = string.Format("Save ${1}! Simply by increasing your orders to ${0}, your small orders fee will be waived!", CurrentUser.MinOrderSize.ToString("N0"), CurrentUser.MinOrderMisc.ToString("N0"));
            }
            ViewBag.MinOrderMsg = msg;
            ViewBag.Misctitle = misc_msg;
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
                if (model.ShipTo != "SHIPTONEW")
                {

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
            ViewBag.CurrentUser = CurrentUser;
            return View();
        }

        /// <summary>
        /// 测试状态（demo）,订单保存在InetSnell下。
        /// </summary>
        private int DemoOrder(out string orderId)
        {
            int retsult = 0;
            SALES_EORDERSModel eorderInfo = new SALES_EORDERSModel(ShoppingOrder); //Ben 2017/3/21 redo: 这里对象还没有值

            var limitInfo = Rela_location_limitService.Rela_location_limitList.FirstOrDefault(t => t.Account_no == CurrentUser.AccountInfo.Account_no && t.Address_id == eorderInfo.ShipID);
            if (limitInfo != null)//如果有月限制
            {
                //如果订单在location范围中达月总额限制，也Hold
                double sum = SALES_EORDERSService.GetOrdersByCurrentMonth(CurrentUser.AccountInfo.Account_no, eorderInfo.ShipID);//获取当前月所有订单
                if (limitInfo.Month_quota > 0 && limitInfo.Month_quota <= sum)
                {
                    eorderInfo.ProcStatus = 3;//this proc status is Hold;
                    //SALES_EORDERSService.Update(eorderInfo);
                }
            }
            orderId = eorderInfo.ID = Guid.NewGuid().ToString();
            int result_oid = SALES_EORDERSService.Insert2(eorderInfo);
            if (result_oid > 0)
            {
                ShoppingOrder.OrderID = string.Concat("INT", orderId); //result_oid
                //Ecomm.BLL.SALES_EORDERDETAILS sales_eodetail = Ecomm.BLL.BLLFactory<Ecomm.BLL.SALES_EORDERDETAILS>.Instance;
                foreach (var drv in ShoppingOrder.ShoppingCart.Sales_Ebaskets)
                {
                    SALES_EORDERDETAILSModel detailInfo = new SALES_EORDERDETAILSModel();

                    detailInfo.ProductNo = drv.ProductNo;
                    detailInfo.OrderQty = drv.Quantity;
                    detailInfo.UnitPrice = drv.UnitPrice;
                    detailInfo.Unit = drv.Unit;
                    detailInfo.UnitPType = drv.UnitPType;
                    //detailInfo.Modifier = drv["Modifier"].ToString();
                    //detailInfo.ModiDate = DateTime.Now;
                    detailInfo.Status = 0;
                    detailInfo.Freight = ShoppingOrder.ShoppingCart.Freight;//redo
                    detailInfo.Tax = 0;
                    detailInfo.UnitCost = drv.StndCost;
                    detailInfo.OrderID = eorderInfo.ID; //redo
                    detailInfo.Creator = eorderInfo.Creator;
                    detailInfo.CreateDate = DateTime.Now;

                    SALES_EORDERDETAILSService.Insert(detailInfo);//Insert Eorder detail

                    //update EBasket
                    SALES_EBASKETService.UpdateEBasket(drv.ID, eorderInfo.ID, CurrentUser.UserName);

                    //update Easiorderform
                    //redo
                }
                retsult = result_oid;
            }

            //remove session eorder info
            //Response.Redirect("PrintOrder.aspx?state=ok&oid=" + base.EOrderInfo.ID, false);
            //RedirectToAction("PrintOrder", "Office", new { state = "ok", oid = eorderInfo.ID });
            return retsult;
        }

        /// <summary>
        /// live正式状态，即订单保存在inetApp下。
        /// </summary>
        private int LiveOrder()
        {
            int retsult = 0;
            try
            {
                EOrderModel ordermodel = new EOrderModel(ShoppingOrder); //redo

                var limitInfo = Rela_location_limitService.Rela_location_limitList.FirstOrDefault(t => t.Account_no == CurrentUser.AccountInfo.Account_no && t.Address_id == ordermodel.ShipID);
                if (limitInfo != null)//如果有月限制
                {
                    //如果订单在location范围中达月总额限制，也Hold
                    var dt = EOrderService.GetOrdersByCurrentMonth(CurrentUser.AccountInfo.Account_no, ordermodel.ShipID);//获取当前月所有订单
                    double sum = dt.Sum();

                    if (limitInfo.Month_quota > 0 && limitInfo.Month_quota <= sum)
                    {
                        //ordermodel.OrderID = result_oid;
                        ordermodel.PROC_STATUS = 3;//this proc status is Hold;
                        //EOrderService.Update(ordermodel);
                    }
                }

                int result_oid = EOrderService.InsertOrder(ordermodel);
                if (result_oid > 0)
                {
                    ShoppingOrder.OrderID = string.Concat("INT", result_oid);
                    foreach (var drv in ShoppingOrder.ShoppingCart.Sales_Ebaskets)
                    {
                        double qty = drv.Quantity;
                        double uprice = (double)drv.UnitPrice;
                        EOrderDetailModel detailMode = new EOrderDetailModel(result_oid, drv);
                        EOrderDetailService.InsertEOrderDetail(detailMode);
                        //snell.InsertOrderDetailOfTesting(result_oid, drv["ProductNo"].ToString(), qty, uprice);

                        //update EBasket
                        SALES_EBASKETService.UpdateEBasket(drv.ID, result_oid.ToString(), CurrentUser.UserName);
                    }
                    retsult = result_oid;
                    //remove session eorder info
                    //RedirectToAction("PrintOrder", "Office", new { state = "ok", oid = result_oid });
                    //return;
                }
                else
                {
                    retsult = -1;
                    //Ecomm.Common.ExceptionManagement.LogException(BLL.Util.GetObjectfields(base.EOrderInfo));
                    //RedirectToAction("PrintOrder", "Office", new { state = "failed" });
                    //return;
                }
            }
            catch (Exception ex)
            {
                retsult = -99;
                RedirectToAction("Index", "Error", new { msg = ex.Message });
                //return;
            }
            return retsult;
        }

        private int SendEmail(string OrderID, string repEmail)
        {
            //string repEmail = CurrentUser.Email;
            string repToEmail = CurrentUser.Report_To_Email;
            if (!string.IsNullOrEmpty(repEmail))
            {
                string body = string.Empty;

                StringBuilder strhtml = new StringBuilder();
                //创建StreamReader对象
                using (StreamReader sr = new StreamReader(Server.MapPath("/Content") + "\\snell\\Tpl\\OrderLetter.html"))
                {
                    string oneline;
                    //读取指定的HTML文件模板
                    while ((oneline = sr.ReadLine()) != null)
                    {
                        strhtml.Append(oneline);
                    }
                    sr.Close();
                }
                if (!string.IsNullOrEmpty(OrderID))
                {
                    //string authName = string.Empty;
                    string Address = string.Empty;
                    string City = string.Empty;
                    string InvoiceNo = string.Empty;
                    string Comment = string.Empty;
                    string Company = string.Empty;
                    string CUSTNAME = CurrentUser.AccountInfo.Name;
                    string PurchaseNo = string.Empty;
                    string YourName = string.Empty;
                    string Freight = string.Empty;
                    string Miscellaneous = string.Empty;
                    string Subtotal = string.Empty;
                    string Gst = string.Empty;
                    string Total = string.Empty;
                    string productlist = string.Empty;

                    string date = DateTime.Now.ToString("dd  MMMM  yyyy", new System.Globalization.DateTimeFormatInfo());

                    if (Common.Util.IsTesting || CurrentUser.AccountRole.Equals("0"))
                    {
                        //Ecomm.BLL.SALES_EORDERS sales_eorder = Ecomm.BLL.BLLFactory<Ecomm.BLL.SALES_EORDERS>.Instance;
                        //Model.SALES_EORDERSInfo info = sales_eorder.Get(OrderID);
                        var info = SALES_EORDERSService.SALES_EORDERSList.FirstOrDefault(t => t.ID == OrderID);
                        if (info != null)
                        {
                            string status = string.Empty;
                            if (info.ProcStatus == 3)
                            {
                                status = " The order is hold!";
                            }
                            Address = info.ShipAddress;
                            City = info.ShipCity;
                            Comment = info.CommText;
                            Company = info.ShipName;
                            PurchaseNo = info.PurchaseNo;
                            YourName = info.AuthCode;
                            Freight = "$ " + info.Freight.Value.ToString("N2");
                            Miscellaneous = "$ " + info.Miscellaneous.Value.ToString("N2");
                            InvoiceNo = string.Format("INT{0} {1}", info.RowID, status);



                            var lt = SALES_EORDERDETAILSService.QueryEntities(0, string.Format("a.OrderID='{0}'", OrderID), string.Empty);

                            StringBuilder sb = new StringBuilder();
                            foreach (var item in lt)
                            {
                                double unitPrice = item.UnitPrice.Value;
                                double ptotal = (double)(item.UnitPrice * item.OrderQty);
                                sb.Append("<tr style=\"border-bottom:1px solid #EBEBEB; width:95%; height: 30px; vertical-align:top;font-size:12px;\">");
                                sb.Append("<td>" + item.ProductNo + "</td>");
                                sb.Append("<td>" + item.ProductName + "</td>");
                                sb.Append("<td>" + item.Unit + "</td>");
                                sb.Append("<td align=\"center\">" + item.OrderQty + "</td>");
                                sb.Append("<td align=\"right\">$" + unitPrice.ToString("N2") + "</td>");
                            }
                            productlist = sb.ToString();

                            //object sumObject = lt.Select(o => (double)(o.UnitPrice * o.OrderQty)).Sum();
                            //Literal lt = (Literal)rptProductLine.Controls[rptProductLine.Controls.Count - 1].FindControl("liTotal");
                            //string t = sumObject != null ? sumObject.ToString() : "0";
                            double sutotal = lt.Select(o => (double)(o.UnitPrice * o.OrderQty)).Sum();
                            Subtotal = "$" + sutotal.ToString("N2");
                            //ltFreight.Text = "$ " + base.UserInfo.Freight.ToString("N2");
                            double gst = SYS_CONFIGService.GetCalculatedGst(info.Freight.Value, info.Miscellaneous.Value, sutotal);
                            Gst = "$ " + gst.ToString("N2");
                            Total = "$" + (sutotal + info.Freight.Value + info.Miscellaneous.Value + gst).ToString("N2");
                        }

                    }
                    else
                    {
                        //Ecomm.BLL.Snell_Hold sales_eorder = new Ecomm.BLL.Snell_Hold();
                        //DataTable dt = sales_eorder.GetOrderOfTesting(int.Parse(OrderID)).Tables[0];
                        var order_infor = EOrderService.EOrderList.FirstOrDefault(pt => pt.OrderID == int.Parse(OrderID));
                        double freight = 0;
                        double misc = 0;
                        if (order_infor != null)
                        {
                            freight = (double)order_infor.Freight;
                            misc = (double)order_infor.Miscellaneous;
                            string status = string.Empty;
                            if ((int)order_infor.PROC_STATUS == 3)
                            {
                                status = " The order is hold!";
                            }
                            Address = order_infor.Ship_Address;
                            City = order_infor.Ship_City;
                            Comment = order_infor.CommText;
                            Company = order_infor.Ship_Name;
                            PurchaseNo = order_infor.Pono;
                            YourName = order_infor.Auth_code;
                            Freight = "$ " + freight.ToString("N2");
                            Miscellaneous = "$ " + misc.ToString("N2");
                            InvoiceNo = string.Format("INT{0} {1}", order_infor.OrderID, status);

                            //Ecomm.BLL.Snell_Hold sales_eodetail = new Ecomm.BLL.Snell_Hold();
                            //DataSet ds = sales_eodetail.GetOrderDetailOfTesting(int.Parse(OrderID));

                            var list_details = EOrderDetailService.QueryEntities(int.Parse(OrderID));
                            //dt = ds.Tables[0];
                            StringBuilder sb = new StringBuilder();
                            foreach (var item in list_details)
                            {
                                double unitPrice = (double)item.UnitPrice;
                                double pTotal = (double)((double)item.UnitPrice * item.Orderqty);
                                sb.Append("<tr style=\"border-bottom:1px solid #EBEBEB; width:95%; height: 30px; vertical-align: top;font-size:12px;\">");
                                sb.Append("<td>" + item.Sku + "</td>");
                                sb.Append("<td>" + item.Skudesc + "</td>");
                                sb.Append("<td>" + item.Unit + "</td>");
                                sb.Append("<td align=\"center\">" + item.Orderqty + "</td>");
                                sb.Append("<td align=\"right\">$" + unitPrice.ToString("N2") + "</td>");
                            }
                            productlist = sb.ToString();
                            double sutotal = list_details.Select(d => (double)((double)d.UnitPrice * d.Orderqty)).Sum();
                            Subtotal = "$" + sutotal.ToString("N2");
                            //ltFreight.Text = "$ " + base.UserInfo.Freight.ToString("N2");
                            double gst = SYS_CONFIGService.GetCalculatedGst(freight, misc, sutotal);
                            Gst = "$ " + gst.ToString("N2");
                            Total = "$" + (sutotal + freight + misc + gst).ToString("N2");
                        }
                    }
                    strhtml.Replace("$url$", Common.Util.SiteRootURL);
                    strhtml.Replace("$month", date);
                    strhtml.Replace("$orderNumber", InvoiceNo);
                    strhtml.Replace("$productlist", productlist);
                    strhtml.Replace("$purchaseNo", PurchaseNo);
                    strhtml.Replace("$name", YourName);
                    strhtml.Replace("$company", Company);
                    strhtml.Replace("$CUSTNAME", CUSTNAME);
                    strhtml.Replace("$city", City);
                    strhtml.Replace("$Address", Address);
                    strhtml.Replace("$Comment", Comment);
                    strhtml.Replace("$Subtotal", Subtotal);
                    strhtml.Replace("$Freight", Freight);
                    strhtml.Replace("$Miscellaneous", Miscellaneous);
                    strhtml.Replace("$Get", Gst);
                    strhtml.Replace("$TOTAL", Total);
                    //0 为成功
                    return Common.SendEmailHelper.Send_Email(repEmail, repToEmail, strhtml.ToString(), Common.SendEmailHelper.Order_MailSubject + " " + InvoiceNo);
                }
            }
            return -1;
        }

        private void RemoveSession(string OrderID)
        {

            if (ShoppingOrder != null)
            {
                string authName = ShoppingOrder.ShoppingInfo.PurchaseName;
                //订单产生成功，并发邮件给用户
                ShoppingOrder = null;
                //SendEmail(OrderID, authName); //redo 需要使用线程发送;
            }
        }

        [HttpPost]
        public ActionResult PrintOrder()
        {
            if (ShoppingOrder == null)
            {
                return RedirectToAction("Index", "Error", new { msg = "There was an error accessing the page." });
                //return;
            }
            if (!ModelState.IsValid) //验证失败
            {
                return View();
            }
            ShoppingOrder.OrderID = Guid.NewGuid().ToString();
            ShoppingOrder.OrderDate = DateTime.Now;
            ShoppingOrder.ContactID = CurrentUser.Id;
            ShoppingOrder.Customer = CurrentUser.AccountInfo.Account_no;
            ShoppingOrder.Creator = CurrentUser.UserName;
            ShoppingOrder.ModiDate = DateTime.Now;
            ShoppingOrder.CreateDate = DateTime.Now;
            ShoppingOrder.IsPrint = false;
            ShoppingOrder.Status = 0;
            ShoppingOrder.ProcStatus = 0;

            //其它逻辑增加 Aprove,Hold
            if (!(bool)CurrentUser.IsManager && CurrentUser.AmountLimit > 0)//用户不是管理员，订单有总额限制
            {
                if (Double.Parse(ShoppingOrder.ShoppingCart.CartTotal) >= CurrentUser.AmountLimit)
                {
                    ShoppingOrder.ProcStatus = 3;//this proc status is Hold;
                }
            }

            int ret = 0;
            string orderId = string.Empty;
            //It's Testing(or User is Demo user)
            if (Common.Util.IsTesting || CurrentUser.AccountRole.Equals("0"))
            {
                ret = DemoOrder(out orderId);
            }
            else
            {
                ret = LiveOrder();

                orderId = ret.ToString();
            }
            var PrintOrderInfo = ShoppingOrder;
            //PrintOrderInfo.OrderID = orderId;
            //保存记录成功; remove session
            if (ret > 0)
            {
                //01 订单产生成功，并发邮件给用户
                //ShoppingOrder = null;
                //02 发邮件
                RemoveSession(orderId);
            }
            else //失败;
            {
                return RedirectToAction("Index", "Error", new { msg = "Submit order failed." });
            }

            ViewBag.ShoppingOrderModel = PrintOrderInfo;
            return View();
        }

        [HttpPost]
        public ActionResult SendUserEmail(string orderId, string emailTo)
        {
            orderId = orderId.Replace("INT", "");
            OperationResult result = new OperationResult(OperationResultType.Warning, "send email fail.");
            int r = SendEmail(orderId, emailTo);
            if (r == 0) result = new OperationResult(OperationResultType.Success, "send email success.");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #region EOF
        private List<string> getCategoryStrWhere()
        {
            var user = base.CurrentUser;
            List<string> condition = new List<string>();
            
            condition.Add(string.Format(" CustomerID='{0}'", user.AccountInfo.Account_no));
            //Ben 2013-08-29
            //用户登录只能查看自己的ShipTo
            if (user.AccountInfo != null)
            {
                var locations = Rela_account_locationService.Rela_account_locationList.Where(t => t.Account_no == user.AccountInfo.Account_no && t.Contact_id == user.Id).
                    Select(t => new { address_no = t.Address_id });
                var locs = from loc in locations.AsEnumerable()
                           select "'" + loc.address_no.Trim() + "'";
                if (locs.Count() > 0)
                {
                    string addressWhere = string.Join(",", locs.ToArray());
                    condition.Add(string.Format("ShipTo in ({0})", addressWhere));
                }
            }
            return condition;
        }
        private string getStrWhere(string category, string location ,string ctype)
        {
            string strWhrer = string.Empty;
            List<string> condition = getCategoryStrWhere();

            if (ctype == "1")
            {
                location = string.Empty;
            }
            if (ctype == "2")
            {
                category = string.Empty;
            }

            if (!string.IsNullOrEmpty(location) && !location.Contains("ALL"))
            {
                condition.Add(string.Format("ShipTo='{0}'", location));
            }
            if (!string.IsNullOrEmpty(category))
            {
                string cateWhere = string.Empty;

                string[] cateArr = category.Split(',');
                List<string> cateList = new List<string>();
                foreach (string c in cateArr)
                {
                    cateList.Add("'" + c + "'");
                }
                cateWhere = string.Join(",", cateList.ToArray());

                condition.Add(string.Format("a.CategoryCode in ({0})", cateWhere));
            }

            if (condition.Count > 0) strWhrer = " Where " + string.Join(" and ", condition.ToArray());
            return strWhrer;
            //locationList = GetEOFShipToCount(strWhrer);
        }
        public ActionResult EasiOrderForm(int id = 1)
        {
            //分页控件语言定义
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            string tab_type = Common.Util.GetCookie("snell_product_tab_type");
            if (string.IsNullOrEmpty(tab_type))
            {
                Common.Util.SetCookie("snell_product_tab_type", "list");
            }
            var orderby = Request.Params["sortModle"] ?? " ProductName asc";
            var category = Request.Params["category"] ?? "";
            var location = Request.Params["location"] ?? "";
            var ctype = Request.Params["ctype"] ?? "0"; //这里区分是:category, location
            if (!string.IsNullOrEmpty(category))
            {
                var cates = JsonConvert.DeserializeObject<List<string>>(category);
                category = string.Join(",", cates.ToArray());
            }

            if (!string.IsNullOrEmpty(location))
            {
                var locas = JsonConvert.DeserializeObject<List<string>>(location);
                location = string.Join(",", locas.ToArray());
            }

            int pageSize = base.CurrentUser.EofPageSize;
            int pageCount = 0;
            
            string strWhere = getStrWhere(category, location, ctype);
            
            var dt = SALES_ESIORDERFORMService.GetItems(base.CurrentUser.AccountInfo.Account_no,strWhere, location, orderby, id, pageSize, out pageCount);// Ben 2012-12-25
            if (dt != null && dt.Count() > 0)
            {
                var items = dt.AsEnumerable()
                            .Select(t => new EOF_PAGE_MASTER
                            {
                                ProductID = t.ProductID,
                                ProductNo = t.ProductNo,
                                ProductName = t.ProductName,
                                BigPic = Common.Util.GetProductImgUrl(t.BigPic, false),
                                SmallPic = Common.Util.GetProductImgUrl(t.SmallPic),
                                MiddlePic = Common.Util.GetProductImgUrl(t.SmallPic).Replace("Small", "Middl"),
                                StockType = t.StockType,
                                SellPrice = SALES_ESIORDERFORMService.getCurrentPrice(t.CurrentPrice, t.ListPrice),//Ecomm.BLL.Snell_Hold.GetSellPrice(item.Field<string>("ProductNo"), item.Field<double>("ListPrice"), 0).ToString("N2"), //在EasiorderForm不需要对价格进行处理，因为已经登陆了

                                Qty0 = t.Qty0,
                                Qty1 = t.Qty1,
                                Qty2 = t.Qty2,
                                Qty3 = t.Qty3,
                                Qty4 = t.Qty4,
                                Forecast = t.Forecast,
                                CategoryName = t.CategoryName,//Ben 2015-12-18 修改存储过程同时修改这个字段
                                BaseUOFM = t.BaseUOFM,
                                ListPrice = t.ListPrice,
                                Item04 = string.IsNullOrEmpty(t.Item04) ? "" : t.Item04,
                                pCount = pageCount,
                                altPath = Common.Util.SiteRootURL + "detailchart.aspx?proNo=" + t.ProductNo
                            });

                if (!string.IsNullOrEmpty(orderby) && orderby.IndexOf("SellPrice") > -1)
                {
                    if (orderby.IndexOf("asc") > -1)
                    {
                        items.OrderBy(i => i.SellPrice);
                    }
                    if (orderby.IndexOf("desc") > -1)
                    {
                        items.OrderByDescending(i => i.SellPrice);
                    }
                }
                ViewBag.PagedListEofModel = new PagedList<EOF_PAGE_MASTER>(items, id, pageSize, pageCount);
            }
            ViewBag.Months = new EOF_PAGE_Other_MASTER
            {
                Month0 = Common.Util.GetMonthName(DateTime.Now.Month),
                Month1 = Common.Util.GetMonthName(DateTime.Now.AddMonths(-1).Month),
                Month2 = Common.Util.GetMonthName(DateTime.Now.AddMonths(-2).Month),
                Month3 = Common.Util.GetMonthName(DateTime.Now.AddMonths(-3).Month),
                Month4 = Common.Util.GetMonthName(DateTime.Now.AddMonths(-4).Month),
            };
            if (Request.IsAjaxRequest())
            {
                System.Threading.Thread.Sleep(1000);
                return PartialView("_EofList");
            }

            EOF_PAGE_Other2_MASTER eof_master = new EOF_PAGE_Other2_MASTER();
            //IEnumerable<EOF_Location> locationList = null;
            string strWhrer2 = string.Empty;
            List<string> condition = getCategoryStrWhere();
            if (condition.Count > 0) strWhrer2 = " Where " + string.Join(" and ", condition.ToArray());
            eof_master.Categories = BindCategory(strWhrer2).ToList();
            eof_master.Locations = BindLocation(strWhrer2).ToList();

            var myfavs = SALES_FAVFOLDERService.GetFavFoldersAndItemCount(base.CurrentUser.AccountInfo.Account_no, base.CurrentUser.Id);
            eof_master.MyFavourites = myfavs.Select(t => new EOF_Favourite
            {
                Count = t.itemCount,
                Favourite = t.FolderName,
                FavouriteID = t.ID
            }).ToList();

            ViewBag.EOF_Model = eof_master;
            return View();
        }

        private IEnumerable<EOF_Category> BindCategory(string strWhere)
        {
            var rows = SALES_ESIORDERFORMService.GetByCustIDAndShipto(base.CurrentUser.AccountInfo.Account_no, string.Empty, "ALL", strWhere, string.Empty);
            var categories = from category in rows
                             group category by new { code = category.CategoryCode, name = category.CategoryName?? category.MenuAlias } into cs
                             select new EOF_Category
                             {
                                 CategoryName = cs.Key.name,
                                 CategoryCode = cs.Key.code,
                                 Count = cs.Count()
                             };
            return categories;
        }
        private IEnumerable<EOF_Location> BindLocation(string strWhere)
        {
            var rows = SALES_ESIORDERFORMService.GetEOFShipToCount(strWhere);
            var locats = from loca in rows
                         select new EOF_Location
                         {
                             Count = loca.Total,
                             ShopName = loca.ShipTo
                         };
            return locats;

        }

        #endregion

        #region CustomizedProduct
        public ActionResult CustomizedProdcut(int id = 1)
        {
            //分页控件语言定义
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            string tab_type = Common.Util.GetCookie("snell_product_tab_type");
            if (string.IsNullOrEmpty(tab_type))
            {
                Common.Util.SetCookie("snell_product_tab_type", "list");
            }
            var orderby = Request.Params["sortModle"] ?? " ProductName asc";
            var category = Request.Params["category"] ?? "";
            var location = Request.Params["location"] ?? "";
            if (!string.IsNullOrEmpty(category))
            {
                var cates = JsonConvert.DeserializeObject<List<string>>(category);
                category = string.Join(",", cates.ToArray());
            }

            if (!string.IsNullOrEmpty(location))
            {
                var locas = JsonConvert.DeserializeObject<List<string>>(location);
                location = string.Join(",", locas.ToArray());
            }

            int pageSize = base.CurrentUser.EofPageSize;
            int pageCount = 0;

            string strWhere = string.Empty;
            List<string> condition = new List<string>();
            //if (!string.IsNullOrEmpty(location) && !location.Contains("ALL"))
            //{
            //    condition.Add(string.Format("ShipTo='{0}'", location));
            //}
            if (!string.IsNullOrEmpty(category))
            {
                string cateWhere = string.Empty;

                string[] cateArr = category.Split(',');
                List<string> cateList = new List<string>();
                foreach (string c in cateArr)
                {
                    cateList.Add("'" + c + "'");
                }
                cateWhere = string.Join(",", cateList.ToArray());

                condition.Add(string.Format("CategoryCode in ({0})", cateWhere));
            }
            if (condition.Count > 0) strWhere = string.Join(" and ", condition.ToArray());

            var dt = SALES_ESIORDERFORMService.GetCustomizedProducts(strWhere, base.CurrentUser.AccountInfo.Account_no,  orderby,  pageSize, id, out pageCount);// Ben 2012-12-25
            if (dt != null && dt.Count() > 0)
            {
                var items = dt.AsEnumerable()
                            .Select(t => new EOF_PAGE_MASTER
                            {
                                ProductID = t.ProductID,
                                ProductNo = t.ProductNo,
                                ProductName = t.ProductName,
                                BigPic = Common.Util.GetProductImgUrl(t.BigPic, false),
                                SmallPic = Common.Util.GetProductImgUrl(t.SmallPic),
                                MiddlePic = Common.Util.GetProductImgUrl(t.SmallPic).Replace("Small", "Middl"),
                                StockType = t.StockType,
                                SellPrice = PROD_MASTERService.GetSellPrice(t.ProductNo, Common.Util.TransformObjToDou(t.ListPrice), (double)t.SpecialPrice), //在EasiorderForm不需要对价格进行处理，因为已经登陆了
                                CategoryName = string.IsNullOrEmpty(t.CategoryName) ? t.CategoryCode : t.CategoryName,
                                BaseUOFM = t.BaseUOFM,
                                ListPrice = t.ListPrice,
                                pCount = pageCount,
                                altPath = Common.Util.SiteRootURL + "detailchart.aspx?proNo=" + t.ProductNo
                            });

                if (!string.IsNullOrEmpty(orderby) && orderby.IndexOf("SellPrice") > -1)
                {
                    if (orderby.IndexOf("asc") > -1)
                    {
                        items.OrderBy(i => i.SellPrice);
                    }
                    if (orderby.IndexOf("desc") > -1)
                    {
                        items.OrderByDescending(i => i.SellPrice);
                    }
                }
                ViewBag.PagedListModel = new PagedList<EOF_PAGE_MASTER>(items, id, pageSize, pageCount);
            }
            if (Request.IsAjaxRequest())
            {
                System.Threading.Thread.Sleep(1000);
                return PartialView("_CustomizedProdList");
            }
            EOF_PAGE_Other2_MASTER eof_master = new EOF_PAGE_Other2_MASTER();
            ViewBag.EOF_Model = eof_master;
            eof_master.Categories = BindCustomizedProdCategory().ToList();
            return View();
        }

        private IEnumerable<EOF_Category> BindCustomizedProdCategory()
        {
            int totalcount = 0;
            var rows = SALES_ESIORDERFORMService.GetCustomizedProducts(string.Empty, base.CurrentUser.AccountInfo.Account_no, string.Empty, 0, 1, out totalcount); ;
            var categories = from category in rows
                             group category by new { code = category.CategoryCode, name = category.CategoryName ?? category.MenuAlias } into cs
                             select new EOF_Category
                             {
                                 CategoryName = cs.Key.name,
                                 CategoryCode = cs.Key.code,
                                 Count = cs.Count()
                             };
            return categories;
        }

        #endregion

        #region ContractPricing

        public ActionResult ContractPricing(int id = 1)
        {
            //分页控件语言定义
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            string tab_type = Common.Util.GetCookie("snell_product_tab_type");
            if (string.IsNullOrEmpty(tab_type))
            {
                Common.Util.SetCookie("snell_product_tab_type", "list");
            }
            var orderby = Request.Params["sortModle"] ?? " ProductName asc";
            var category = Request.Params["category"] ?? "";
            var location = Request.Params["location"] ?? "";
            if (!string.IsNullOrEmpty(category))
            {
                var cates = JsonConvert.DeserializeObject<List<string>>(category);
                category = string.Join(",", cates.ToArray());
            }

            if (!string.IsNullOrEmpty(location))
            {
                var locas = JsonConvert.DeserializeObject<List<string>>(location);
                location = string.Join(",", locas.ToArray());
            }

            int pageSize = base.CurrentUser.EofPageSize;
            int pageCount = 0;

            string strWhere = string.Empty;
            List<string> condition = new List<string>();
            condition.Add(string.Format("a.CustomerID = '{0}'", base.CurrentUser.AccountInfo.Account_no));
            if (!string.IsNullOrEmpty(category))
            {
                string cateWhere = string.Empty;

                string[] cateArr = category.Split(',');
                List<string> cateList = new List<string>();
                foreach (string c in cateArr)
                {
                    cateList.Add("'" + c + "'");
                }
                cateWhere = string.Join(",", cateList.ToArray());

                condition.Add(string.Format("f0.CategoryCode in ({0})", cateWhere));
            }
            if (condition.Count > 0) strWhere = "  Where " + string.Join(" and ", condition.ToArray());

            var dt = SALES_CONTRACTPRICEService.GetContractPric(strWhere, orderby, pageSize, id, out pageCount);// Ben 2012-12-25
            if (dt != null && dt.Count() > 0)
            {
                var items = dt.AsEnumerable()
                            .Select(t => new EOF_PAGE_MASTER
                            {
                                ProductID = t.ProductID,
                                ProductNo = t.ProductNo,
                                ProductName = t.ProductName,
                                BigPic = Common.Util.GetProductImgUrl(t.BigPic, false),
                                SmallPic = Common.Util.GetProductImgUrl(t.SmallPic),
                                MiddlePic = Common.Util.GetProductImgUrl(t.SmallPic).Replace("Small", "Middl"),
                                StockType = t.StockType,
                                SellPrice = PROD_MASTERService.GetSellPrice(t.ProductNo, Common.Util.TransformObjToDou(t.ListPrice), (double)t.SpecialPrice), //在EasiorderForm不需要对价格进行处理，因为已经登陆了
                                CategoryName = string.IsNullOrEmpty(t.CategoryName) ? t.CategoryCode : t.CategoryName,
                                BaseUOFM = t.BaseUOFM,
                                ListPrice = t.ListPrice,
                                pCount = pageCount,
                                altPath = Common.Util.SiteRootURL + "detailchart.aspx?proNo=" + t.ProductNo
                            });

                if (!string.IsNullOrEmpty(orderby) && orderby.IndexOf("SellPrice") > -1)
                {
                    if (orderby.IndexOf("asc") > -1)
                    {
                        items.OrderBy(i => i.SellPrice);
                    }
                    if (orderby.IndexOf("desc") > -1)
                    {
                        items.OrderByDescending(i => i.SellPrice);
                    }
                }
                ViewBag.PagedListModel = new PagedList<EOF_PAGE_MASTER>(items, id, pageSize, pageCount);
            }
            if (Request.IsAjaxRequest())
            {
                System.Threading.Thread.Sleep(1000);
                return PartialView("_CustomizedProdList");
            }
            EOF_PAGE_Other2_MASTER eof_master = new EOF_PAGE_Other2_MASTER();
            ViewBag.EOF_Model = eof_master;
            eof_master.Categories = BindContractPricingCategory().ToList();
            return View();
        }

        private IEnumerable<EOF_Category> BindContractPricingCategory()
        {
            int totalcount = 0;
            var rows = SALES_CONTRACTPRICEService.GetContractPric(" where a.CustomerID = '" + base.CurrentUser.AccountInfo.Account_no + "'", string.Empty, 0, -1, out totalcount); ;
            var categories = from category in rows
                             group category by new { code = category.CategoryCode, name = category.CategoryName ?? category.MenuAlias } into cs
                             select new EOF_Category
                             {
                                 CategoryName = cs.Key.name,
                                 CategoryCode = cs.Key.code,
                                 Count = cs.Count()
                             };
            return categories;
        }

        #endregion

        #region My Favourites
        public ActionResult MyFavourites()
        {
            var myfavs = SALES_FAVFOLDERService.GetFavFoldersAndItemCount(base.CurrentUser.AccountInfo.Account_no, base.CurrentUser.Id);
            ViewBag.MyFavourites = myfavs.Select(t => new EOF_Favourite
            {
                Count = t.itemCount,
                Favourite = t.FolderName,
                FavouriteID = t.ID,
                Img = GetFavFolderFirstImg(t.ID)
            }).ToList();

            return View();
        }

        private string GetFavFolderFirstImg(string favFolderID)
        {
           string img =  SALES_FAVORITEService.GetFavFolderFirstImg(favFolderID);
            if (img != null && !string.IsNullOrEmpty(img))
            {
                img = Common.Util.UploadFilesRootURL + img;
            }
            return img;
        }
        [HttpPost]
        public JsonResult UpdateFavourite(string hdfavid, string FavouriteName)
        {
            if (string.IsNullOrEmpty(hdfavid))
            {
                Models.MyOffice.SALES_FAVFOLDER.SALES_FAVFOLDERModel model = new Models.MyOffice.SALES_FAVFOLDER.SALES_FAVFOLDERModel
                {
                    ID = Guid.NewGuid().ToString(),
                    FolderName = FavouriteName,
                    Status = 0,
                    CreateDate = DateTime.Now,
                    CustomerID = CurrentUser.AccountInfo.Account_no,
                    ContactID = CurrentUser.Id,
                    Creator = CurrentUser.UserName,
                };
                SALES_FAVFOLDERService.Insert(model);
                return Json(new { success = true, message = "added success" });
            }
            else
            {
                var info = SALES_FAVFOLDERService.SALES_FAVFOLDERList.FirstOrDefault(t => t.ID == hdfavid);
                if (info != null)
                {
                    info.FolderName = FavouriteName;
                    info.ModiDate = DateTime.Now;
                    info.Modifier = CurrentUser.UserName;
                    SALES_FAVFOLDERService.Update(info);
                    return Json(new { success = true, message = "edit success" });
                }
            }
            return Json(new { success = false, message = "failed" });
        }

        [HttpPost]
        public JsonResult RemoveFavourite(string favid)
        {
            SALES_FAVFOLDERService.DeleteBysql(favid);
            return Json(new { success = true, message = "delete success" });
        }

        [HttpPost]
        public JsonResult RemoveFavouriteItem(string favid)
        {
            SALES_FAVORITEService.Delete(favid);
            return Json(new { success = true, message = "delete success" });
        }

        public ActionResult MyFavouriteItems(int id = 1,string favId ="")
        {
            //分页控件语言定义
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            string tab_type = Common.Util.GetCookie("snell_product_tab_type");
            if (string.IsNullOrEmpty(tab_type))
            {
                Common.Util.SetCookie("snell_product_tab_type", "list");
            }
            var orderby = Request.Params["sortModle"] ?? " ProductName asc";
            var category = Request.Params["category"] ?? "";
            if (string.IsNullOrEmpty(favId)) favId = Request.Params["favId"] ?? "";
            if (!string.IsNullOrEmpty(category))
            {
                var cates = JsonConvert.DeserializeObject<List<string>>(category);
                category = string.Join(",", cates.ToArray());
            }


            int pageSize = base.CurrentUser.EofPageSize;
            int pageCount = 0;

            string strWhere = string.Empty;
            List<string> condition = new List<string>();
            if (!string.IsNullOrEmpty(favId))
            {
                condition.Add(string.Format("a.FavFolderID = '{0}'", favId));
            }
            if (!string.IsNullOrEmpty(category))
            {
                string cateWhere = string.Empty;

                string[] cateArr = category.Split(',');
                List<string> cateList = new List<string>();
                foreach (string c in cateArr)
                {
                    cateList.Add("'" + c + "'");
                }
                cateWhere = string.Join(",", cateList.ToArray());

                condition.Add(string.Format("f0.CategoryCode in ({0})", cateWhere));
            }
            if (condition.Count > 0) strWhere = string.Join(" and ", condition.ToArray());

            var dt = SALES_FAVORITEService.GetAllByCondition(CurrentUser.AccountInfo.Account_no,CurrentUser.Id, strWhere);// Ben 2012-12-25
            if (dt != null && dt.Count() > 0)
            {
                var items = dt.AsEnumerable()
                            .Select(t => new EOF_PAGE_MASTER
                            {
                                ID = t.ID,
                                ProductID = t.ProductID,
                                ProductNo = t.ProductNo,
                                ProductName = t.ProductName,
                                BigPic = Common.Util.GetProductImgUrl(t.BigPic, false),
                                SmallPic = Common.Util.GetProductImgUrl(t.SmallPic),
                                MiddlePic = Common.Util.GetProductImgUrl(t.SmallPic).Replace("Small", "Middl"),
                                StockType = t.StockType,
                                SellPrice = PROD_MASTERService.GetSellPrice(t.ProductNo, Common.Util.TransformObjToDou(t.ListPrice), (double)t.SpecialPrice), //在EasiorderForm不需要对价格进行处理，因为已经登陆了
                                Qty0 = SALES_ESIORDERFORMService.GetQTYBycustomerID(CurrentUser.AccountInfo.Account_no, t.ProductNo)[0],
                                Qty1 = SALES_ESIORDERFORMService.GetQTYBycustomerID(CurrentUser.AccountInfo.Account_no, t.ProductNo)[1],
                                Qty2 = SALES_ESIORDERFORMService.GetQTYBycustomerID(CurrentUser.AccountInfo.Account_no, t.ProductNo)[2],
                                Qty3 = SALES_ESIORDERFORMService.GetQTYBycustomerID(CurrentUser.AccountInfo.Account_no, t.ProductNo)[3],
                                CategoryName = string.IsNullOrEmpty(t.CategoryName) ? t.CategoryCode : t.CategoryName,
                                BaseUOFM = t.BaseUOFM,
                                ListPrice = t.ListPrice,
                                pCount = pageCount,
                                altPath = Common.Util.SiteRootURL + "detailchart.aspx?proNo=" + t.ProductNo
                            });

                if (!string.IsNullOrEmpty(orderby))
                {
                    if(orderby.IndexOf("ProductName") > -1)
                    {
                        if (orderby.IndexOf("asc") > -1)
                        {
                            items = items.OrderBy(i => i.ProductName);
                        }
                        if (orderby.IndexOf("desc") > -1)
                        {
                            items = items.OrderByDescending(i => i.ProductName);
                        }
                    }
                    if (orderby.IndexOf("ProductNo") > -1)
                    {
                        if (orderby.IndexOf("asc") > -1)
                        {
                            items = items.OrderBy(i => i.ProductNo);
                        }
                        if (orderby.IndexOf("desc") > -1)
                        {
                            items = items.OrderByDescending(i => i.ProductNo);
                        }
                    }
                    if (orderby.IndexOf("CategoryCode") > -1)
                    {
                        if (orderby.IndexOf("asc") > -1)
                        {
                            items = items.OrderBy(i => i.CategoryCode);
                        }
                        if (orderby.IndexOf("desc") > -1)
                        {
                             items.OrderByDescending(i => i.CategoryCode);
                        }
                    }

                }
                ViewBag.PagedListModel = items.ToPagedList(id, 5);
            }
            ViewBag.Months = new EOF_PAGE_Other_MASTER
            {
                Month0 = Common.Util.GetMonthName(DateTime.Now.Month),
                Month1 = Common.Util.GetMonthName(DateTime.Now.AddMonths(-1).Month),
                Month2 = Common.Util.GetMonthName(DateTime.Now.AddMonths(-2).Month),
                Month3 = Common.Util.GetMonthName(DateTime.Now.AddMonths(-3).Month),
                Month4 = Common.Util.GetMonthName(DateTime.Now.AddMonths(-4).Month),
            };
            if (Request.IsAjaxRequest())
            {
                //System.Threading.Thread.Sleep(1000);
                return PartialView("_Favourites");
            }
            EOF_PAGE_Other2_MASTER eof_master = new EOF_PAGE_Other2_MASTER();
            ViewBag.EOF_Model = eof_master;
            ViewBag.FavId = favId;
            ViewBag.FavName = SALES_FAVFOLDERService.GetFavName(favId);

            var myfavs = SALES_FAVFOLDERService.GetFavFoldersAndItemCount(base.CurrentUser.AccountInfo.Account_no, base.CurrentUser.Id);
            eof_master.MyFavourites = myfavs.Select(t => new EOF_Favourite
            {
                Count = t.itemCount,
                Favourite = t.FolderName,
                FavouriteID = t.ID
            }).ToList();
            eof_master.Categories = BindMyFavouritesCategory(favId).ToList();
            return View();

            //var items = SALES_FAVORITEService.SALES_FAVORITEList.Where(t => t.FavFolderID == favId).Select();
            //return View();
        }

        private IEnumerable<EOF_Category> BindMyFavouritesCategory(string favId)
        {
            string strWhere = string.Empty;
            if (!string.IsNullOrEmpty(favId))
            {
                strWhere = string.Format("a.FavFolderID = '{0}'", favId);
            }
            var rows = SALES_FAVORITEService.GetAllByCondition(CurrentUser.AccountInfo.Account_no, CurrentUser.Id, strWhere);
            var categories = from category in rows
                             group category by new { code = category.CategoryCode, name = category.CategoryName ?? category.MenuAlias } into cs
                             select new EOF_Category
                             {
                                 CategoryName = cs.Key.name,
                                 CategoryCode = cs.Key.code,
                                 Count = cs.Count()
                             };
            return categories;
        }

        public ActionResult GetMyFav(int pageSize = 5, int pageNumber = 1)
        {
            var myfavs = SALES_FAVFOLDERService.GetFavFoldersAndItemCount(base.CurrentUser.AccountInfo.Account_no, base.CurrentUser.Id);
            var list = myfavs.Select(t => new EOF_Favourite
            {
                Count = t.itemCount,
                Favourite = t.FolderName,
                FavouriteID = t.ID
            }).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            int total = myfavs.Count();
            var json = new { total = total, rows = list };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region User manage
        public ActionResult Users()
        {
            //var ls = Rela_contactService.Rela_contactList.Where(t => t.Account_id == CurrentUser.Account_id);
            //string sql = string.Format("a.[account_id]='{0}' and a.[UserName]<>'' and a.[id]<>'{1}'", base.CurrentUser.Account_id,base.CurrentUser.Id);
            var users = Rela_contactService.Rela_contactList.Where(t => t.Account_id == CurrentUser.Account_id && t.UserName != "" && t.Id != CurrentUser.Id)
                .Select(t=>new Rela_contactModel
                {
                    Name = t.Name,
                    Phone1 = t.Phone1,
                    Mobile = t.Mobile,
                    IsManager = t.IsManager,
                    UserName = t.UserName,
                    Password = t.Password,
                    AmountLimit = t.AmountLimit,
                    Id = t.Id
                });
            ViewBag.UsersModel = users;
            return View();
        }
        public ActionResult UserInfor(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ViewBag.UserModel = GetMyProfile(id);
            }
            return View();
        }

        [HttpPost]
        public ActionResult UpdateUserInfor()
        {
            string id = Request.Form["Id"];
            if (string.IsNullOrEmpty(id))
            {
                return Json(new OperationResult(OperationResultType.Error, "ID is error."));
            }
            Rela_contactModel model = GetMyProfile(id); //ID直接就是用户登录的ID;
            model.Fname = Request.Form["Fname"];
            model.Lname = Request.Form["Lname"];
            model.Email = Request.Form["Email"];
            model.Fax = Request.Form["Fax"];
            model.Mobile = Request.Form["Mobile"];
            model.Phone1 = Request.Form["Phone1"];
            model.Password = Request.Form["Password"];

            double i = 0;
            double.TryParse(Request.Form["AmountLimit"], out i);
            model.AmountLimit = i;
            model.Report_To_Email = Request.Form["Report_To_Email"];

            string IsManager = Request.Form["IsManager"];
            if(IsManager == "1")
            {
                model.IsManager = true;
            }
            else
            {
                model.IsManager = false;
            }

            OperationResult result = Rela_contactService.UpdateMyProfile(model);
            return Json(result);
        }

        public ActionResult MyProfile()
        {
            ViewBag.UserModel = GetMyProfile(string.Empty);
            return View();
        }

        private Rela_contactModel GetMyProfile(string id)
        {
            var user = base.CurrentUser;
            if (!string.IsNullOrEmpty(id))
            {
                user = Rela_contactService.Rela_contactList.FirstOrDefault(t => t.Id == id);
            }
            Rela_contactModel model = new Rela_contactModel();
            if (user != null)
            {
                model.Id = user.Id;
                model.Name = user.Name;
                model.Title = user.Title;
                model.Job_title = user.Job_title;
                model.Fname = user.Fname;
                model.Lname = user.Lname;
                model.Mname = user.Mname;
                model.Gender = user.Gender;
                model.Account_id = user.Account_id;
                model.Iskey = user.Iskey;
                model.Description = user.Description;
                model.Address1 = user.Address1;
                model.Address2 = user.Address2;
                model.City = user.City;
                model.State = user.State;
                model.Country = user.Country;
                model.Zip = user.Zip;
                model.P_address1 = user.P_address1;
                model.P_address2 = user.P_address2;
                model.P_city = user.P_city;
                model.P_state = user.P_state;
                model.P_country = user.P_country;
                model.P_zip = user.P_zip;
                model.Phone1 = user.Phone1;
                model.Phone2 = user.Phone2;
                model.Fax = user.Fax;
                model.Email = user.Email;
                model.Www = user.Www;
                model.Isort = user.Isort;
                model.Pic_s = user.Pic_s;
                model.Pic_b = user.Pic_b;
                model.Detail = user.Detail;
                model.Status = user.Status;
                model.Territory_id = user.Territory_id;
                model.Home_phone = user.Home_phone;
                model.Mobile = user.Mobile;
                model.Department = user.Department;
                model.Birthday = user.Birthday;
                model.Assistant = user.Assistant;
                model.Assistant_phone = user.Assistant_phone;
                model.Report_to = user.Report_to;
                model.Lead_source = user.Lead_source;
                model.Personal_details = user.Personal_details;
                model.Background = user.Background;
                model.Family = user.Family;
                model.Qualifications = user.Qualifications;
                model.Memberships = user.Memberships;
                model.Projects = user.Projects;
                model.Interests = user.Interests;
                model.Quote = user.Quote;
                model.Skills = user.Skills;
                model.Cretuser = user.Cretuser;
                model.Cretdate = user.Cretdate;
                model.Modidate = user.Modidate;
                model.Modiuser = user.Modiuser;
                model.Row_id = user.Row_id;
                model.Isprivate = user.Isprivate;
                model.Owner = user.Owner;
                model.Rn_id = user.Rn_id;
                model.Item1 = user.Item1;
                model.Item2 = user.Item2;
                model.Item3 = user.Item3;
                model.Item4 = user.Item4;
                model.Item5 = user.Item5;
                model.Item6 = user.Item6;
                model.Class1 = user.Class1;
                model.Class2 = user.Class2;
                model.Class3 = user.Class3;
                model.Class4 = user.Class4;
                model.Class5 = user.Class5;
                model.Class6 = user.Class6;
                model.IsManager = user.IsManager;
                model.UserName = user.UserName;
                model.Password = user.Password;
                model.QtyLimit = user.QtyLimit;
                model.AmountLimit = user.AmountLimit;
                model.ItemQtyLimit = user.ItemQtyLimit;
                model.ItemAmountLimit = user.ItemAmountLimit;
                model.AccountRole = user.AccountRole;
                model.IsContractLimit = user.IsContractLimit;
                model.HomePage = user.HomePage;
                model.Report_To_Email = user.Report_To_Email;
            }
            return model;
        }

        [HttpPost]
        public ActionResult UpdateMyProfile()
        {
            Rela_contactModel model = GetMyProfile(string.Empty); //ID直接就是用户登录的ID;
            model.Fname = Request.Form["Fname"];
            model.Lname = Request.Form["Lname"];
            model.Email = Request.Form["Email"];
            model.Fax = Request.Form["Fax"];
            model.Mobile = Request.Form["Mobile"];
            model.Phone1 = Request.Form["Phone1"];
            model.Password = Request.Form["Password"];

            OperationResult result = Rela_contactService.UpdateMyProfile(model);
            return Json(result);
        }

        public ActionResult SyncLocation(string id)
        {
            var shiptos = Rela_account_locationService.Query_SHIPTO(CurrentUser.AccountInfo.Account_no, CurrentUser.Id)
                .Select(t => new Rela_account_location_shiptoModel
                {
                    address1 = t.address1,
                    address2 = t.address2,
                    address_id = t.address_id,
                    contact_id = t.contact_id,
                    description = t.description,
                    isSel = t.isSel
                });
            ViewBag.LocationModel = shiptos;
            return View();
        }

        [HttpPost]
        public ActionResult UpdateSyncLocation(Dictionary<string, string>[] shiptolist)
        {
            OperationResult result = new OperationResult(OperationResultType.Error, "Error");
            string contact_id = CurrentUser.Id;
            string account_no = CurrentUser.AccountInfo.Account_no;
            for (int i = 0; i < shiptolist.Length; i++)
            {
                string address_id = shiptolist[i]["address_id"];
                bool isChecked = bool.Parse(shiptolist[i]["isChecked"]);
                var entity = Rela_contact_locationService.Rela_contact_locationList.FirstOrDefault(t => t.Account_no == account_no && t.Contact_id == contact_id && t.Address_no == address_id);
                if (isChecked)
                {
                    if (entity != null)
                    {
                        UpdateRela_contact_locationModel model = new UpdateRela_contact_locationModel();
                        model.Account_no = entity.Account_no;
                        model.Contact_id = entity.Contact_id;
                        model.Address_no = entity.Address_no;
                        model.Cretdate = entity.Cretdate;
                        model.Modidate = DateTime.Now;
                        model.Cretuser = entity.Cretuser;
                        model.Modiuser = CurrentUser.Name;
                        model.Display_order = entity.Display_order;
                        //model.Row_id = entity.Row_id;
                        model.Status = entity.Status;
                        model.Item1 = entity.Item1;
                        model.Item2 = entity.Item2;
                        model.Item3 = entity.Item3;
                        model.Item4 = entity.Item4;
                        model.Item5 = entity.Item5;
                        model.Item6 = entity.Item6;


                        result = Rela_contact_locationService.Update(model);
                    }
                    else
                    {
                        Rela_contact_locationModel model = new Rela_contact_locationModel();
                        model.Account_no = account_no;
                        model.Contact_id = contact_id;
                        model.Address_no = address_id;
                        model.Cretdate = DateTime.Now;
                        model.Modidate = DateTime.Now;
                        model.Cretuser = CurrentUser.Name;
                        model.Modiuser = CurrentUser.Name;
                        model.Display_order = 0;
                        model.Status = 0;

                        result = Rela_contact_locationService.Insert(model);
                    }
                }
                else
                {
                    result = Rela_contact_locationService.Delete(entity.Account_no, entity.Contact_id, entity.Address_no);
                }
            }             
            
            return Json(result);
        }

        #endregion

        #region Order Limit
        public ActionResult OrderLimit()
        {
            var action = Request.Params["action"];
            var address_id = Request.Params["Address_id"];
            var month_quota = Request.Params["Month_quota"];
            if (!string.IsNullOrEmpty(action))
            {
                var m = Rela_location_limitService.Rela_location_limitList.FirstOrDefault(t => t.Account_no == CurrentUser.AccountInfo.Account_no && t.Address_id == address_id);
                if (m != null && action == "add")
                {
                    action = "edit";
                }

                switch (action)
                {
                    case "add":
                        Models.EpSnell.Rela_location_limit.Rela_location_limitModel info = new Models.EpSnell.Rela_location_limit.Rela_location_limitModel();
                        info.Account_no = CurrentUser.AccountInfo.Account_no;
                        info.Address_id = address_id;
                        info.Month_quota = double.Parse(month_quota);
                        Rela_location_limitService.Insert(info);
                        break;
                    case "edit":
                        if (m != null)
                        {
                            Rela_location_limitService.Update(new Models.EpSnell.Rela_location_limit.UpdateRela_location_limitModel
                            {
                                Account_no = CurrentUser.AccountInfo.Account_no,
                                Address_id = address_id,
                                Month_quota = double.Parse(month_quota),
                                Month_sales = m.Month_sales
                            });
                        }
                        break;
                    case "delete":
                        Rela_location_limitService.Delete(CurrentUser.AccountInfo.Account_no, address_id);
                        break;
                }
            }

            var orders = Rela_location_limitService.Rela_location_limitList.Where(t => t.Account_no == CurrentUser.AccountInfo.Account_no)
                .ToList()
                .Select(t => new Ecomm.Site.Models.EpSnell.Rela_location_limit.Rela_location_limitModel
                {
                    Account_no = t.Account_no,
                    Address_id = t.Address_id,
                    Month_quota = t.Month_quota,
                    Month_sales = t.Month_sales,
                    Address = Rela_account_locationService.GetAddress(t.Account_no,t.Address_id)
                });
            ViewBag.OrderModel = orders;
            var drop = Rela_account_locationService.QueryDropList(CurrentUser.AccountInfo.Account_no)
                .Select(t => new SelectListItem
                {
                    Text = t.name,
                    Value = t.id
                });
            ViewBag.DropDownModel = drop;
            if (Request.IsAjaxRequest())
            {
                return PartialView("_OrderLimitList");
            }
            return View();
        }

        public ActionResult OrderStatus()
        {
            var orders = SALES_EORDERSService.GetOrderStatus(CurrentUser.AccountInfo.Account_no).Select(t => new Order_StatusModel
            {
                DOCDATE = t.DOCDATE,
                gCUSTNAME = t.gCUSTNAME,
                gCUSTNMBR = t.gCUSTNMBR,
                gSOPNUMBE = t.gSOPNUMBE,
                PACKSLIP = t.PACKSLIP,
                PONO = t.PONO,
                PROCSTEP = SALES_EORDERSService.GetStatus(t.PROCSTEP)
            });//redo
            ViewBag.OrderModel = orders;
            return View();
        }

        public ActionResult OrderItemStatus(string packslip)
        {
            var items = DBService.GetOrderItemStatusByPackslip(packslip).
                Select(t => new Order_ItemModel
                {
                    ITEMDESC = t.ITEMDESC,
                    ITEMNMBR = t.ITEMNMBR,
                    ITMCLSCD = t.ITMCLSCD,
                    Qty_BackOrdered = t.Qty_BackOrdered,
                    Qty_Ordered = t.Qty_Ordered,
                    Qty_Shipped = t.Qty_Shipped,
                    UOFM = t.UOFM
                });
            ViewBag.OrderModel = items;
            return View();
        }
        #endregion

        #region Invoices
        public ActionResult Invoices()
        {
            return View();
        }
        #endregion

        #region OrderByLoca
        public ActionResult OrderByLoca()
        {
            return View();
        }

        public ActionResult OrderHistory()
        {
            return View();
        }

        public ActionResult OrderDetail()
        {
            return View();
        }
        #endregion
    }
}