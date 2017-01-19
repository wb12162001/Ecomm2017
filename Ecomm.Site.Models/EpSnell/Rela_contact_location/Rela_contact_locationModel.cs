// ===================================================================
// File: Rela_contact_locationModel.cs
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

namespace Ecomm.Site.Models.EpSnell.Rela_contact_location
{
    public class Rela_contact_locationModel : EntityCommon
    {
        public Rela_contact_locationModel()
        {
            SearchModel = new SearchModel();
        }

        [Display(Name = "Account_no")]
        [Required(ErrorMessage = "Account_no can not be empty")]
		public string Account_no  { get; set; }


        [Display(Name = "Contact_id")]
        [Required(ErrorMessage = "Contact_id can not be empty")]
		public string Contact_id  { get; set; }


        [Display(Name = "Address_no")]
        [Required(ErrorMessage = "Address_no can not be empty")]
		public string Address_no  { get; set; }


        [Display(Name = "Cretdate")]
		public DateTime? Cretdate  { get; set; }


        [Display(Name = "Modidate")]
		public DateTime? Modidate  { get; set; }


        [Display(Name = "Cretuser")]
		public string Cretuser  { get; set; }


        [Display(Name = "Modiuser")]
		public string Modiuser  { get; set; }


        [Display(Name = "Display_order")]
		public int? Display_order  { get; set; }


        [Display(Name = "Row_id")]
        [Required(ErrorMessage = "Row_id can not be empty")]
		public int Row_id  { get; set; }


        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status can not be empty")]
		public byte Status  { get; set; }


        [Display(Name = "Item1")]
		public string Item1  { get; set; }


        [Display(Name = "Item2")]
		public string Item2  { get; set; }


        [Display(Name = "Item3")]
		public string Item3  { get; set; }


        [Display(Name = "Item4")]
		public string Item4  { get; set; }


        [Display(Name = "Item5")]
		public string Item5  { get; set; }


        [Display(Name = "Item6")]
		public string Item6  { get; set; }

        
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

