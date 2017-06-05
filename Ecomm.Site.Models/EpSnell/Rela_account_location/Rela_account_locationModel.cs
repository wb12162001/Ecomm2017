// ===================================================================
// File: Rela_account_locationModel.cs
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

namespace Ecomm.Site.Models.EpSnell.Rela_account_location
{
    public class Rela_account_locationModel : EntityCommon
    {
        public Rela_account_locationModel()
        {
            SearchModel = new SearchModel();
        }

        [Display(Name = "Account_no")]
        [Required(ErrorMessage = "Account_no can not be empty")]
		public string Account_no  { get; set; }


        [Display(Name = "Address_id")]
        [Required(ErrorMessage = "Address_id can not be empty")]
		public string Address_id  { get; set; }


        [Display(Name = "Name")]
		public string Name  { get; set; }


        [Display(Name = "Description")]
		public string Description  { get; set; }


        [Display(Name = "Contact_id")]
		public string Contact_id  { get; set; }


        [Display(Name = "Address1")]
		public string Address1  { get; set; }


        [Display(Name = "Address2")]
		public string Address2  { get; set; }


        [Display(Name = "City")]
		public string City  { get; set; }


        [Display(Name = "State")]
		public string State  { get; set; }


        [Display(Name = "Country")]
		public string Country  { get; set; }


        [Display(Name = "Zip")]
		public string Zip  { get; set; }


        [Display(Name = "P_address1")]
		public string P_address1  { get; set; }


        [Display(Name = "P_address2")]
		public string P_address2  { get; set; }


        [Display(Name = "P_city")]
		public string P_city  { get; set; }


        [Display(Name = "P_state")]
		public string P_state  { get; set; }


        [Display(Name = "P_country")]
		public string P_country  { get; set; }


        [Display(Name = "P_zip")]
		public string P_zip  { get; set; }


        [Display(Name = "Phone1")]
		public string Phone1  { get; set; }


        [Display(Name = "Phone2")]
		public string Phone2  { get; set; }


        [Display(Name = "Fax")]
		public string Fax  { get; set; }


        [Display(Name = "Email")]
		public string Email  { get; set; }


        [Display(Name = "Www")]
		public string Www  { get; set; }


        [Display(Name = "Isort")]
		public string Isort  { get; set; }


        [Display(Name = "Pic_s")]
		public string Pic_s  { get; set; }


        [Display(Name = "Pic_b")]
		public string Pic_b  { get; set; }


        [Display(Name = "Detail")]
		public string Detail  { get; set; }


        [Display(Name = "Status")]
		public byte? Status  { get; set; }


        [Display(Name = "Cretuser")]
		public string Cretuser  { get; set; }


        [Display(Name = "Cretdate")]
		public DateTime? Cretdate  { get; set; }


        [Display(Name = "Modidate")]
		public DateTime? Modidate  { get; set; }


        [Display(Name = "Modiuser")]
		public string Modiuser  { get; set; }


        [Display(Name = "Row_id")]
        [Required(ErrorMessage = "Row_id can not be empty")]
		public int Row_id  { get; set; }

        
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

    public class Rela_account_location_shiptoModel
    {
        public string address1 { get; set; }

        public string address2 { get; set; }
        public string address_id { get; set; }
        public string description { get; set; }

        public string contact_id { get; set; }

        public int isSel { get; set; }

    }
}

