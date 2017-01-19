// ===================================================================
// File: UpdateRela_accountModel.cs
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

namespace Ecomm.Site.Models.EpSnell.Rela_account
{
    public class UpdateRela_accountModel : EntityCommon
    {
        public UpdateRela_accountModel()
        {
        }

        [Display(Name = "Id")]
        [Required(ErrorMessage = "Id can not be empty")]
		public string Id  { get; set; }


        [Display(Name = "Account_type")]
		public string Account_type  { get; set; }


        [Display(Name = "Account_no")]
		public string Account_no  { get; set; }


        [Display(Name = "Pid")]
		public string Pid  { get; set; }


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


        [Display(Name = "Territory_id")]
		public string Territory_id  { get; set; }


        [Display(Name = "Region_id")]
		public string Region_id  { get; set; }


        [Display(Name = "Rating")]
		public string Rating  { get; set; }


        [Display(Name = "Employees")]
		public string Employees  { get; set; }


        [Display(Name = "Industry")]
		public string Industry  { get; set; }


        [Display(Name = "Ownership")]
		public string Ownership  { get; set; }


        [Display(Name = "Onhold")]
		public string Onhold  { get; set; }


        [Display(Name = "Payment_term")]
		public string Payment_term  { get; set; }


        [Display(Name = "Currency_id")]
		public string Currency_id  { get; set; }


        [Display(Name = "Revenue")]
		public string Revenue  { get; set; }


        [Display(Name = "Ticker_symbol")]
		public string Ticker_symbol  { get; set; }


        [Display(Name = "Sic_code")]
		public string Sic_code  { get; set; }


        [Display(Name = "Isort")]
		public string Isort  { get; set; }


        [Display(Name = "Pic_s")]
		public string Pic_s  { get; set; }


        [Display(Name = "Pic_b")]
		public string Pic_b  { get; set; }


        [Display(Name = "Detail")]
		public string Detail  { get; set; }


        [Display(Name = "Rep_id")]
		public string Rep_id  { get; set; }


        [Display(Name = "Open_date")]
		public DateTime? Open_date  { get; set; }


        [Display(Name = "Ship_method")]
		public string Ship_method  { get; set; }


        [Display(Name = "Account_class")]
		public string Account_class  { get; set; }


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


        [Display(Name = "MinOrderValue")]
		public decimal? MinOrderValue  { get; set; }


        [Display(Name = "MinOrderSize")]
		public decimal? MinOrderSize  { get; set; }


        [Display(Name = "MinOrderFreight")]
		public decimal? MinOrderFreight  { get; set; }


        [Display(Name = "MinOrderMisc")]
		public decimal? MinOrderMisc  { get; set; }


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


        [Display(Name = "Isprivate")]
		public byte? Isprivate  { get; set; }


        [Display(Name = "Owner")]
		public string Owner  { get; set; }


        [Display(Name = "Rn_id")]
		public byte[] Rn_id  { get; set; }


        [Display(Name = "EcomRecommend")]
		public byte? EcomRecommend  { get; set; }

    }
    
}

