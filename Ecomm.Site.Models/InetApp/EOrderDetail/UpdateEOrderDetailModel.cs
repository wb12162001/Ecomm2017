// ===================================================================
// File: UpdateEOrderDetailModel.cs
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

namespace Ecomm.Site.Models.InetApp.EOrderDetail
{
    public class UpdateEOrderDetailModel : EntityCommon
    {
        public UpdateEOrderDetailModel()
        {
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

    }
    
}

