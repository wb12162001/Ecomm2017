// ===================================================================
// File: UpdateSALES_FAVORITEModel.cs
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

namespace Ecomm.Site.Models.MyOffice.SALES_FAVORITE
{
    public class UpdateSALES_FAVORITEModel : EntityCommon
    {
        public UpdateSALES_FAVORITEModel()
        {
        }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID can not be empty")]
		public string ID  { get; set; }


        [Display(Name = "FavFolderID")]
		public string FavFolderID  { get; set; }


        [Display(Name = "ProductNo")]
        [Required(ErrorMessage = "ProductNo can not be empty")]
		public string ProductNo  { get; set; }


        [Display(Name = "CustomerID")]
        [Required(ErrorMessage = "CustomerID can not be empty")]
		public string CustomerID  { get; set; }


        [Display(Name = "ContactID")]
        [Required(ErrorMessage = "ContactID can not be empty")]
		public string ContactID  { get; set; }


        [Display(Name = "CreateDate")]
		public DateTime? CreateDate  { get; set; }


        [Display(Name = "ModiDate")]
		public DateTime? ModiDate  { get; set; }


        [Display(Name = "Creator")]
		public string Creator  { get; set; }


        [Display(Name = "Modifier")]
		public string Modifier  { get; set; }


        [Display(Name = "Status")]
		public int? Status  { get; set; }

    }
    
}

