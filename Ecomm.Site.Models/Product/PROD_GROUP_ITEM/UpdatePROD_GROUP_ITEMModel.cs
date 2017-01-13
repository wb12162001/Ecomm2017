// ===================================================================
// File: UpdatePROD_GROUP_ITEMModel.cs
// 2016/12/28: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using Quick.Site.Common.Models;
using System.Web.Mvc;
using Quick.Site.Common;

namespace Ecomm.Site.Models.Product.PROD_GROUP_ITEM
{
    public class UpdatePROD_GROUP_ITEMModel : EntityCommon
    {
        public UpdatePROD_GROUP_ITEMModel()
        {
            Groups = new List<SelectListItem>() {
                new SelectListItem { Text = "--- Root ---", Value = ""},
            };
            Products = new List<SelectListItem>() {
                new SelectListItem { Text = "--- Root ---", Value = ""},
            };
        }

        [Display(Name = "ProductID")]
        [Required(ErrorMessage = "ProductID can not be empty")]
        public string ProductID { get; set; }

        [Display(Name = "Product")]
        public string ProductName { get; set; }
        public List<SelectListItem> Products { get; set; }


        [Display(Name = "GROUP_INDEX")]
        [Required(ErrorMessage = "GROUP_INDEX can not be empty")]
        public string GROUP_INDEX { get; set; }

        [Display(Name = "Group")]
        public string GroupName { get; set; }
        public List<SelectListItem> Groups { get; set; }

        [Display(Name = "ProductID")]
        [Required(ErrorMessage = "ProductID can not be empty")]
        public string NewProductID { get; set; }


        [Display(Name = "GROUP_INDEX")]
        [Required(ErrorMessage = "GROUP_INDEX can not be empty")]
        public string NewGROUP_INDEX { get; set; }


        [Display(Name = "Notes")]
        [Required(ErrorMessage = "Notes can not be empty")]
		public string Notes  { get; set; }


        [Display(Name = "Picture")]
		public string Picture  { get; set; }


        [Display(Name = "IsActivate")]
        public bool Status { get; set; }

    }
    
}

