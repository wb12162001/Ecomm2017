// ===================================================================
// File: INFOR_MASTERModel.cs
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

namespace Ecomm.Site.Models.SysConfig.INFOR_MASTER
{
    public class INFOR_MASTERModel : EntityCommon
    {
        public INFOR_MASTERModel()
        {
            SearchModel = new SearchModel();
            TargetModel = new TargetModel();
            StatusModel = new StatusModel();

            Categrouies = new List<SelectListItem> {
                new SelectListItem { Text = "--- Please select ---", Value = "" },
            };
        }

        [Display(Name = "ID")]
		public string ID  { get; set; }


        [Display(Name = "InforSubject")]
        [Required(ErrorMessage = "InforSubject can not be empty")]
		public string InforSubject  { get; set; }


        [Display(Name = "InforCategoryID")]
		public string InforCategoryID  { get; set; }
        [Display(Name = "CategoryName")]
        public string InforCategoryName { get; set; }


        [Display(Name = "Introduction")]
		public string Introduction  { get; set; }


        [Display(Name = "Author")]
		public string Author  { get; set; }


        [Display(Name = "ViewTimes")]
		public int? ViewTimes  { get; set; }


        [Display(Name = "Description")]
		public string Description  { get; set; }


        [Display(Name = "Creator")]
		public string Creator  { get; set; }


        [Display(Name = "CreateDate")]
		public DateTime? CreateDate  { get; set; }


        [Display(Name = "Modifier")]
		public string Modifier  { get; set; }


        [Display(Name = "ModiDate")]
		public DateTime? ModiDate  { get; set; }


        [Display(Name = "DisplayOrder")]
		public int? DisplayOrder  { get; set; }


        [Display(Name = "Status")]
		public int? Status  { get; set; }


        [Display(Name = "HomePagePic")]
		public string Item01  { get; set; }


        [Display(Name = "Item02")]
		public string Item02  { get; set; }


        [Display(Name = "Item03")]
		public string Item03  { get; set; }


        [Display(Name = "Item04")]
		public string Item04  { get; set; }


        [Display(Name = "Item05")]
		public string Item05  { get; set; }


        [Display(Name = "IsOuterLink")]
		public bool IsOuterLink  { get; set; }


        [Display(Name = "ActiveLink")]
		public string ActiveLink  { get; set; }


        [Display(Name = "Target")]
		public string Target  { get; set; }


        [Display(Name = "LinkTitle")]
		public string LinkTitle  { get; set; }


        [Display(Name = "LinkText")]
		public string LinkText  { get; set; }


        [Display(Name = "LinkStyle")]
		public string LinkStyle  { get; set; }


        [Display(Name = "ParentID")]
		public string ParentID  { get; set; }

        
        public SearchModel SearchModel { get; set; }

        public List<SelectListItem> Categrouies { get; set; }

        public StatusModel StatusModel { get; set; }

        public TargetModel TargetModel { get; set; }
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
            Categrouies = new List<SelectListItem>();
        }

        [Display(Name = "Subject")]
        public string Subject { get; set; }


        [Display(Name = "Status")]
        public int? Enabled { get; set; }

        public List<SelectListItem> EnabledItems { get; set; }

        [Display(Name = "Category")]
        public string InforCategoryID { get; set; }

        public List<SelectListItem> Categrouies { get; set; }
    }

    public class INFOR_CATE_Model
    {
        public string ID { get; set; }

        public string InforSubject { get; set; }

        public string ActiveLink { get; set; }

        public string Target { get; set; }

        public string Type { get; set; }
    }
}

