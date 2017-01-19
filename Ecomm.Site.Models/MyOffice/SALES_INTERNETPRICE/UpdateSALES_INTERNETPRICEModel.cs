// ===================================================================
// File: UpdateSALES_INTERNETPRICEModel.cs
// 2017/1/17: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using Quick.Site.Common.Models;
using System.Web.Mvc;
using Quick.Site.Common;

namespace Ecomm.Site.Models.MyOffice.SALES_INTERNETPRICE
{
    public class UpdateSALES_INTERNETPRICEModel : EntityCommon
    {
        public UpdateSALES_INTERNETPRICEModel()
        {
        }

        [Display(Name = "CustomerID")]
        [Required(ErrorMessage = "CustomerID can not be empty")]
		public string CustomerID  { get; set; }


        [Display(Name = "ProductNo")]
        [Required(ErrorMessage = "ProductNo can not be empty")]
		public string ProductNo  { get; set; }


        [Display(Name = "IPrice")]
		public decimal? IPrice  { get; set; }


        [Display(Name = "Status")]
		public byte? Status  { get; set; }

    }
    
}

