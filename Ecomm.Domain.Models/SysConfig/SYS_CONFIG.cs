// ===================================================================
// File: SYS_CONFIG.cs
// 2017/1/5: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.SysConfig
{
    public class SYS_CONFIG : EntityBase<string>
    {
        public SYS_CONFIG()
        {
            
        }

		public string ID  { get; set; }


		public string ConfigName  { get; set; }


		public string ConfigContent  { get; set; }


		public string FieldProperty  { get; set; }


		public bool IsSystem  { get; set; }

        
        
    }
    
    
}

