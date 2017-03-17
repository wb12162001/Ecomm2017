// ===================================================================
// File: PROD_MASTERCOMMONModel.cs
// 2017/2/6: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using Quick.Site.Common.Models;
using System.Web.Mvc;
using Quick.Site.Common;

namespace Ecomm.Site.Models.Product.PROD_MASTERCOMMON
{
    public class PROD_MASTERCOMMONModel : EntityCommon
    {
        public PROD_MASTERCOMMONModel()
        {
            SearchModel = new SearchModel();
        }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID can not be empty")]
		public string ID  { get; set; }


        [Display(Name = "ProductNo")]
        [Required(ErrorMessage = "ProductNo can not be empty")]
		public string ProductNo  { get; set; }


        [Display(Name = "CommTitle")]
        [Required(ErrorMessage = "CommTitle can not be empty")]
		public string CommTitle  { get; set; }


        [Display(Name = "CommSummary")]
		public string CommSummary  { get; set; }


        [Display(Name = "CommContent")]
        [Required(ErrorMessage = "CommContent can not be empty")]
		public string CommContent  { get; set; }


        [Display(Name = "Creator")]
		public string Creator  { get; set; }


        [Display(Name = "CreateDate")]
		public DateTime? CreateDate  { get; set; }


        [Display(Name = "Modifier")]
		public string Modifier  { get; set; }


        [Display(Name = "ModiDate")]
		public DateTime? ModiDate  { get; set; }


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

