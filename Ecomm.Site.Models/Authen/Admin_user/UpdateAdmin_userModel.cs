// ===================================================================
// File: UpdateAdmin_userModel.cs
// 2016/12/23: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using Quick.Site.Common.Models;
using System.Web.Mvc;
using Quick.Site.Common;

namespace Ecomm.Site.Models.Authen.Admin_user
{
    public class UpdateAdmin_userModel : EntityCommon
    {
        public UpdateAdmin_userModel()
        {
        }

        [Display(Name = "Id")]
        [Required(ErrorMessage = "Id can not be empty")]
		public string Id  { get; set; }


        [Display(Name = "Name")]
		public string Name  { get; set; }


        [Display(Name = "Userid")]
        [Required(ErrorMessage = "Userid can not be empty")]
		public string Userid  { get; set; }


        [Display(Name = "Passid")]
        [Required(ErrorMessage = "Passid can not be empty")]
		public string Passid  { get; set; }


        [Display(Name = "Usertype")]
		public string Usertype  { get; set; }


        [Display(Name = "Fname")]
		public string Fname  { get; set; }


        [Display(Name = "Lname")]
		public string Lname  { get; set; }


        [Display(Name = "Mname")]
		public string Mname  { get; set; }


        [Display(Name = "Gender")]
		public string Gender  { get; set; }


        [Display(Name = "Title")]
		public string Title  { get; set; }


        [Display(Name = "Email")]
		public string Email  { get; set; }


        [Display(Name = "Description")]
		public string Description  { get; set; }


        [Display(Name = "Status")]
		public byte? Status  { get; set; }


        [Display(Name = "Sessionid")]
		public string Sessionid  { get; set; }


        [Display(Name = "Ip")]
		public string Ip  { get; set; }


        [Display(Name = "Lastdate")]
		public DateTime? Lastdate  { get; set; }


        [Display(Name = "Cretuser")]
		public string Cretuser  { get; set; }


        [Display(Name = "Cretdate")]
		public DateTime? Cretdate  { get; set; }


        [Display(Name = "Modidate")]
		public DateTime? Modidate  { get; set; }


        [Display(Name = "Modiuser")]
		public string Modiuser  { get; set; }


        [Display(Name = "Row_id")]
        [Required(ErrorMessage = "Row_id can not be empty")]
		public int Row_id  { get; set; }


        [Display(Name = "Phoneid")]
		public string Phoneid  { get; set; }


        [Display(Name = "Temp01")]
		public string Temp01  { get; set; }

    }
    
}

