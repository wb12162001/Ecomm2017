// ===================================================================
// File: PROD_RELATED_PROPERTY.cs
// 2017/2/6: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.Product
{
    public class PROD_RELATED_PROPERTY : EntityBase<string>
    {
        public PROD_RELATED_PROPERTY()
        {
            
        }

		public string ProductNo  { get; set; }


		public string PropertyID  { get; set; }


		public int CLevel  { get; set; }

        
        
    }
    
    
}

