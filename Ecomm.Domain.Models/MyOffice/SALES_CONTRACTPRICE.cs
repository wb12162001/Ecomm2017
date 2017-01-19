// ===================================================================
// File: SALES_CONTRACTPRICE.cs
// 2017/1/17: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.MyOffice
{
    public class SALES_CONTRACTPRICE : EntityBase<string>
    {
        public SALES_CONTRACTPRICE()
        {
            
        }

		public string CustomerID  { get; set; }


		public string ProductNo  { get; set; }


		public double ContractPrice  { get; set; }


		public string Creator  { get; set; }


		public string Modifier  { get; set; }


		public DateTime? CreateDate  { get; set; }


		public DateTime? ModiDate  { get; set; }


		public int? Status  { get; set; }


		public int RowID  { get; set; }

        
        
    }
    
    
}

