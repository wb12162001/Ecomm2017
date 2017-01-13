// ===================================================================
// File: UpdateSYS_PROPERTYModel.cs
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

namespace Ecomm.Site.Models.SysConfig.SYS_PROPERTY
{
    public class UpdateSYS_PROPERTYModel : EntityCommon
    {
        public UpdateSYS_PROPERTYModel()
        {
        }

        [Display(Name = "PropertyID")]
        [Required(ErrorMessage = "PropertyID can not be empty")]
		public string PropertyID  { get; set; }


        [Display(Name = "PropertyName")]
        [Required(ErrorMessage = "PropertyName can not be empty")]
		public string PropertyName  { get; set; }


        [Display(Name = "Remark")]
		public string Remark  { get; set; }


        [Display(Name = "Status")]
		public int? Status  { get; set; }

    }
    
}

