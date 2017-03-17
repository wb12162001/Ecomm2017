// ===================================================================
// File: UpdatePROD_RELATEDITEMModel.cs
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

namespace Ecomm.Site.Models.Product.PROD_RELATEDITEM
{
    public class UpdatePROD_RELATEDITEMModel : EntityCommon
    {
        public UpdatePROD_RELATEDITEMModel()
        {
        }

        [Display(Name = "ProductNo")]
        [Required(ErrorMessage = "ProductNo can not be empty")]
		public string ProductNo  { get; set; }


        [Display(Name = "RelatedID")]
        [Required(ErrorMessage = "RelatedID can not be empty")]
		public string RelatedID  { get; set; }


        [Display(Name = "Ranking")]
		public short? Ranking  { get; set; }

    }
    
}

