// ===================================================================
// File: EOrderModel.cs
// 2017/3/22: Ben Wang    Original Version
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

namespace Ecomm.Site.Models.InetApp.EOrder
{
    public class EOrderModel : EntityCommon
    {
        public EOrderModel()
        {
            SearchModel = new SearchModel();
        }

        public EOrderModel(ShoppingOrderViewModel model)
        {
            SearchModel = new SearchModel();
            CustID = model.Customer;
            ShipID = model.ShoppingInfo.ShipTo;
            Ship_Name = model.ShoppingInfo.Company;
            Ship_Address = model.ShoppingInfo.Address;
            Ship_City = model.ShoppingInfo.City;
            Pono = model.ShoppingInfo.PurchaseNO;
            CommText = model.ShoppingInfo.CommonText;
            CretDate = model.CreateDate;
            ModiDate = model.ModiDate;
            OrderStats = 0;
            VoidStats = 0;
            PROC_STATUS = (byte)model.ProcStatus;
            Freight = (decimal)model.ShoppingCart.Freight;
            ShopID = model.ContactID;
            Miscellaneous = (decimal)model.ShoppingCart.Miscellaneous;
        }

        [Display(Name = "OrderType")]
		public short? OrderType  { get; set; }


        [Display(Name = "OrderID")]
        [Required(ErrorMessage = "OrderID can not be empty")]
		public int OrderID  { get; set; }


        [Display(Name = "ORIGTYPE")]
		public short? ORIGTYPE  { get; set; }


        [Display(Name = "ORIGNUMB")]
		public string ORIGNUMB  { get; set; }


        [Display(Name = "BACHNUMB")]
		public string BACHNUMB  { get; set; }


        [Display(Name = "CustID")]
		public string CustID  { get; set; }


        [Display(Name = "ShopID")]
		public string ShopID  { get; set; }


        [Display(Name = "EmplID")]
		public string EmplID  { get; set; }


        [Display(Name = "OrderDate")]
		public DateTime? OrderDate  { get; set; }


        [Display(Name = "RequiredDate")]
		public DateTime? RequiredDate  { get; set; }


        [Display(Name = "ShippedDate")]
		public DateTime? ShippedDate  { get; set; }


        [Display(Name = "ShipID")]
		public string ShipID  { get; set; }


        [Display(Name = "Freight")]
		public decimal? Freight  { get; set; }


        [Display(Name = "Ship_Name")]
		public string Ship_Name  { get; set; }


        [Display(Name = "Ship_Address")]
		public string Ship_Address  { get; set; }


        [Display(Name = "Ship_City")]
		public string Ship_City  { get; set; }


        [Display(Name = "TerrID")]
		public string TerrID  { get; set; }


        [Display(Name = "Ship_zip")]
		public string Ship_zip  { get; set; }


        [Display(Name = "Ship_Country")]
		public string Ship_Country  { get; set; }


        [Display(Name = "Ship_state")]
		public string Ship_state  { get; set; }


        [Display(Name = "Ship_phone")]
		public string Ship_phone  { get; set; }


        [Display(Name = "Auth_code")]
		public string Auth_code  { get; set; }


        [Display(Name = "Bill_name")]
		public string Bill_name  { get; set; }


        [Display(Name = "Bill_address")]
		public string Bill_address  { get; set; }


        [Display(Name = "Bill_city")]
		public string Bill_city  { get; set; }


        [Display(Name = "Bill_state")]
		public string Bill_state  { get; set; }


        [Display(Name = "Bill_zip")]
		public string Bill_zip  { get; set; }


        [Display(Name = "Bill_country")]
		public string Bill_country  { get; set; }


        [Display(Name = "Bill_phone")]
		public string Bill_phone  { get; set; }


        [Display(Name = "RepID")]
		public string RepID  { get; set; }


        [Display(Name = "OrderStats")]
		public short? OrderStats  { get; set; }


        [Display(Name = "VoidStats")]
		public short? VoidStats  { get; set; }


        [Display(Name = "CommText")]
		public string CommText  { get; set; }


        [Display(Name = "CretDate")]
		public DateTime? CretDate  { get; set; }


        [Display(Name = "ModiDate")]
		public DateTime? ModiDate  { get; set; }


        [Display(Name = "CretID")]
		public string CretID  { get; set; }


        [Display(Name = "Cc_name")]
		public string Cc_name  { get; set; }


        [Display(Name = "Cc_expmonth")]
		public int? Cc_expmonth  { get; set; }


        [Display(Name = "Cc_expyear")]
		public int? Cc_expyear  { get; set; }


        [Display(Name = "Cc_number")]
		public string Cc_number  { get; set; }


        [Display(Name = "Cc_type")]
		public string Cc_type  { get; set; }


        [Display(Name = "Verify_with")]
		public string Verify_with  { get; set; }


        [Display(Name = "Pono")]
		public string Pono  { get; set; }


        [Display(Name = "Prnstats")]
		public short? Prnstats  { get; set; }


        [Display(Name = "PROC_STATUS")]
		public byte? PROC_STATUS  { get; set; }


        [Display(Name = "Miscellaneous")]
		public decimal? Miscellaneous  { get; set; }

        
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
}

