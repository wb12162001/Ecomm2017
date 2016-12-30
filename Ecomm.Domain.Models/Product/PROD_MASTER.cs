// ===================================================================
// File: PROD_MASTER.cs
// 2016/12/20: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.Product
{
    public class PROD_MASTER : EntityBase<string>
    {
        public PROD_MASTER()
        {
        }

		public string ID  { get; set; }
		public string ProductNo  { get; set; }


		public string ProductName  { get; set; }


		public string Description  { get; set; }


		public int? ProductType  { get; set; }


		public double? StndCost  { get; set; }


		public double? CurrCost  { get; set; }


		public double? ListPrice  { get; set; }


		public double? SpecialPrice  { get; set; }


		public double? ClearPrice  { get; set; }


		public string ProdCategoryID  { get; set; }


		public string CategoryCode  { get; set; }


		public string SchdlUOM  { get; set; }


		public string PriceShed  { get; set; }


		public string BaseUOFM  { get; set; }


		public int? AvailableQTY  { get; set; }


		public string ProdGroupID  { get; set; }


		public string ProdSubclassID  { get; set; }


		public DateTime? LeadTime  { get; set; }


		public double? QtySales  { get; set; }


		public double? QtyMin  { get; set; }


		public double? QtyMax  { get; set; }


		public string CustomerID  { get; set; }


		public string StockType  { get; set; }


		public string SalesRepID  { get; set; }


		public string PriceBookItem  { get; set; }


		public string PriceLevel  { get; set; }


		public string BarCode  { get; set; }


		public int? Ranking  { get; set; }


		public string Notes  { get; set; }


		public string Substitute1  { get; set; }


		public string Substitute2  { get; set; }


		public double? Qty1  { get; set; }


		public double? Qty3  { get; set; }


		public double? Qty6  { get; set; }


		public double? Qty12  { get; set; }


		public double? Sales1  { get; set; }


		public double? Sales3  { get; set; }


		public double? Sales6  { get; set; }


		public double? Sales12  { get; set; }


		public double? GPD1  { get; set; }


		public double? GPD3  { get; set; }


		public double? GPD6  { get; set; }


		public double? GPD12  { get; set; }


		public DateTime? LastDate  { get; set; }


		public DateTime? CreateDate  { get; set; }


		public string Creator  { get; set; }


		public string Modifier  { get; set; }


		public DateTime? ModiDate  { get; set; }


		public int? Status  { get; set; }


		public double? P01  { get; set; }


		public double? P02  { get; set; }


		public double? P03  { get; set; }


		public double? P04  { get; set; }


		public double? P05  { get; set; }


		public double? P06  { get; set; }


		public double? P07  { get; set; }


		public double? P08  { get; set; }


		public double? P09  { get; set; }


		public double? P10  { get; set; }


		public bool IsCommend  { get; set; }


		public bool IsHot  { get; set; }


		public string ExteriorPart  { get; set; }


		public double? ExteriorPartPrice  { get; set; }


		public int? ViewTimes  { get; set; }


		public string SmallPic  { get; set; }


		public string BigPic  { get; set; }


		public double? LocationStocks1  { get; set; }


		public double? LocationStocks2  { get; set; }


		public double? LocationStocks3  { get; set; }


		public double? LocationStocks4  { get; set; }


		public double? LocationStocks5  { get; set; }


		public double? LocationStocks6  { get; set; }


		public double? LocationStocks7  { get; set; }


		public double? LocationStocks8  { get; set; }


		public double? LocationStocks9  { get; set; }


		public double? LocationStocks10  { get; set; }


		public double? LocationStocks11  { get; set; }


		public double? LocationStocks12  { get; set; }


		public double? LocationStocks13  { get; set; }


		public double? LocationStocks14  { get; set; }


		public double? LocationStocks15  { get; set; }


		public double? LocationAllocate1  { get; set; }


		public double? LocationAllocate2  { get; set; }


		public double? LocationAllocate3  { get; set; }


		public double? LocationAllocate4  { get; set; }


		public double? LocationAllocate5  { get; set; }


		public double? LocationAllocate6  { get; set; }


		public double? LocationAllocate7  { get; set; }


		public double? LocationAllocate8  { get; set; }


		public double? LocationAllocate9  { get; set; }


		public double? LocationAllocate10  { get; set; }


		public double? LocationAllocate11  { get; set; }


		public double? LocationAllocate12  { get; set; }


		public double? LocationAllocate13  { get; set; }


		public double? LocationAllocate14  { get; set; }


		public double? LocationAllocate15  { get; set; }


		public string Introduction  { get; set; }


		public string Brand  { get; set; }


		public string Item01  { get; set; }


		public string Item02  { get; set; }


		public string Item03  { get; set; }


		public string Item04  { get; set; }


		public string Item05  { get; set; }

    }
}

