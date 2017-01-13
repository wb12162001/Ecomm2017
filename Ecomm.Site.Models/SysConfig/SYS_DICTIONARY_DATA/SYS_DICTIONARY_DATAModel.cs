// ===================================================================
// File: SYS_DICTIONARY_DATAModel.cs
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

namespace Ecomm.Site.Models.SysConfig.SYS_DICTIONARY_DATA
{
    public class SYS_DICTIONARY_DATAModel : EntityCommon
    {
        public SYS_DICTIONARY_DATAModel()
        {
            SearchModel = new SearchModel();
        }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID can not be empty")]
		public string ID  { get; set; }


        [Display(Name = "DictionaryValue")]
        [Required(ErrorMessage = "DictionaryValue can not be empty")]
		public int DictionaryValue  { get; set; }


        [Display(Name = "DictDataName")]
        [Required(ErrorMessage = "DictDataName can not be empty")]
		public string DictDataName  { get; set; }


        [Display(Name = "DictDataValue")]
        [Required(ErrorMessage = "DictDataValue can not be empty")]
		public string DictDataValue  { get; set; }


        [Display(Name = "DictDataType")]
		public string DictDataType  { get; set; }


        [Display(Name = "IsFixed")]
		public bool IsFixed  { get; set; }


        [Display(Name = "IsCancel")]
		public bool IsCancel  { get; set; }


        [Display(Name = "DictParentID")]
		public string DictParentID  { get; set; }


        [Display(Name = "CreateDate")]
		public DateTime? CreateDate  { get; set; }


        [Display(Name = "ModiDate")]
		public DateTime? ModiDate  { get; set; }


        [Display(Name = "Remark")]
		public string Remark  { get; set; }


        [Display(Name = "DisplayOrder")]
		public int? DisplayOrder  { get; set; }

        
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

