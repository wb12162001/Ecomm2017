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
using System.Text;
using System.IO;
using Quick.Framework.Tool;

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
            //Ben 2014-08-20 For the MinOrderValue
            if (CurrentUser.MinOrderValue > 0 && CurrentUser.MinOrderValue > double.Parse(ShoppingCart.CartTotal))
            {
                msg = string.Format("We are unable to process as below ${0}/order threshold, please increase your order or contact the customers service team on 0800736557 to discuss options.", CurrentUser.MinOrderValue.ToString("N2"));
            }
            ViewBag.MinOrderMsg = msg;
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
                   return  Common.SendEmailHelper.Send_Email(repEmail, repToEmail, strhtml.ToString(), Common.SendEmailHelper.Order_MailSubject + " " + InvoiceNo);
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
            if (!CurrentUser.IsManager && CurrentUser.AmountLimit > 0)//用户不是管理员，订单有总额限制
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
            orderId = orderId.Replace("INT","");
            OperationResult result = new OperationResult(OperationResultType.Warning, "send email fail.");
            int r = SendEmail(orderId, emailTo);
            if(r ==0) result = new OperationResult(OperationResultType.Success, "send email success.");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}