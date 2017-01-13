// ===================================================================
// File: SALES_EORDERDETAILS.cs
// 2017/1/12: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.MyOffice
{
    public class SALES_EORDERDETAILS : EntityBase<string>
    {
        public SALES_EORDERDETAILS()
        {
            
        }

		public string OrderID  { get; set; }


		public string ProductNo  { get; set; }


		public double? OrderQty  { get; set; }


		public string Unit  { get; set; }


		public double? UnitCost  { get; set; }


		public double? UnitPrice  { get; set; }


		public double? Tax  { get; set; }


		public double? Freight  { get; set; }


		public string CommText  { get; set; }


		public string Creator  { get; set; }


		public string Modifier  { get; set; }


		public DateTime? ModiDate  { get; set; }


		public DateTime? CreateDate  { get; set; }


		public int RowID  { get; set; }


		public int? Status  { get; set; }


		public string Item01  { get; set; }


		public string Item02  { get; set; }


		public string Item03  { get; set; }


		public string Item04  { get; set; }


		public string Item05  { get; set; }


		public string UnitPType  { get; set; }

        
        
    }
    
    
}

