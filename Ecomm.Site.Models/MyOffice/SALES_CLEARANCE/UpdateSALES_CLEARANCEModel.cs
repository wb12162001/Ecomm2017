// ===================================================================
// File: UpdateSALES_CLEARANCEModel.cs
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

namespace Ecomm.Site.Models.MyOffice.SALES_CLEARANCE
{
    public class UpdateSALES_CLEARANCEModel : EntityCommon
    {
        public UpdateSALES_CLEARANCEModel()
        {
        }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID can not be empty")]
		public string ID  { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name can not be empty")]
		public string Name  { get; set; }


        [Display(Name = "ImgFile")]
		public string ImgFile  { get; set; }


        [Display(Name = "Notes")]
		public string Notes  { get; set; }


        [Display(Name = "SortNo")]
		public string SortNo  { get; set; }


        [Display(Name = "CreateDate")]
		public DateTime? CreateDate  { get; set; }


        [Display(Name = "StartDate")]
		public DateTime? StartDate  { get; set; }


        [Display(Name = "EndDate")]
		public DateTime? EndDate  { get; set; }


        [Display(Name = "Status")]
		public int? Status  { get; set; }

    }
    
}

