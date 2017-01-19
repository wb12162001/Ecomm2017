// ===================================================================
// File: SALES_VIEWED.cs
// 2017/1/17: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.MyOffice
{
    public class SALES_VIEWED : EntityBase<string>
    {
        public SALES_VIEWED()
        {
            
        }

		public string ID  { get; set; }


		public string ProductNo  { get; set; }


		public string CustomerID  { get; set; }


		public string ContactID  { get; set; }


		public DateTime? CreateDate  { get; set; }


		public DateTime? ModiDate  { get; set; }


		public string Creator  { get; set; }


		public string Modifier  { get; set; }


		public int RowID  { get; set; }

        
        
    }
    
    
}

