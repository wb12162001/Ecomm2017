// ===================================================================
// File: SALES_QUOTE.cs
// 2017/1/17: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.MyOffice
{
    public class SALES_QUOTE : EntityBase<string>
    {
        public SALES_QUOTE()
        {
            
        }

		public string ID  { get; set; }


		public string CustomerID  { get; set; }


		public string ContactID  { get; set; }


		public string ProductNo  { get; set; }


		public string Unit  { get; set; }


		public double? UnitPrice  { get; set; }


		public DateTime? CreateDate  { get; set; }


		public string Creator  { get; set; }


		public string CommText  { get; set; }


		public int? Status  { get; set; }


		public int RowID  { get; set; }

        
        
    }
    
    
}

