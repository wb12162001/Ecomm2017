// ===================================================================
// File: PROD_GROUP_ITEMModel.cs
// 2016/12/28: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using Quick.Site.Common.Models;
using System.Web.Mvc;
using Quick.Site.Common;

namespace Ecomm.Site.Models.Product.PROD_GROUP_ITEM
{
    public class PROD_GROUP_ITEMModel : EntityCommon
    {
        public PROD_GROUP_ITEMModel()
        {
            SearchModel = new SearchModel();
            Groups = new List<SelectListItem>() {
                new SelectListItem { Text = "--- Root ---", Value = ""},
            };
            Products = new List<SelectListItem>() {
                new SelectListItem { Text = "--- Root ---", Value = ""},
            };
        }

        [Display(Name = "ProductID")]
        [Required(ErrorMessage = "ProductID can not be empty")]
		public string ProductID  { get; set; }

        [Display(Name = "Product")]
        public string ProductName { get; set; }
        public List<SelectListItem> Products { get; set; }


        [Display(Name = "GROUP_INDEX")]
        [Required(ErrorMessage = "GROUP_INDEX can not be empty")]
		public string GROUP_INDEX  { get; set; }

        [Display(Name = "Group")]
        public string GroupName { get; set; }
        public List<SelectListItem> Groups { get; set; }


        [Display(Name = "Notes")]
        [Required(ErrorMessage = "Notes can not be empty")]
		public string Notes  { get; set; }


        [Display(Name = "Picture")]
		public string Picture  { get; set; }


        [Display(Name = "IsActivate")]
        public bool Status  { get; set; }

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

