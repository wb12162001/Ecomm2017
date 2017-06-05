// ===================================================================
// File: SALES_ESIORDERFORMModel.cs
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

namespace Ecomm.Site.Models.MyOffice.SALES_ESIORDERFORM
{
    public class SALES_ESIORDERFORMModel : EntityCommon
    {
        public SALES_ESIORDERFORMModel()
        {
            SearchModel = new SearchModel();
        }

        [Display(Name = "CustomerID")]
        [Required(ErrorMessage = "CustomerID can not be empty")]
		public string CustomerID  { get; set; }


        [Display(Name = "ProductNo")]
        [Required(ErrorMessage = "ProductNo can not be empty")]
		public string ProductNo  { get; set; }


        [Display(Name = "ShipTo")]
        [Required(ErrorMessage = "ShipTo can not be empty")]
		public string ShipTo  { get; set; }


        [Display(Name = "Qty0")]
		public double? Qty0  { get; set; }


        [Display(Name = "Qty1")]
		public double? Qty1  { get; set; }


        [Display(Name = "Qty2")]
		public double? Qty2  { get; set; }


        [Display(Name = "Qty3")]
		public double? Qty3  { get; set; }


        [Display(Name = "Qty4")]
		public double? Qty4  { get; set; }


        [Display(Name = "Qty5")]
		public double? Qty5  { get; set; }


        [Display(Name = "Qty6")]
		public double? Qty6  { get; set; }


        [Display(Name = "Qty7")]
		public double? Qty7  { get; set; }


        [Display(Name = "Qty8")]
		public double? Qty8  { get; set; }


        [Display(Name = "Qty9")]
		public double? Qty9  { get; set; }


        [Display(Name = "Qty10")]
		public double? Qty10  { get; set; }


        [Display(Name = "Qty11")]
		public double? Qty11  { get; set; }


        [Display(Name = "Qty12")]
		public double? Qty12  { get; set; }


        [Display(Name = "Qty13")]
		public double? Qty13  { get; set; }


        [Display(Name = "QtyTotal")]
		public double? QtyTotal  { get; set; }


        [Display(Name = "Cost0")]
		public double? Cost0  { get; set; }


        [Display(Name = "Cost1")]
		public double? Cost1  { get; set; }


        [Display(Name = "Cost2")]
		public double? Cost2  { get; set; }


        [Display(Name = "Cost3")]
		public double? Cost3  { get; set; }


        [Display(Name = "Cost4")]
		public double? Cost4  { get; set; }


        [Display(Name = "Cost5")]
		public double? Cost5  { get; set; }


        [Display(Name = "Cost6")]
		public double? Cost6  { get; set; }


        [Display(Name = "Cost7")]
		public double? Cost7  { get; set; }


        [Display(Name = "Cost8")]
		public double? Cost8  { get; set; }


        [Display(Name = "Cost9")]
		public double? Cost9  { get; set; }


        [Display(Name = "Cost10")]
		public double? Cost10  { get; set; }


        [Display(Name = "Cost11")]
		public double? Cost11  { get; set; }


        [Display(Name = "Cost12")]
		public double? Cost12  { get; set; }


        [Display(Name = "Cost13")]
		public double? Cost13  { get; set; }


        [Display(Name = "CostTotal")]
		public double? CostTotal  { get; set; }


        [Display(Name = "Price0")]
		public double? Price0  { get; set; }


        [Display(Name = "Price1")]
		public double? Price1  { get; set; }


        [Display(Name = "Price2")]
		public double? Price2  { get; set; }


        [Display(Name = "Price3")]
		public double? Price3  { get; set; }


        [Display(Name = "Price4")]
		public double? Price4  { get; set; }


        [Display(Name = "Price5")]
		public double? Price5  { get; set; }


        [Display(Name = "Price6")]
		public double? Price6  { get; set; }


        [Display(Name = "Price7")]
		public double? Price7  { get; set; }


        [Display(Name = "Price8")]
		public double? Price8  { get; set; }


        [Display(Name = "Price9")]
		public double? Price9  { get; set; }


        [Display(Name = "Price10")]
		public double? Price10  { get; set; }


        [Display(Name = "Price11")]
		public double? Price11  { get; set; }


        [Display(Name = "Price12")]
		public double? Price12  { get; set; }


        [Display(Name = "Price13")]
		public double? Price13  { get; set; }


        [Display(Name = "PriceTotal")]
		public double? PriceTotal  { get; set; }


        [Display(Name = "ProdCategoryCode")]
		public string ProdCategoryCode  { get; set; }


        [Display(Name = "IDate")]
		public DateTime? IDate  { get; set; }


        [Display(Name = "ContactID")]
		public string ContactID  { get; set; }


        [Display(Name = "CurrentPrice")]
		public double? CurrentPrice  { get; set; }


        [Display(Name = "PriceType")]
		public string PriceType  { get; set; }


        [Display(Name = "Status")]
		public int? Status  { get; set; }


        [Display(Name = "Forecast")]
		public double? Forecast  { get; set; }

        
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

    public class SALES_ESIORDERFORM_RelaModel : SALES_ESIORDERFORMModel
    {
        public string ProductName { get; set; }
        public string ProductPic { get; set; }
        public string ProductID { get; set; }
        public double? StndCost { get; set; }
        public string StockType { get; set; }
    }
    public class EOF_PAGE_Other_MASTER
    {
        public string Month0 { get; set; }
        public string Month1 { get; set; }
        public string Month2 { get; set; }
        public string Month3 { get; set; }
        public string Month4 { get; set; }
    }
    public class EOF_PAGE_MASTER
    {
        public string ID { get; set; }
        public string ProductName { get; set; }
        public string ProductNo { get; set; }
        public string ProductID { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? ListPrice { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? SpecialPrice { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? ClearPrice { get; set; }

        public string CategoryCode { get; set; }
        public string BaseUOFM { get; set; }
        public string ProdGroupID { get; set; }
        public string StockType { get; set; }
        public string SmallPic { get; set; }
        public string MiddlePic { get; set; }
        public string BigPic { get; set; }
        public string ShipTo { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Qty0 { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Qty1 { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Qty2 { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Qty3 { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Qty4 { get; set; }
        public double? Qty5 { get; set; }
        public double? Qty6 { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? AVGQTY { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? CurrentPrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? SellPrice { get; set; }

        public string PriceType { get; set; }

        public int? Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Forecast { get; set; }

        public string Item04 { get; set; }
        public string CategoryName { get; set; }
        public string MenuAlias { get; set; }

        public int pCount { get; set; }

        public string altPath { get; set; }
    }

    public class EOF_Category
    {
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
        public int Count { get; set; }
    }

    public class EOF_Location
    {
        public string ShopName { get; set; }
        public string ShopId { get; set; }
        public int Count { get; set; }
    }
    public class EOF_Favourite
    {
        public string Favourite { get; set; }
        public int Count { get; set; }
        public string FavouriteID { get; set; }

        public string Img { get; set; }
    }
    public class EOF_PAGE_Other2_MASTER
    {
        public EOF_PAGE_Other2_MASTER()
        {
            Categories = new List<EOF_Category>();
            Locations = new List<EOF_Location>();
            MyFavourites = new List<EOF_Favourite>();
        }
        public List<EOF_Category> Categories { get; set; }

        public List<EOF_Location> Locations { get; set; }

        public List<EOF_Favourite> MyFavourites { get; set; }
    }
}

