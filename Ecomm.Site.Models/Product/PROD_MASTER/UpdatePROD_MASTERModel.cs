﻿// ===================================================================
// File: UpdatePROD_MASTERModel.cs
// 2016/12/22: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using Quick.Site.Common.Models;
using System.Web.Mvc;
using Quick.Site.Common;

namespace Ecomm.Site.Models.Product.PROD_MASTER
{
    public class UpdatePROD_MASTERModel : EntityCommon
    {
        public UpdatePROD_MASTERModel()
        {
        }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID can not be empty")]
		public string ID  { get; set; }


        [Display(Name = "ProductNo")]
        [Required(ErrorMessage = "ProductNo can not be empty")]
		public string ProductNo  { get; set; }


        [Display(Name = "ProductName")]
        [Required(ErrorMessage = "ProductName can not be empty")]
		public string ProductName  { get; set; }


        [Display(Name = "Description")]
		public string Description  { get; set; }


        [Display(Name = "ProductType")]
		public int? ProductType  { get; set; }


        [Display(Name = "StndCost")]
		public double? StndCost  { get; set; }


        [Display(Name = "CurrCost")]
		public double? CurrCost  { get; set; }


        [Display(Name = "ListPrice")]
		public double? ListPrice  { get; set; }


        [Display(Name = "SpecialPrice")]
		public double? SpecialPrice  { get; set; }


        [Display(Name = "ClearPrice")]
		public double? ClearPrice  { get; set; }


        [Display(Name = "ProdCategoryID")]
		public string ProdCategoryID  { get; set; }


        [Display(Name = "CategoryCode")]
		public string CategoryCode  { get; set; }


        [Display(Name = "SchdlUOM")]
		public string SchdlUOM  { get; set; }


        [Display(Name = "PriceShed")]
		public string PriceShed  { get; set; }


        [Display(Name = "BaseUOFM")]
		public string BaseUOFM  { get; set; }


        [Display(Name = "AvailableQTY")]
		public int? AvailableQTY  { get; set; }


        [Display(Name = "ProdGroupID")]
		public string ProdGroupID  { get; set; }


        [Display(Name = "ProdSubclassID")]
		public string ProdSubclassID  { get; set; }


        [Display(Name = "LeadTime")]
		public DateTime? LeadTime  { get; set; }


        [Display(Name = "QtySales")]
		public double? QtySales  { get; set; }


        [Display(Name = "QtyMin")]
		public double? QtyMin  { get; set; }


        [Display(Name = "QtyMax")]
		public double? QtyMax  { get; set; }


        [Display(Name = "CustomerID")]
		public string CustomerID  { get; set; }


        [Display(Name = "StockType")]
		public string StockType  { get; set; }


        [Display(Name = "SalesRepID")]
		public string SalesRepID  { get; set; }


        [Display(Name = "PriceBookItem")]
		public string PriceBookItem  { get; set; }


        [Display(Name = "PriceLevel")]
		public string PriceLevel  { get; set; }


        [Display(Name = "BarCode")]
		public string BarCode  { get; set; }


        [Display(Name = "Ranking")]
		public int? Ranking  { get; set; }


        [Display(Name = "Notes")]
		public string Notes  { get; set; }


        [Display(Name = "Substitute1")]
		public string Substitute1  { get; set; }


        [Display(Name = "Substitute2")]
		public string Substitute2  { get; set; }


        [Display(Name = "Qty1")]
		public double? Qty1  { get; set; }


        [Display(Name = "Qty3")]
		public double? Qty3  { get; set; }


        [Display(Name = "Qty6")]
		public double? Qty6  { get; set; }


        [Display(Name = "Qty12")]
		public double? Qty12  { get; set; }


        [Display(Name = "Sales1")]
		public double? Sales1  { get; set; }


        [Display(Name = "Sales3")]
		public double? Sales3  { get; set; }


        [Display(Name = "Sales6")]
		public double? Sales6  { get; set; }


        [Display(Name = "Sales12")]
		public double? Sales12  { get; set; }


        [Display(Name = "GPD1")]
		public double? GPD1  { get; set; }


        [Display(Name = "GPD3")]
		public double? GPD3  { get; set; }


        [Display(Name = "GPD6")]
		public double? GPD6  { get; set; }


        [Display(Name = "GPD12")]
		public double? GPD12  { get; set; }


        [Display(Name = "LastDate")]
		public DateTime? LastDate  { get; set; }


        [Display(Name = "CreateDate")]
		public DateTime? CreateDate  { get; set; }


        [Display(Name = "Creator")]
		public string Creator  { get; set; }


