// ===================================================================
// File: SALES_EORDERSModel.cs
// 2017/1/12: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using Quick.Site.Common.Models;
using System.Web.Mvc;
using Quick.Site.Common;
using Ecomm.Site.Models.MyOffice.SALES_EBASKET;

namespace Ecomm.Site.Models.MyOffice.SALES_EORDERS
{
    public class SALES_EORDERSModel : EntityCommon
    {

        public SALES_EORDERSModel()
        {
            SearchModel = new SearchModel();
        }

        public SALES_EORDERSModel(ShoppingOrderViewModel model)
        {
            SearchModel = new SearchModel();
            //ID = model.ShoppingInfo.ID;
            //RowID = model.ShoppingInfo.RowID;
            OrderType = 1;
            CustomerID = model.Customer;
            ShipID = model.ShoppingInfo.ShipTo;
            Freight = model.ShoppingCart.Freight;
            ShipName = model.ShoppingInfo.Company;
            ShipAddress = model.ShoppingInfo.Address;
            ShipCity = model.ShoppingInfo.City;
            //ShipZip = model.ShoppingInfo.ShipZip;
            //ShipCountry = model.ShoppingInfo.Suburb;
            ShipState = model.ShoppingInfo.Suburb;
            //ShipPhone = model.ShoppingInfo.;
            AuthCode = model.ShoppingInfo.Contact;
            //BillTitle = model.ShoppingInfo.BillTitle;
            //BillName = model.ShoppingInfo.BillName;
            //BillAddress = model.ShoppingInfo.BillAddress;
            //BillCity = model.ShoppingInfo.BillCity;
            //BillState = model.ShoppingInfo.BillState;
            //BillZip = model.ShoppingInfo.BillZip;
            //BillCountry = model.ShoppingInfo.BillCountry;
            //BillPhone = model.ShoppingInfo.BillPhone;
            CommText = model.ShoppingInfo.CommonText;
            //CreditCard = model.ShoppingInfo.CreditCard;
            //CcName = model.ShoppingInfo.CcName;
            //CcExpMonth = model.ShoppingInfo.CcExpMonth;
            //CcExpYear = model.ShoppingInfo.CcExpYear;
            //CcNumber = model.ShoppingInfo.CcNumber;
            //CcType = model.ShoppingInfo.CcType;
            //VerifyWith = model.ShoppingInfo.VerifyWith;
            PurchaseNo = model.ShoppingInfo.PurchaseNO;
            OrderDate = model.OrderDate;
            //RequiredDate = model.ShoppingInfo.RequiredDate;
            //ShippedDate = model.ShoppingInfo.ShippedDate;
            CreateDate = model.CreateDate;
            ModiDate = model.ModiDate;
            Creator = model.Creator;
            Modifier = model.Modifier;
            IsPrint = model.IsPrint;
            ProcStatus = model.ProcStatus;
            Status = model.Status;
            //Item01 = model.ShoppingInfo.Item01;
            //Item02 = model.ShoppingInfo.Item02;
            //Item03 = model.ShoppingInfo.Item03;
            //Item04 = model.ShoppingInfo.Item04;
            //Item05 = model.ShoppingInfo.Item05;
            ContactID = model.ContactID;
            Miscellaneous = model.ShoppingCart.Miscellaneous;
        }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID can not be empty")]
		public string ID  { get; set; }


        [Display(Name = "RowID")]
        [Required(ErrorMessage = "RowID can not be empty")]
		public int RowID  { get; set; }


        [Display(Name = "OrderType")]
		public int? OrderType  { get; set; }


        [Display(Name = "CustomerID")]
		public string CustomerID  { get; set; }


        [Display(Name = "ShipID")]
		public string ShipID  { get; set; }


        [Display(Name = "Freight")]
		public double? Freight  { get; set; }


        [Display(Name = "ShipName")]
		public string ShipName  { get; set; }


