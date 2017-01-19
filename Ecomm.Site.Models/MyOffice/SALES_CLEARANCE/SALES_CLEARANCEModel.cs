// ===================================================================
// File: SALES_CLEARANCEModel.cs
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

namespace Ecomm.Site.Models.MyOffice.SALES_CLEARANCE
{
    public class SALES_CLEARANCEModel : EntityCommon
    {
        public SALES_CLEARANCEModel()
        {
            SearchModel = new SearchModel();
        }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID can not be empty")]
		public string ID  { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name can not be empty")]
		public string Name  { get; set; }


        [Display(Name = "ImgFile")]
		public string ImgFile  { get; set; }


        [Display(Name = "Notes")]
		public string Notes  { get; set; }


        [Display(Name = "SortNo")]
		public string SortNo  { get; set; }


        [Display(Name = "CreateDate")]
		public DateTime? CreateDate  { get; set; }


        [Display(Name = "StartDate")]
		public DateTime? StartDate  { get; set; }


        [Display(Name = "EndDate")]
		public DateTime? EndDate  { get; set; }


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

