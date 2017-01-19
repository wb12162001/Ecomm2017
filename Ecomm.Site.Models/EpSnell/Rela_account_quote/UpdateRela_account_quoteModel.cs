// ===================================================================
// File: UpdateRela_account_quoteModel.cs
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

namespace Ecomm.Site.Models.EpSnell.Rela_account_quote
{
    public class UpdateRela_account_quoteModel : EntityCommon
    {
        public UpdateRela_account_quoteModel()
        {
        }

        [Display(Name = "Quote_id")]
        [Required(ErrorMessage = "Quote_id can not be empty")]
		public string Quote_id  { get; set; }


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


        [Display(Name = "Reference")]
		public string Reference  { get; set; }


        [Display(Name = "Cretuser")]
		public string Cretuser  { get; set; }


        [Display(Name = "Cretdate")]
		public DateTime? Cretdate  { get; set; }


        [Display(Name = "Modidate")]
		public DateTime? Modidate  { get; set; }


        [Display(Name = "Modiuser")]
		public string Modiuser  { get; set; }

    }
    
}

