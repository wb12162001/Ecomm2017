﻿// ===================================================================
// File: SALES_ESIORDERFORM.cs
// 2017/1/17: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Domain.Models.MyOffice
{
    public class SALES_ESIORDERFORM : EntityBase<string>
    {
        public SALES_ESIORDERFORM()
        {
            
        }

		public string CustomerID  { get; set; }


		public string ProductNo  { get; set; }


		public string ShipTo  { get; set; }


		public double? Qty0  { get; set; }


		public double? Qty1  { get; set; }


		public double? Qty2  { get; set; }


		public double? Qty3  { get; set; }


		public double? Qty4  { get; set; }


		public double? Qty5  { get; set; }


		public double? Qty6  { get; set; }


		public double? Qty7  { get; set; }


		public double? Qty8  { get; set; }


		public double? Qty9  { get; set; }


		public double? Qty10  { get; set; }


		public double? Qty11  { get; set; }


		public double? Qty12  { get; set; }


		public double? Qty13  { get; set; }


		public double? QtyTotal  { get; set; }


		public double? Cost0  { get; set; }


		public double? Cost1  { get; set; }


		public double? Cost2  { get; set; }


		public double? Cost3  { get; set; }


		public double? Cost4  { get; set; }


		public double? Cost5  { get; set; }


		public double? Cost6  { get; set; }


		public double? Cost7  { get; set; }


		public double? Cost8  { get; set; }


		public double? Cost9  { get; set; }


		public double? Cost10  { get; set; }


		public double? Cost11  { get; set; }


		public double? Cost12  { get; set; }


		public double? Cost13  { get; set; }


		public double? CostTotal  { get; set; }


		public double? Price0  { get; set; }


		public double? Price1  { get; set; }


		public double? Price2  { get; set; }


		public double? Price3  { get; set; }


		public double? Price4  { get; set; }


		public double? Price5  { get; set; }


		public double? Price6  { get; set; }


		public double? Price7  { get; set; }


		public double? Price8  { get; set; }


		public double? Price9  { get; set; }


		public double? Price10  { get; set; }


		public double? Price11  { get; set; }


		public double? Price12  { get; set; }


		public double? Price13  { get; set; }


		public double? PriceTotal  { get; set; }


		public string ProdCategoryCode  { get; set; }


		public DateTime? IDate  { get; set; }


		public string ContactID  { get; set; }


		public double? CurrentPrice  { get; set; }


		public string PriceType  { get; set; }


		public int? Status  { get; set; }


		public double? Forecast  { get; set; }

        
        
    }

    [NotMapped]
    public class SALES_ESIORDERFORM_MASTER : SALES_ESIORDERFORM
    {
        public string ProductName { get; set; }
        public string ProductPic { get; set; }
        public string ProductID { get; set; }

        public double? StndCost { get; set; }
        public string StockType { get; set; }
    }

    [NotMapped]
    public class ESIORDERFORM_PAGE_MASTER
    {
        public string ProductName { get; set; }
        public string ProductNo { get; set; }
        public string ProductID { get; set; }

        public double? ListPrice { get; set; }
        public double? SpecialPrice { get; set; }
        public double? ClearPrice { get; set; }

        public string CategoryCode { get; set; }
        public string BaseUOFM { get; set; }
        public string ProdGroupID { get; set; }
        public string StockType { get; set; }
        public string SmallPic { get; set; }
        public string BigPic { get; set; }
        public string ShipTo { get; set; }

        public double? Qty0 { get; set; }
        public double? Qty1 { get; set; }
        public double? Qty2 { get; set; }
        public double? Qty3 { get; set; }
        public double? Qty4 { get; set; }
        public double? Qty5 { get; set; }
        public double? Qty6 { get; set; }

        public double? AVGQTY { get; set; }
        public double? CurrentPrice { get; set; }

        public string PriceType { get; set; }

        public int? Status { get; set; }


        public double? Forecast { get; set; }

        public string Item04 { get; set; }
        public string CategoryName { get; set; }
        public string MenuAlias { get; set; }
    }

    [NotMapped]
    public class Location
    {
        public int Total { get; set; }
        public string ShipTo { get; set; }
    }

    [NotMapped]
    public class CustomizedProduct_PAGE_MASTER
    {
        public string ProductName { get; set; }
        public string ProductNo { get; set; }
        public string ProductID { get; set; }

        public double? ListPrice { get; set; }
        public double? SpecialPrice { get; set; }
        public double? ClearPrice { get; set; }

        public string CategoryCode { get; set; }
        public string BaseUOFM { get; set; }
        public string ProdGroupID { get; set; }
        public string StockType { get; set; }
        public string SmallPic { get; set; }
        public string BigPic { get; set; }
        
        public string CategoryName { get; set; }
        public string MenuAlias { get; set; }
    }

    [NotMapped]
    public class MyFavourite_QTY_MASTER
    {
        public string CustomerID { get; set; }


        public string ProductNo { get; set; }


        public string ShipTo { get; set; }


        public double? Qty0 { get; set; }


        public double? Qty1 { get; set; }


        public double? Qty2 { get; set; }


        public double? Qty3 { get; set; }


        public double? Forecast { get; set; }

    }
}

