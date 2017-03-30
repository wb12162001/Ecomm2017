// ===================================================================
// File: EOrderDetailModel.cs
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

namespace Ecomm.Site.Models.InetApp.EOrderDetail
{
    public class EOrderDetailModel : EntityCommon
    {
        public EOrderDetailModel()
        {
            SearchModel = new SearchModel();
        }

        public EOrderDetailModel(int orderId, SALES_EBASKET_RelaModel model)
        {
            SearchModel = new SearchModel();
            OrderID = orderId;
            Sku = model.ProductNo;
            UnitPrice = (decimal)model.UnitPrice;
            Unit = model.Unit;
            UnitCost = (decimal)model.StndCost;
            Skudesc = model.ProductName;
            Orderqty = model.Quantity;
            CretDate = DateTime.Now;
            ModiDate = DateTime.Now;
        }

        [Display(Name = "OrderType")]
		public short? OrderType  { get; set; }


        [Display(Name = "OrderID")]
        [Required(ErrorMessage = "OrderID can not be empty")]
		public int OrderID  { get; set; }


        [Display(Name = "Sn")]
		public string Sn  { get; set; }


        [Display(Name = "Sku")]
        [Required(ErrorMessage = "Sku can not be empty")]
		public string Sku  { get; set; }


        [Display(Name = "Skudesc")]
		public string Skudesc  { get; set; }


        [Display(Name = "WareId")]
		public short? WareId  { get; set; }


        [Display(Name = "Unit")]
		public string Unit  { get; set; }


        [Display(Name = "UnitCost")]
		public decimal? UnitCost  { get; set; }


        [Display(Name = "UnitPrice")]
		public decimal? UnitPrice  { get; set; }


        [Display(Name = "QtyonSales")]
		public double? QtyonSales  { get; set; }


        [Display(Name = "Orderqty")]
		public double? Orderqty  { get; set; }


        [Display(Name = "Bkoqty")]
		public double? Bkoqty  { get; set; }


        [Display(Name = "Fullqty")]
		public double? Fullqty  { get; set; }


        [Display(Name = "Discount")]
		public double? Discount  { get; set; }


        [Display(Name = "Tax")]
		public decimal? Tax  { get; set; }


        [Display(Name = "OrderStats")]
		public string OrderStats  { get; set; }


        [Display(Name = "CommText")]
		public string CommText  { get; set; }


        [Display(Name = "FullDate")]
		public DateTime? FullDate  { get; set; }


        [Display(Name = "CretDate")]
		public DateTime? CretDate  { get; set; }


        [Display(Name = "ModiDate")]
		public DateTime? ModiDate  { get; set; }


        [Display(Name = "CretID")]
		public string CretID  { get; set; }


        [Display(Name = "Class1")]
		public string Class1  { get; set; }

        
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

