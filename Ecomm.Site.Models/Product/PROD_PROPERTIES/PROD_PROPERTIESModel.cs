// ===================================================================
// File: PROD_PROPERTIESModel.cs
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

namespace Ecomm.Site.Models.Product.PROD_PROPERTIES
{
    public class PROD_PROPERTIESModel : EntityCommon
    {
        public PROD_PROPERTIESModel()
        {
            SearchModel = new SearchModel();
        }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID can not be empty")]
		public string ID  { get; set; }


        [Display(Name = "ProductNo")]
        [Required(ErrorMessage = "ProductNo can not be empty")]
		public string ProductNo  { get; set; }


        [Display(Name = "PropertyID")]
        [Required(ErrorMessage = "PropertyID can not be empty")]
		public string PropertyID  { get; set; }


        [Display(Name = "PropertyValue")]
		public string PropertyValue  { get; set; }


        [Display(Name = "PLevel")]
		public int? PLevel  { get; set; }


        [Display(Name = "ParentID")]
		public string ParentID  { get; set; }


        [Display(Name = "RelationCode")]
		public string RelationCode  { get; set; }


        [Display(Name = "RowID")]
        [Required(ErrorMessage = "RowID can not be empty")]
		public int RowID  { get; set; }


        [Display(Name = "RealProductNo")]
		public string RealProductNo  { get; set; }


        [Display(Name = "DisplayOrder")]
		public int? DisplayOrder  { get; set; }


        [Display(Name = "Remark")]
		public string Remark  { get; set; }


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

