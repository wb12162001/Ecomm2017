// ===================================================================
// File: PROD_PHOTOModel.cs
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

namespace Ecomm.Site.Models.Product.PROD_PHOTO
{
    public class PROD_PHOTOModel : EntityCommon
    {
        public PROD_PHOTOModel()
        {
            SearchModel = new SearchModel();
        }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID can not be empty")]
		public string ID  { get; set; }


        [Display(Name = "PhotoTitle")]
        [Required(ErrorMessage = "PhotoTitle can not be empty")]
		public string PhotoTitle  { get; set; }


        [Display(Name = "FilePath")]
		public string FilePath  { get; set; }


        [Display(Name = "IsDefault")]
		public int? IsDefault  { get; set; }


        [Display(Name = "PhotoType")]
		public int? PhotoType  { get; set; }


        [Display(Name = "EntityID")]
		public string EntityID  { get; set; }


        [Display(Name = "SmallPic")]
		public string SmallPic  { get; set; }


        [Display(Name = "BigPic")]
		public string BigPic  { get; set; }


        [Display(Name = "MiddlePic")]
		public string MiddlePic  { get; set; }


        [Display(Name = "CreateDate")]
		public DateTime? CreateDate  { get; set; }


        [Display(Name = "ModiDate")]
		public DateTime? ModiDate  { get; set; }


        [Display(Name = "Creator")]
		public string Creator  { get; set; }


        [Display(Name = "Modifier")]
		public string Modifier  { get; set; }


        [Display(Name = "DisplayOrder")]
		public int? DisplayOrder  { get; set; }


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

