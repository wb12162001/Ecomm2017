// ===================================================================
// File: UpdateRela_account_contractpriceModel.cs
// 2017/1/16: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using Quick.Site.Common.Models;
using System.Web.Mvc;
using Quick.Site.Common;

namespace Ecomm.Site.Models.EpSnell.Rela_account_contractprice
{
    public class UpdateRela_account_contractpriceModel : EntityCommon
    {
        public UpdateRela_account_contractpriceModel()
        {
        }

        [Display(Name = "Account_no")]
        [Required(ErrorMessage = "Account_no can not be empty")]
		public string Account_no  { get; set; }


        [Display(Name = "Item_no")]
        [Required(ErrorMessage = "Item_no can not be empty")]
		public string Item_no  { get; set; }


        [Display(Name = "Price")]
		public double? Price  { get; set; }


        [Display(Name = "Cost")]
		public double? Cost  { get; set; }


        [Display(Name = "Gp")]
		public double? Gp  { get; set; }


        [Display(Name = "Unit")]
		public string Unit  { get; set; }


        [Display(Name = "Status")]
		public byte? Status  { get; set; }


        [Display(Name = "Account_type")]
		public string Account_type  { get; set; }


        [Display(Name = "Cretuser")]
		public string Cretuser  { get; set; }


        [Display(Name = "Cretdate")]
		public DateTime? Cretdate  { get; set; }


        [Display(Name = "Modidate")]
		public DateTime? Modidate  { get; set; }


        [Display(Name = "Modiuser")]
		public string Modiuser  { get; set; }


        [Display(Name = "Start_date")]
		public DateTime? Start_date  { get; set; }


        [Display(Name = "End_date")]
		public DateTime? End_date  { get; set; }

    }
    
}

