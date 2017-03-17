// ===================================================================
// File: UpdatePROD_PROMOTIONSModel.cs
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

namespace Ecomm.Site.Models.Product.PROD_PROMOTIONS
{
    public class UpdatePROD_PROMOTIONSModel : EntityCommon
    {
        public UpdatePROD_PROMOTIONSModel()
        {
        }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID can not be empty")]
		public string ID  { get; set; }


        [Display(Name = "ProductNo")]
        [Required(ErrorMessage = "ProductNo can not be empty")]
		public string ProductNo  { get; set; }


        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title can not be empty")]
		public string Title  { get; set; }


        [Display(Name = "ImgFile")]
		public string ImgFile  { get; set; }


        [Display(Name = "Description")]
		public string Description  { get; set; }


        [Display(Name = "FootNote")]
		public string FootNote  { get; set; }


        [Display(Name = "SortNo")]
		public string SortNo  { get; set; }


        [Display(Name = "CreateDate")]
		public DateTime? CreateDate  { get; set; }


        [Display(Name = "Status")]
		public int? Status  { get; set; }

    }
    
}

