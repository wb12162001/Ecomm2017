// ===================================================================
// File: UpdatePROD_PROPERTIESModel.cs
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

namespace Ecomm.Site.Models.Product.PROD_PROPERTIES
{
    public class UpdatePROD_PROPERTIESModel : EntityCommon
    {
        public UpdatePROD_PROPERTIESModel()
        {
        }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID can not be empty")]
		public string ID  { get; set; }


        [Display(Name = "ProductNo")]
        [Required(ErrorMessage = "ProductNo can not be empty")]
		public string ProductNo  { get; set; }


        [Display(Name = "PropertyID")]
        [Required(ErrorMessage = "PropertyID can not be empty")]
		public string PropertyID  { get; set; }


        [Display(Name = "PropertyValue")]
		public string PropertyValue  { get; set; }


        [Display(Name = "PLevel")]
		public int? PLevel  { get; set; }


        [Display(Name = "ParentID")]
		public string ParentID  { get; set; }


        [Display(Name = "RelationCode")]
		public string RelationCode  { get; set; }


        [Display(Name = "RowID")]
        [Required(ErrorMessage = "RowID can not be empty")]
		public int RowID  { get; set; }


        [Display(Name = "RealProductNo")]
		public string RealProductNo  { get; set; }


        [Display(Name = "DisplayOrder")]
		public int? DisplayOrder  { get; set; }


        [Display(Name = "Remark")]
		public string Remark  { get; set; }


        [Display(Name = "Status")]
		public int? Status  { get; set; }

    }
    
}

