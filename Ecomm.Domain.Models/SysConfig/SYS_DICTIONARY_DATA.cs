// ===================================================================
// File: SYS_DICTIONARY_DATA.cs
// 2017/1/5: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Domain.Models.SysConfig
{
    public class SYS_DICTIONARY_DATA : EntityBase<string>
    {
        public SYS_DICTIONARY_DATA()
        {
            
        }

		public string ID  { get; set; }


		public int DictionaryValue  { get; set; }

        [ForeignKey("DictionaryValue")]
        public virtual SYS_DICTIONARY Dictionary { get; set; }


        public string DictDataName  { get; set; }


		public string DictDataValue  { get; set; }


		public string DictDataType  { get; set; }


		public bool IsFixed  { get; set; }


		public bool IsCancel  { get; set; }


		public string DictParentID  { get; set; }


		public DateTime? CreateDate  { get; set; }


		public DateTime? ModiDate  { get; set; }


		public string Remark  { get; set; }


		public int? DisplayOrder  { get; set; }

        
        
    }
    
    
}

