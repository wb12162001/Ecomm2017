// ===================================================================
// File: SYS_PROPERTY.cs
// 2017/1/5: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.SysConfig
{
    public class SYS_PROPERTY : EntityBase<string>
    {
        public SYS_PROPERTY()
        {
            
        }

		public string PropertyID  { get; set; }


		public string PropertyName  { get; set; }


		public string Remark  { get; set; }


		public int? Status  { get; set; }

        
        
    }
    
    
}

