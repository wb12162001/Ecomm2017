// ===================================================================
// File: UpdateRela_account_locationModel.cs
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
    public class UpdateRela_account_locationModel : EntityCommon
    {
        public UpdateRela_account_locationModel()
        {
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

    }
    
}

