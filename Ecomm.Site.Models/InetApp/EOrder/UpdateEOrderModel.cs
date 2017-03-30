// ===================================================================
// File: UpdateEOrderModel.cs
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

namespace Ecomm.Site.Models.InetApp.EOrder
{
    public class UpdateEOrderModel : EntityCommon
    {
        public UpdateEOrderModel()
        {
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

    }
    
}

