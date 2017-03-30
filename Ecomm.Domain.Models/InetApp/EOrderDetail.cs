// ===================================================================
// File: EOrderDetail.cs
// 2017/3/22: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Domain.Models.InetApp
{
    public class EOrderDetail : EntityBase<string>
    {
        public EOrderDetail()
        {
            
        }

		public short? OrderType  { get; set; }


		public int OrderID  { get; set; }


		public string Sn  { get; set; }


		public string Sku  { get; set; }


		public string Skudesc  { get; set; }


		public short? WareId  { get; set; }


		public string Unit  { get; set; }


		public decimal? UnitCost  { get; set; }


		public decimal? UnitPrice  { get; set; }


		public double? QtyonSales  { get; set; }


		public double? Orderqty  { get; set; }


		public double? Bkoqty  { get; set; }


		public double? Fullqty  { get; set; }


		public double? Discount  { get; set; }


		public decimal? Tax  { get; set; }


		public string OrderStats  { get; set; }


		public string CommText  { get; set; }


		public DateTime? FullDate  { get; set; }


		public DateTime? CretDate  { get; set; }


		public DateTime? ModiDate  { get; set; }


		public string CretID  { get; set; }


		public string Class1  { get; set; }

        
        
    }

    [NotMapped]
    public class EOrderDetail_MASTER : EOrderDetail
    {
        public string ProductName { get; set; }
    }
}

