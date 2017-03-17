// ===================================================================
// File: PROD_MASTERCOMMON.cs
// 2017/2/6: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.Product
{
    public class PROD_MASTERCOMMON : EntityBase<string>
    {
        public PROD_MASTERCOMMON()
        {
            
        }

		public string ID  { get; set; }


		public string ProductNo  { get; set; }


		public string CommTitle  { get; set; }


		public string CommSummary  { get; set; }


		public string CommContent  { get; set; }


		public string Creator  { get; set; }


		public DateTime? CreateDate  { get; set; }


		public string Modifier  { get; set; }


		public DateTime? ModiDate  { get; set; }


		public int? Status  { get; set; }


		public string Item01  { get; set; }


		public string Item02  { get; set; }


		public string Item03  { get; set; }


		public string Item04  { get; set; }


		public string Item05  { get; set; }

        
        
    }
    
    
}

