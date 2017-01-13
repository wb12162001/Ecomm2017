// ===================================================================
// File: UpdateSYS_DICTIONARYModel.cs
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

namespace Ecomm.Site.Models.SysConfig.SYS_DICTIONARY
{
    public class UpdateSYS_DICTIONARYModel : EntityCommon
    {
        public UpdateSYS_DICTIONARYModel()
        {
        }

        [Display(Name = "DictionaryName")]
        [Required(ErrorMessage = "DictionaryName can not be empty")]
		public string DictionaryName  { get; set; }


        [Display(Name = "DictionaryValue")]
        [Required(ErrorMessage = "DictionaryValue can not be empty")]
		public int DictionaryValue  { get; set; }


        [Display(Name = "Remark")]
		public string Remark  { get; set; }

    }
    
}

