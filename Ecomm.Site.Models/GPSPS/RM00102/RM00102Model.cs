// ===================================================================
// File: RM00102Model.cs
// 2017/3/15: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using Quick.Site.Common.Models;
using System.Web.Mvc;
using Quick.Site.Common;

namespace Ecomm.Site.Models.GPSPS.RM00102
{
    public class RM00102Model : EntityCommon
    {
        public RM00102Model()
        {
            SearchModel = new SearchModel();
        }

        [Display(Name = "CUSTNMBR")]
        [Required(ErrorMessage = "CUSTNMBR can not be empty")]
		public string CUSTNMBR  { get; set; }


        [Display(Name = "ADRSCODE")]
        [Required(ErrorMessage = "ADRSCODE can not be empty")]
		public string ADRSCODE  { get; set; }


        [Display(Name = "SLPRSNID")]
        [Required(ErrorMessage = "SLPRSNID can not be empty")]
		public string SLPRSNID  { get; set; }


        [Display(Name = "UPSZONE")]
        [Required(ErrorMessage = "UPSZONE can not be empty")]
		public string UPSZONE  { get; set; }


        [Display(Name = "SHIPMTHD")]
        [Required(ErrorMessage = "SHIPMTHD can not be empty")]
		public string SHIPMTHD  { get; set; }


        [Display(Name = "TAXSCHID")]
        [Required(ErrorMessage = "TAXSCHID can not be empty")]
		public string TAXSCHID  { get; set; }


        [Display(Name = "CNTCPRSN")]
        [Required(ErrorMessage = "CNTCPRSN can not be empty")]
		public string CNTCPRSN  { get; set; }


        [Display(Name = "ADDRESS1")]
        [Required(ErrorMessage = "ADDRESS1 can not be empty")]
		public string ADDRESS1  { get; set; }


        [Display(Name = "ADDRESS2")]
        [Required(ErrorMessage = "ADDRESS2 can not be empty")]
		public string ADDRESS2  { get; set; }


        [Display(Name = "ADDRESS3")]
        [Required(ErrorMessage = "ADDRESS3 can not be empty")]
		public string ADDRESS3  { get; set; }


        [Display(Name = "COUNTRY")]
        [Required(ErrorMessage = "COUNTRY can not be empty")]
		public string COUNTRY  { get; set; }


        [Display(Name = "CITY")]
        [Required(ErrorMessage = "CITY can not be empty")]
		public string CITY  { get; set; }


        [Display(Name = "STATE")]
        [Required(ErrorMessage = "STATE can not be empty")]
		public string STATE  { get; set; }


        [Display(Name = "ZIP")]
        [Required(ErrorMessage = "ZIP can not be empty")]
		public string ZIP  { get; set; }


        [Display(Name = "PHONE1")]
        [Required(ErrorMessage = "PHONE1 can not be empty")]
		public string PHONE1  { get; set; }


        [Display(Name = "PHONE2")]
        [Required(ErrorMessage = "PHONE2 can not be empty")]
		public string PHONE2  { get; set; }


        [Display(Name = "PHONE3")]
        [Required(ErrorMessage = "PHONE3 can not be empty")]
		public string PHONE3  { get; set; }


        [Display(Name = "FAX")]
        [Required(ErrorMessage = "FAX can not be empty")]
		public string FAX  { get; set; }


        [Display(Name = "MODIFDT")]
        [Required(ErrorMessage = "MODIFDT can not be empty")]
		public DateTime MODIFDT  { get; set; }


        [Display(Name = "CREATDDT")]
        [Required(ErrorMessage = "CREATDDT can not be empty")]
		public DateTime CREATDDT  { get; set; }


        [Display(Name = "GPSFOINTEGRATIONID")]
        [Required(ErrorMessage = "GPSFOINTEGRATIONID can not be empty")]
		public string GPSFOINTEGRATIONID  { get; set; }


        [Display(Name = "INTEGRATIONSOURCE")]
        [Required(ErrorMessage = "INTEGRATIONSOURCE can not be empty")]
		public short INTEGRATIONSOURCE  { get; set; }


        [Display(Name = "INTEGRATIONID")]
        [Required(ErrorMessage = "INTEGRATIONID can not be empty")]
		public string INTEGRATIONID  { get; set; }


        [Display(Name = "CCode")]
        [Required(ErrorMessage = "CCode can not be empty")]
		public string CCode  { get; set; }


        [Display(Name = "DECLID")]
        [Required(ErrorMessage = "DECLID can not be empty")]
		public string DECLID  { get; set; }


        [Display(Name = "LOCNCODE")]
        [Required(ErrorMessage = "LOCNCODE can not be empty")]
		public string LOCNCODE  { get; set; }


        [Display(Name = "SALSTERR")]
        [Required(ErrorMessage = "SALSTERR can not be empty")]
		public string SALSTERR  { get; set; }


        [Display(Name = "USERDEF1")]
        [Required(ErrorMessage = "USERDEF1 can not be empty")]
		public string USERDEF1  { get; set; }


        [Display(Name = "USERDEF2")]
        [Required(ErrorMessage = "USERDEF2 can not be empty")]
		public string USERDEF2  { get; set; }


        [Display(Name = "ShipToName")]
        [Required(ErrorMessage = "ShipToName can not be empty")]
		public string ShipToName  { get; set; }


        [Display(Name = "Print_Phone_NumberGB")]
        [Required(ErrorMessage = "Print_Phone_NumberGB can not be empty")]
		public short Print_Phone_NumberGB  { get; set; }


        [Display(Name = "DEX_ROW_TS")]
        [Required(ErrorMessage = "DEX_ROW_TS can not be empty")]
		public DateTime DEX_ROW_TS  { get; set; }


        [Display(Name = "DEX_ROW_ID")]
        [Required(ErrorMessage = "DEX_ROW_ID can not be empty")]
		public int DEX_ROW_ID  { get; set; }

        
        public SearchModel SearchModel { get; set; }
    }
    
    public class SearchModel
    {
        public SearchModel()
        {
            EnabledItems = new List<SelectListItem> { 
                new SelectListItem { Text = "--- Please select ---", Value = "-1", Selected = true }, 
                new SelectListItem { Text = "Yes", Value = "1" }, 
                new SelectListItem { Text = "No", Value = "0" }
            };
        }

        [Display(Name = "Name")]
        public string LoginName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "IsEnabled")]
        public bool Enabled { get; set; }

		[Display(Name = "Start Time")]
		[DataType(DataType.DateTime)]
		public DateTime? StartTime { get; set; }

		[Display(Name = "End Time")]
		[DataType(DataType.DateTime)]
		public DateTime? EndTime { get; set; }

        public List<SelectListItem> EnabledItems { get; set; }
    }
}

