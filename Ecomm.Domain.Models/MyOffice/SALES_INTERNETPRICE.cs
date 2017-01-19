// ===================================================================
// File: SALES_INTERNETPRICE.cs
// 2017/1/17: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.MyOffice
{
    public class SALES_INTERNETPRICE : EntityBase<string>
    {
        public SALES_INTERNETPRICE()
        {
            
        }

		public string CustomerID  { get; set; }


		public string ProductNo  { get; set; }


		public decimal? IPrice  { get; set; }


		public byte? Status  { get; set; }

        
        
    }
    
    
}