        [Display(Name = "Modifier")]
		public string Modifier  { get; set; }


        [Display(Name = "ModiDate")]
		public DateTime? ModiDate  { get; set; }


        [Display(Name = "Status")]
		public int? Status  { get; set; }


        [Display(Name = "P01")]
		public double? P01  { get; set; }


        [Display(Name = "P02")]
		public double? P02  { get; set; }


        [Display(Name = "P03")]
		public double? P03  { get; set; }


        [Display(Name = "P04")]
		public double? P04  { get; set; }


        [Display(Name = "P05")]
		public double? P05  { get; set; }


        [Display(Name = "P06")]
		public double? P06  { get; set; }


        [Display(Name = "P07")]
		public double? P07  { get; set; }


        [Display(Name = "P08")]
		public double? P08  { get; set; }


        [Display(Name = "P09")]
		public double? P09  { get; set; }


        [Display(Name = "P10")]
		public double? P10  { get; set; }


        [Display(Name = "IsCommend")]
		public bool IsCommend  { get; set; }


        [Display(Name = "IsHot")]
		public bool IsHot  { get; set; }


        [Display(Name = "ExteriorPart")]
		public string ExteriorPart  { get; set; }


        [Display(Name = "ExteriorPartPrice")]
		public double? ExteriorPartPrice  { get; set; }


        [Display(Name = "ViewTimes")]
		public int? ViewTimes  { get; set; }


        [Display(Name = "SmallPic")]
		public string SmallPic  { get; set; }


        [Display(Name = "BigPic")]
		public string BigPic  { get; set; }


        [Display(Name = "LocationStocks1")]
		public double? LocationStocks1  { get; set; }


        [Display(Name = "LocationStocks2")]
		public double? LocationStocks2  { get; set; }


        [Display(Name = "LocationStocks3")]
		public double? LocationStocks3  { get; set; }


        [Display(Name = "LocationStocks4")]
		public double? LocationStocks4  { get; set; }


        [Display(Name = "LocationStocks5")]
		public double? LocationStocks5  { get; set; }


        [Display(Name = "LocationStocks6")]
		public double? LocationStocks6  { get; set; }


        [Display(Name = "LocationStocks7")]
		public double? LocationStocks7  { get; set; }


        [Display(Name = "LocationStocks8")]
		public double? LocationStocks8  { get; set; }


        [Display(Name = "LocationStocks9")]
		public double? LocationStocks9  { get; set; }


        [Display(Name = "LocationStocks10")]
		public double? LocationStocks10  { get; set; }


        [Display(Name = "LocationStocks11")]
		public double? LocationStocks11  { get; set; }


        [Display(Name = "LocationStocks12")]
		public double? LocationStocks12  { get; set; }


        [Display(Name = "LocationStocks13")]
		public double? LocationStocks13  { get; set; }


        [Display(Name = "LocationStocks14")]
		public double? LocationStocks14  { get; set; }


        [Display(Name = "LocationStocks15")]
		public double? LocationStocks15  { get; set; }


        [Display(Name = "LocationAllocate1")]
		public double? LocationAllocate1  { get; set; }


        [Display(Name = "LocationAllocate2")]
		public double? LocationAllocate2  { get; set; }


        [Display(Name = "LocationAllocate3")]
		public double? LocationAllocate3  { get; set; }


        [Display(Name = "LocationAllocate4")]
		public double? LocationAllocate4  { get; set; }


        [Display(Name = "LocationAllocate5")]
		public double? LocationAllocate5  { get; set; }


        [Display(Name = "LocationAllocate6")]
		public double? LocationAllocate6  { get; set; }


        [Display(Name = "LocationAllocate7")]
		public double? LocationAllocate7  { get; set; }


        [Display(Name = "LocationAllocate8")]
		public double? LocationAllocate8  { get; set; }


        [Display(Name = "LocationAllocate9")]
		public double? LocationAllocate9  { get; set; }


        [Display(Name = "LocationAllocate10")]
		public double? LocationAllocate10  { get; set; }


        [Display(Name = "LocationAllocate11")]
		public double? LocationAllocate11  { get; set; }


        [Display(Name = "LocationAllocate12")]
		public double? LocationAllocate12  { get; set; }


        [Display(Name = "LocationAllocate13")]
		public double? LocationAllocate13  { get; set; }


        [Display(Name = "LocationAllocate14")]
		public double? LocationAllocate14  { get; set; }


        [Display(Name = "LocationAllocate15")]
		public double? LocationAllocate15  { get; set; }


        [Display(Name = "Introduction")]
		public string Introduction  { get; set; }


        [Display(Name = "Brand")]
		public string Brand  { get; set; }


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

