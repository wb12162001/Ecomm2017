// ===================================================================
// File: SALES_EBASKETModel.cs
// 2017/1/12: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using Quick.Site.Common.Models;
using System.Web.Mvc;
using Quick.Site.Common;

namespace Ecomm.Site.Models.MyOffice.SALES_EBASKET
{
    public class ShoppingOrderViewModel
    {
        public ShoppingOrderViewModel()
        {
            ShoppingCart = new ShoppingCartViewModel();
            ShoppingInfo = new ShoppingInformationViewModel();
        }
        public ShoppingCartViewModel ShoppingCart { get; set; }
        public ShoppingInformationViewModel ShoppingInfo { get; set; }
        public string OrderID { get; set; }
        public string ContactID { get; set; }

        public string Customer { get; set; }

        public string Creator { get; set; }

        public string Modifier { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModiDate { get; set; }

        public DateTime? OrderDate { get; set; }

        public bool IsPrint { get; set; }
        public int? ProcStatus { get; set; }
        public int? Status { get; set; }

    }

    public class ShoppingInformationViewModel
    {
        public string PurchaseNO { get; set; }
        public string PurchaseName { get; set; }
        public string PurchaseTel { get; set; }

        public string CommonText { get; set; }

        public string ShipTo { get; set; }

        public string Company { get; set; }
        public string Contact { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string Address { get; set; }
    }
    public class ShoppingCartViewModel
    {
        public IEnumerable<SALES_EBASKET_RelaModel> Sales_Ebaskets { get; set; }

        public string CartTotal { get; set; }

        public int ItemCount { get; set; }

        public string Message { get; set; }
        public string Misctitle { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Freight { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Miscellaneous { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double GST { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Total { get; set; }
    }
    public class SALES_EBASKETModel : EntityCommon
    {
        public SALES_EBASKETModel()
        {
            SearchModel = new SearchModel();
        }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID can not be empty")]
		public string ID  { get; set; }


        [Display(Name = "CustomerID")]
        [Required(ErrorMessage = "CustomerID can not be empty")]
		public string CustomerID  { get; set; }


        [Display(Name = "ContactID")]
		public string ContactID  { get; set; }


        [Display(Name = "ProductNo")]
        [Required(ErrorMessage = "ProductNo can not be empty")]
		public string ProductNo  { get; set; }


        [Display(Name = "Quantity")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Required(ErrorMessage = "Quantity can not be empty")]
		public double Quantity  { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Display(Name = "UnitPrice")]
		public double? UnitPrice  { get; set; }


        [Display(Name = "Unit")]
		public string Unit  { get; set; }


        [Display(Name = "Creator")]
		public string Creator  { get; set; }


        [Display(Name = "Modifier")]
		public string Modifier  { get; set; }


        [Display(Name = "CreateDate")]
		public DateTime? CreateDate  { get; set; }


        [Display(Name = "ModiDate")]
		public DateTime? ModiDate  { get; set; }


        [Display(Name = "MakeOrderID")]
		public string MakeOrderID  { get; set; }


        [Display(Name = "RowID")]
        [Required(ErrorMessage = "RowID can not be empty")]
		public int RowID  { get; set; }


        [Display(Name = "Status")]
		public int? Status  { get; set; }


        [Display(Name = "UnitPType")]
		public string UnitPType  { get; set; }

        
        public SearchModel SearchModel { get; set; }
    }

    public class SALES_EBASKET_RelaModel: SALES_EBASKETModel
    {
        public string ProductName { get; set; }
        public string ProductPic { get; set; }
        public string ProductID { get; set; }
        public double? StndCost { get; set; }
        public string StockType { get; set; }
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

