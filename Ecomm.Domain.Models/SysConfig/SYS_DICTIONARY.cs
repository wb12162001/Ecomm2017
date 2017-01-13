// ===================================================================
// File: SYS_DICTIONARY.cs
// 2017/1/5: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.SysConfig
{
    public class SYS_DICTIONARY : EntityBase<string>
    {
        public SYS_DICTIONARY()
        {
            
        }

		public string DictionaryName  { get; set; }


		public int DictionaryValue  { get; set; }


		public string Remark  { get; set; }

        
        
    }
    
    
}

