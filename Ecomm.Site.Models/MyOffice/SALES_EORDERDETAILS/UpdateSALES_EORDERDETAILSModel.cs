// ===================================================================
// File: UpdateSALES_EORDERDETAILSModel.cs
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

namespace Ecomm.Site.Models.MyOffice.SALES_EORDERDETAILS
{
    public class UpdateSALES_EORDERDETAILSModel : EntityCommon
    {
        public UpdateSALES_EORDERDETAILSModel()
        {
        }

        [Display(Name = "OrderID")]
        [Required(ErrorMessage = "OrderID can not be empty")]
		public string OrderID  { get; set; }


        [Display(Name = "ProductNo")]
        [Required(ErrorMessage = "ProductNo can not be empty")]
		public string ProductNo  { get; set; }


        [Display(Name = "OrderQty")]
		public double? OrderQty  { get; set; }


        [Display(Name = "Unit")]
		public string Unit  { get; set; }


        [Display(Name = "UnitCost")]
		public double? UnitCost  { get; set; }


        [Display(Name = "UnitPrice")]
		public double? UnitPrice  { get; set; }


        [Display(Name = "Tax")]
		public double? Tax  { get; set; }


        [Display(Name = "Freight")]
		public double? Freight  { get; set; }


        [Display(Name = "CommText")]
		public string CommText  { get; set; }


        [Display(Name = "Creator")]
		public string Creator  { get; set; }


        [Display(Name = "Modifier")]
		public string Modifier  { get; set; }


        [Display(Name = "ModiDate")]
		public DateTime? ModiDate  { get; set; }


        [Display(Name = "CreateDate")]
		public DateTime? CreateDate  { get; set; }


        [Display(Name = "RowID")]
        [Required(ErrorMessage = "RowID can not be empty")]
		public int RowID  { get; set; }


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


        [Display(Name = "UnitPType")]
		public string UnitPType  { get; set; }

    }
    
}

