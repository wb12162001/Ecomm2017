// ===================================================================
// File: UpdatePROD_GROUP_INDEXModel.cs
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

namespace Ecomm.Site.Models.Product.PROD_GROUP_INDEX
{
    public class UpdatePROD_GROUP_INDEXModel : EntityCommon
    {
        public UpdatePROD_GROUP_INDEXModel()
        {
        }

        [Display(Name = "ID")]
		public string ID  { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name can not be empty")]
		public string Name  { get; set; }


        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description can not be empty")]
		public string Description  { get; set; }


        [Display(Name = "ParentID")]
		public string ParentID  { get; set; }


        [Display(Name = "ColorBg")]
		public string ColorBg  { get; set; }


        [Display(Name = "ColorText")]
		public string ColorText  { get; set; }


        [Display(Name = "Picture")]
		public string Picture  { get; set; }


        [Display(Name = "DisplayOrder")]
		public int? DisplayOrder  { get; set; }


        [Display(Name = "Creator")]
		public string Creator  { get; set; }


        [Display(Name = "Modifier")]
		public string Modifier  { get; set; }


        [Display(Name = "CreateDate")]
		public DateTime? CreateDate  { get; set; }


        [Display(Name = "Modidate")]
		public DateTime? Modidate  { get; set; }


        [Display(Name = "IsActivate")]
        public bool Status { get; set; }


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

