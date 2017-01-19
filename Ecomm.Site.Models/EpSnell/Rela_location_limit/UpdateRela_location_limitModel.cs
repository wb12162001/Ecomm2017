// ===================================================================
// File: UpdateRela_location_limitModel.cs
// 2017/1/16: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using Quick.Site.Common.Models;
using System.Web.Mvc;
using Quick.Site.Common;

namespace Ecomm.Site.Models.EpSnell.Rela_location_limit
{
    public class UpdateRela_location_limitModel : EntityCommon
    {
        public UpdateRela_location_limitModel()
        {
        }

        [Display(Name = "Account_no")]
        [Required(ErrorMessage = "Account_no can not be empty")]
		public string Account_no  { get; set; }


        [Display(Name = "Address_id")]
        [Required(ErrorMessage = "Address_id can not be empty")]
		public string Address_id  { get; set; }


        [Display(Name = "Month_quota")]
		public double? Month_quota  { get; set; }


        [Display(Name = "Month_sales")]
		public double? Month_sales  { get; set; }

    }
    
}

