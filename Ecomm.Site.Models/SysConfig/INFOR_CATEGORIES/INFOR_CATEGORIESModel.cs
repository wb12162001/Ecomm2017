// ===================================================================
// File: INFOR_CATEGORIESModel.cs
// 2017/1/5: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using Quick.Site.Common.Models;
using System.Web.Mvc;
using Quick.Site.Common;
using Ecomm.Site.Models.AdminCommon;

namespace Ecomm.Site.Models.SysConfig.INFOR_CATEGORIES
{
    public class INFOR_CATEGORIESModel : EntityCommon
    {
        public INFOR_CATEGORIESModel()
        {
            SearchModel = new SearchModel();
            ParentCategies = new List<SelectListItem>();
            StatusModel = new StatusModel();
        }

        [Display(Name = "ID")]
		public string ID  { get; set; }


        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Category Name can not be empty")]
		public string InforCategoryName  { get; set; }


        [Display(Name = "DisplayOrder")]
		public int? DisplayOrder  { get; set; }


        [Display(Name = "ParentID")]
		public string ParentID  { get; set; }

        [Display(Name = "Parent Name")]
        public string ParentName { get; set; }


        [Display(Name = "Clevel")]
		public int? Clevel  { get; set; }


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

        
        public SearchModel SearchModel { get; set; }

        public List<SelectListItem> ParentCategies { get; set; }

        public StatusModel StatusModel { get; set; }

    }
    
    public class SearchModel
    {
        public SearchModel()
        {
            EnabledItems = new List<SelectListItem> { 
                new SelectListItem { Text = "--- Please select ---", Value = "", Selected = true }, 
                new SelectListItem { Text = "Disable", Value = "1" }, 
                new SelectListItem { Text = "Enable", Value = "0" }
            };
        }

        [Display(Name = "Category Name")]
        public string InforCategoryName { get; set; }


        [Display(Name = "Status")]
        public int? Enabled { get; set; }

        public List<SelectListItem> EnabledItems { get; set; }
    }
}

