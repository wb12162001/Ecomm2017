// ===================================================================
// File: INFOR_CATEGORIES.cs
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
    public class INFOR_CATEGORIES : EntityBase<string>
    {
        public INFOR_CATEGORIES()
        {
            this.ChildCategory = new List<INFOR_CATEGORIES>();
        }

		public string ID  { get; set; }


		public string InforCategoryName  { get; set; }


		public int? DisplayOrder  { get; set; }


		public string ParentID  { get; set; }

        [ForeignKey("ParentID")]
        public virtual INFOR_CATEGORIES ParentCategory { get; set; }

        public virtual ICollection<INFOR_CATEGORIES> ChildCategory { get; set; }


        public int? Clevel  { get; set; }


		public int? Status  { get; set; }


		public string Item01  { get; set; }


		public string Item02  { get; set; }


		public string Item03  { get; set; }


		public string Item04  { get; set; }


		public string Item05  { get; set; }

        
        
    }
    
    
}