        [Display(Name = "ShipAddress")]
		public string ShipAddress  { get; set; }


        [Display(Name = "ShipCity")]
		public string ShipCity  { get; set; }


        [Display(Name = "ShipZip")]
		public string ShipZip  { get; set; }


        [Display(Name = "ShipCountry")]
		public string ShipCountry  { get; set; }


        [Display(Name = "ShipState")]
		public string ShipState  { get; set; }


        [Display(Name = "ShipPhone")]
		public string ShipPhone  { get; set; }


        [Display(Name = "AuthCode")]
		public string AuthCode  { get; set; }


        [Display(Name = "BillTitle")]
		public string BillTitle  { get; set; }


        [Display(Name = "BillName")]
		public string BillName  { get; set; }


        [Display(Name = "BillAddress")]
		public string BillAddress  { get; set; }


        [Display(Name = "BillCity")]
		public string BillCity  { get; set; }


        [Display(Name = "BillState")]
		public string BillState  { get; set; }


        [Display(Name = "BillZip")]
		public string BillZip  { get; set; }


        [Display(Name = "BillCountry")]
		public string BillCountry  { get; set; }


        [Display(Name = "BillPhone")]
		public string BillPhone  { get; set; }


        [Display(Name = "CommText")]
		public string CommText  { get; set; }


        [Display(Name = "CreditCard")]
		public string CreditCard  { get; set; }


        [Display(Name = "CcName")]
		public string CcName  { get; set; }


        [Display(Name = "CcExpMonth")]
		public string CcExpMonth  { get; set; }


        [Display(Name = "CcExpYear")]
		public string CcExpYear  { get; set; }


        [Display(Name = "CcNumber")]
		public string CcNumber  { get; set; }


        [Display(Name = "CcType")]
		public string CcType  { get; set; }


        [Display(Name = "VerifyWith")]
		public string VerifyWith  { get; set; }


        [Display(Name = "PurchaseNo")]
		public string PurchaseNo  { get; set; }


        [Display(Name = "OrderDate")]
		public DateTime? OrderDate  { get; set; }


        [Display(Name = "RequiredDate")]
		public DateTime? RequiredDate  { get; set; }


        [Display(Name = "ShippedDate")]
		public DateTime? ShippedDate  { get; set; }


        [Display(Name = "CreateDate")]
		public DateTime? CreateDate  { get; set; }


        [Display(Name = "ModiDate")]
		public DateTime? ModiDate  { get; set; }


        [Display(Name = "Creator")]
		public string Creator  { get; set; }


        [Display(Name = "Modifier")]
		public string Modifier  { get; set; }


        [Display(Name = "IsPrint")]
		public bool IsPrint  { get; set; }


        [Display(Name = "ProcStatus")]
		public int? ProcStatus  { get; set; }


        [Display(Name = "Status")]
		public int? Status  { get; set; }


        [Display(Name = "Item01")]
		public string Item01  { get; set; }


        [Display(Name = "Item02")]
		public string Item02  { get; set; }


        [Display(Name = "Item03")]
		public string Item03  { get; set; }


        [Display(Name = "Item04")]
		public string Item04  { get; set; }


        [Display(Name = "Item05")]
		public string Item05  { get; set; }


        [Display(Name = "ContactID")]
		public string ContactID  { get; set; }


        [Display(Name = "Miscellaneous")]
		public double? Miscellaneous  { get; set; }

        
        public SearchModel SearchModel { get; set; }
    }
    
    public class SearchModel
    {
        public SearchModel()
        {
            EnabledItems = new List<SelectListItem> { 
                new SelectListItem { Text = "--- Please select ---", Value = "-1", Selected = true }, 
                new SelectListItem { Text = "Yes", Value = "1" }, 
                new SelectListItem { Text = "No", Value = "0" }
            };
        }

