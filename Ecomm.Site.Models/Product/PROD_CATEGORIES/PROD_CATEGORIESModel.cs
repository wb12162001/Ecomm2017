// ===================================================================
// File: PROD_CATEGORIESModel.cs
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

namespace Ecomm.Site.Models.Product.PROD_CATEGORIES
{
    public class MenuViewModel
    {
        public IEnumerable<PROD_CATEGORIESModel> Menus { get; set; }

        public int ItemCount { get; set; }

        public PROD_CATEGORIESModel Category { get; set; }

    }
    public class PROD_CATEGORIESModel : EntityCommon
    {
        public PROD_CATEGORIESModel()
        {
            SearchModel = new SearchModel();
        }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID can not be empty")]
		public string ID  { get; set; }


        [Display(Name = "CategoryName")]
        [Required(ErrorMessage = "CategoryName can not be empty")]
		public string CategoryName  { get; set; }


        [Display(Name = "CategoryCode")]
        [Required(ErrorMessage = "CategoryCode can not be empty")]
		public string CategoryCode  { get; set; }


        [Display(Name = "Description")]
		public string Description  { get; set; }


        [Display(Name = "ParentID")]
		public string ParentID  { get; set; }

        public string ParentCategoryName { get; set; }


        [Display(Name = "ColorBg")]
		public string ColorBg  { get; set; }


        [Display(Name = "ColorText")]
		public string ColorText  { get; set; }


        [Display(Name = "Picture")]
		public string Picture  { get; set; }


        [Display(Name = "SmallPic")]
		public string SmallPic  { get; set; }


        [Display(Name = "BigPic")]
		public string BigPic  { get; set; }


        [Display(Name = "CLevel")]
		public int? CLevel  { get; set; }


        [Display(Name = "DisplayOrder")]
		public int? DisplayOrder  { get; set; }


        [Display(Name = "Creator")]
		public string Creator  { get; set; }


        [Display(Name = "Modifier")]
		public string Modifier  { get; set; }


        [Display(Name = "CreateDate")]
		public DateTime? CreateDate  { get; set; }


        [Display(Name = "Modidate")]
		public DateTime? Modidate  { get; set; }


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


        [Display(Name = "MenuAlias")]
		public string MenuAlias  { get; set; }


        [Display(Name = "IsAvailably")]
		public bool IsAvailably  { get; set; }

        
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

