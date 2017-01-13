// ===================================================================
// File: UpdateINFOR_CATEGORIESModel.cs
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

namespace Ecomm.Site.Models.SysConfig.INFOR_CATEGORIES
{
    public class UpdateINFOR_CATEGORIESModel : EntityCommon
    {
        public UpdateINFOR_CATEGORIESModel()
        {
        }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID can not be empty")]
		public string ID  { get; set; }


        [Display(Name = "InforCategoryName")]
        [Required(ErrorMessage = "InforCategoryName can not be empty")]
		public string InforCategoryName  { get; set; }


        [Display(Name = "DisplayOrder")]
		public int? DisplayOrder  { get; set; }


        [Display(Name = "ParentID")]
		public string ParentID  { get; set; }


        [Display(Name = "Clevel")]
		public int? Clevel  { get; set; }


        [Display(Name = "Status")]
		public int? Status  { get; set; }


        [Display(Name = "Item01")]
		public string Item01  { get; set; }


        [Display(Name = "Item02")]
		public string Item02  { get; set; }


        [Display(Name = "Item03")]
		public string Item03  { get; set; }


        [Display(Name = "Item04")]
		public string Item04  { get; set; }


        [Display(Name = "Item05")]
		public string Item05  { get; set; }

    }
    
}

