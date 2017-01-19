// ===================================================================
// File: Rela_location_limit.cs
// 2017/1/16: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.EpSnell
{
    public class Rela_location_limit : EntityBase<string>
    {
        public Rela_location_limit()
        {
            
        }

		public string Account_no  { get; set; }


		public string Address_id  { get; set; }


		public double? Month_quota  { get; set; }


		public double? Month_sales  { get; set; }

        
        
    }
    
    
}

