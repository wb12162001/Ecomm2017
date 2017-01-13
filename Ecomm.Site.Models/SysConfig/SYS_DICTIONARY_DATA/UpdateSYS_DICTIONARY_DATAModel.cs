// ===================================================================
// File: UpdateSYS_DICTIONARY_DATAModel.cs
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
    public class UpdateSYS_DICTIONARY_DATAModel : EntityCommon
    {
        public UpdateSYS_DICTIONARY_DATAModel()
        {
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

    }
    
}

