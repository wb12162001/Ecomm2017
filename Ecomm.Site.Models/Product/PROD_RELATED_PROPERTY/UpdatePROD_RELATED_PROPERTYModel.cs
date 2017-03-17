// ===================================================================
// File: UpdatePROD_RELATED_PROPERTYModel.cs
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

namespace Ecomm.Site.Models.Product.PROD_RELATED_PROPERTY
{
    public class UpdatePROD_RELATED_PROPERTYModel : EntityCommon
    {
        public UpdatePROD_RELATED_PROPERTYModel()
        {
        }

        [Display(Name = "ProductNo")]
        [Required(ErrorMessage = "ProductNo can not be empty")]
		public string ProductNo  { get; set; }


        [Display(Name = "PropertyID")]
        [Required(ErrorMessage = "PropertyID can not be empty")]
		public string PropertyID  { get; set; }


        [Display(Name = "CLevel")]
        [Required(ErrorMessage = "CLevel can not be empty")]
		public int CLevel  { get; set; }

    }
    
}

