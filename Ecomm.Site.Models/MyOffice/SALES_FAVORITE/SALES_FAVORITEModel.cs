// ===================================================================
// File: SALES_FAVORITEModel.cs
// 2017/1/17: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using Quick.Site.Common.Models;
using System.Web.Mvc;
using Quick.Site.Common;

namespace Ecomm.Site.Models.MyOffice.SALES_FAVORITE
{
    public class SALES_FAVORITEModel : EntityCommon
    {
        public SALES_FAVORITEModel()
        {
            SearchModel = new SearchModel();
        }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID can not be empty")]
		public string ID  { get; set; }


        [Display(Name = "FavFolderID")]
		public string FavFolderID  { get; set; }


        [Display(Name = "ProductNo")]
        [Required(ErrorMessage = "ProductNo can not be empty")]
		public string ProductNo  { get; set; }


        [Display(Name = "CustomerID")]
        [Required(ErrorMessage = "CustomerID can not be empty")]
		public string CustomerID  { get; set; }


        [Display(Name = "ContactID")]
        [Required(ErrorMessage = "ContactID can not be empty")]
		public string ContactID  { get; set; }


        [Display(Name = "CreateDate")]
		public DateTime? CreateDate  { get; set; }


        [Display(Name = "ModiDate")]
		public DateTime? ModiDate  { get; set; }


        [Display(Name = "Creator")]
		public string Creator  { get; set; }


        [Display(Name = "Modifier")]
		public string Modifier  { get; set; }


        [Display(Name = "Status")]
		public int? Status  { get; set; }

        
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

