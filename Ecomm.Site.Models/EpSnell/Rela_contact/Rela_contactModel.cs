// ===================================================================
// File: Rela_contactModel.cs
// 2017/1/3: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using Quick.Site.Common.Models;
using System.Web.Mvc;
using Quick.Site.Common;

namespace Ecomm.Site.Models.EpSnell.Rela_contact
{
    public class Rela_contactModel : EntityCommon
    {
        public Rela_contactModel()
        {
            SearchModel = new SearchModel();
        }

        [Display(Name = "Id")]
        [Required(ErrorMessage = "Id can not be empty")]
		public string Id  { get; set; }


        [Display(Name = "Name")]
		public string Name  { get; set; }


        [Display(Name = "Title")]
		public string Title  { get; set; }


        [Display(Name = "Job_title")]
		public string Job_title  { get; set; }


        [Display(Name = "Fname")]
		public string Fname  { get; set; }


        [Display(Name = "Lname")]
		public string Lname  { get; set; }


        [Display(Name = "Mname")]
		public string Mname  { get; set; }


        [Display(Name = "Gender")]
		public string Gender  { get; set; }


        [Display(Name = "Account_id")]
		public string Account_id  { get; set; }


        [Display(Name = "Iskey")]
		public byte? Iskey  { get; set; }


        [Display(Name = "Description")]
		public string Description  { get; set; }


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


        [Display(Name = "Territory_id")]
		public string Territory_id  { get; set; }


        [Display(Name = "Home_phone")]
		public string Home_phone  { get; set; }


        [Display(Name = "Mobile")]
		public string Mobile  { get; set; }


        [Display(Name = "Department")]
		public string Department  { get; set; }


        [Display(Name = "Birthday")]
		public DateTime? Birthday  { get; set; }


        [Display(Name = "Assistant")]
		public string Assistant  { get; set; }


        [Display(Name = "Assistant_phone")]
		public string Assistant_phone  { get; set; }


        [Display(Name = "Report_to")]
		public string Report_to  { get; set; }


        [Display(Name = "Lead_source")]
		public string Lead_source  { get; set; }


        [Display(Name = "Personal_details")]
		public string Personal_details  { get; set; }


        [Display(Name = "Background")]
		public string Background  { get; set; }


        [Display(Name = "Family")]
		public string Family  { get; set; }


        [Display(Name = "Qualifications")]
		public string Qualifications  { get; set; }


        [Display(Name = "Memberships")]
		public string Memberships  { get; set; }


        [Display(Name = "Projects")]
		public string Projects  { get; set; }


        [Display(Name = "Interests")]
		public string Interests  { get; set; }


        [Display(Name = "Quote")]
		public string Quote  { get; set; }


        [Display(Name = "Skills")]
		public string Skills  { get; set; }


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


        [Display(Name = "Isprivate")]
		public byte? Isprivate  { get; set; }


        [Display(Name = "Owner")]
		public string Owner  { get; set; }


        [Display(Name = "Rn_id")]
		public byte[] Rn_id  { get; set; }


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


        [Display(Name = "Class1")]
		public string Class1  { get; set; }


        [Display(Name = "Class2")]
		public string Class2  { get; set; }


        [Display(Name = "Class3")]
		public string Class3  { get; set; }


        [Display(Name = "Class4")]
		public string Class4  { get; set; }


        [Display(Name = "Class5")]
		public string Class5  { get; set; }


        [Display(Name = "Class6")]
		public string Class6  { get; set; }


        [Display(Name = "IsManager")]
		public bool? IsManager  { get; set; }


        [Display(Name = "UserName")]
		public string UserName  { get; set; }


        [Display(Name = "Password")]
		public string Password  { get; set; }


        [Display(Name = "QtyLimit")]
		public double? QtyLimit  { get; set; }


        [Display(Name = "AmountLimit")]
		public double? AmountLimit  { get; set; }


        [Display(Name = "ItemQtyLimit")]
		public double? ItemQtyLimit  { get; set; }


        [Display(Name = "ItemAmountLimit")]
		public double? ItemAmountLimit  { get; set; }


        [Display(Name = "AccountRole")]
		public string AccountRole  { get; set; }


        [Display(Name = "IsContractLimit")]
		public bool? IsContractLimit  { get; set; }


        [Display(Name = "HomePage")]
		public string HomePage  { get; set; }


        [Display(Name = "Report_To_Email")]
		public string Report_To_Email  { get; set; }

        
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