        [Display(Name = "Name")]
        public string LoginName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "IsEnabled")]
        public bool Enabled { get; set; }

		[Display(Name = "Start Time")]
		[DataType(DataType.DateTime)]
		public DateTime? StartTime { get; set; }

		[Display(Name = "End Time")]
		[DataType(DataType.DateTime)]
		public DateTime? EndTime { get; set; }

        public List<SelectListItem> EnabledItems { get; set; }
    }

    public class Order_StatusModel
    {
        public string gSOPNUMBE { get; set; }

        public string PONO { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DOCDATE { get; set; }

        public string gCUSTNMBR { get; set; }

        public string gCUSTNAME { get; set; }

        public string PACKSLIP { get; set; }
        public string PROCSTEP { get; set; }
    }

    public class OrderSalesByCustidBylocaModel
    {
        public string PRSTADCD { get; set; }
        public float PRICE { get; set; }
        public int ORDERS { get; set; }

        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }

        public string CITY { get; set; }
        public string PHONE1 { get; set; }
        public string FAX { get; set; }
        public string CNTCPRSN { get; set; }
    }

    public class OrderHistoryByClasalesModel
    {
        public string ITCLASS { get; set; }
        public float PRICE { get; set; }
    }

    public class OrderHistoryByInvoiceModel
    {
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime IDATE { get; set; }
        public string CSTPONBR { get; set; }
        public string SOPNUMBE { get; set; }
        public int SOPTYPE { get; set; }
    }
    public class OrderHistoryByClasalesProductModel
    {
        public string ITEMNMBR { get; set; }
        public string ITEMDESC { get; set; }
        public string UOFM { get; set; }
        public string CUSTNMBR { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float PRICE { get; set; }
        public float QTY { get; set; }
        public float ORDERS { get; set; }
        public string CLASS1 { get; set; }
        public string CLASS3 { get; set; }
        public string CLASS6 { get; set; }
    }

    public class Order_ItemModel
    {
        public string ITEMNMBR { get; set; }

        public string ITEMDESC { get; set; }

        public string UOFM { get; set; }

        public string ITMCLSCD { get; set; }

        public double Qty_Ordered { get; set; }

        public double Qty_Shipped { get; set; }
        public double Qty_BackOrdered { get; set; }
    }

    public class OrderHistoryLocaByuseridModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string CITY { get; set; }
        public string CNTCPRSN { get; set; }
        public string contact_id { get; set; }
    }


    public class InvoiceItemModel
    {
        public string ITEMNMBR { get; set; }
        public string ITEMDESC { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? QTY_ORDERED { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? QTY_SHIPPED { get; set; }
        public string UOFM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? UNITPRCE { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? XTNDPRCE { get; set; }

    }


    public class InvoiceHeaderModel
    {
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DOCDATE { get; set; }
        public string GstNo { get; set; }
        public string PageTitle { get; set; }
        public string SOPNUMBE { get; set; }
        public string PCKSLPNO { get; set; }
        public int? MSTRNUMB { get; set; }
        public string ORIGNUMB { get; set; }
        public string CUSTNMBR { get; set; }
        public string CUSTNAME { get; set; }
        public string CSTPONBR { get; set; }

        public string SLPRSNID { get; set; }
        public string PRSTADCD { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SUBTOTAL { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? MISCAMNT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? FRTAMNT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? TAXAMNT { get; set; }
        public decimal? DOCAMNT { get; set; }
        public string SHIP_ADDR1 { get; set; }
        public string SHIP_ADDR2 { get; set; }
        public string SHIP_CITY { get; set; }
        public string BILL_ADDR1 { get; set; }
        public string BILL_ADDR2 { get; set; }
        public string BILL_CITY { get; set; }

    }

    public class InvoicePageModel : OrderHistoryByInvoiceModel
    {
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public Decimal? XTNDPRCE { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public Decimal? TAXAMNT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public Decimal? FRTAMNT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public Decimal? MISCAMNT { get; set; }
    }
}

