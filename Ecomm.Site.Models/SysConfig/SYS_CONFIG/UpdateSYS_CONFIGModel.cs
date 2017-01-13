// ===================================================================
// File: UpdateSYS_CONFIGModel.cs
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

namespace Ecomm.Site.Models.SysConfig.SYS_CONFIG
{
    public class UpdateSYS_CONFIGModel : EntityCommon
    {
        public UpdateSYS_CONFIGModel()
        {
        }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID can not be empty")]
		public string ID  { get; set; }


        [Display(Name = "ConfigName")]
        [Required(ErrorMessage = "ConfigName can not be empty")]
		public string ConfigName  { get; set; }


        [Display(Name = "ConfigContent")]
        [Required(ErrorMessage = "ConfigContent can not be empty")]
		public string ConfigContent  { get; set; }


        [Display(Name = "FieldProperty")]
		public string FieldProperty  { get; set; }


        [Display(Name = "IsSystem")]
		public bool IsSystem  { get; set; }

    }
    
}

