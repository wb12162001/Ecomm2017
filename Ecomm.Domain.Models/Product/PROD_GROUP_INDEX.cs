// ===================================================================
// File: PROD_GROUP_INDEX.cs
// 2016/12/28: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Domain.Models.Product
{
    public class PROD_GROUP_INDEX : EntityBase<string>
    {
        public PROD_GROUP_INDEX()
        {
            this.ChildGroup = new List<PROD_GROUP_INDEX>();
        }
		public string ID  { get; set; }


		public string Name  { get; set; }


		public string Description  { get; set; }


		public string ParentID  { get; set; }


		public string ColorBg  { get; set; }


		public string ColorText  { get; set; }


		public string Picture  { get; set; }


		public int? DisplayOrder  { get; set; }


		public string Creator  { get; set; }


		public string Modifier  { get; set; }


		public DateTime? CreateDate  { get; set; }


		public DateTime? Modidate  { get; set; }


		public int? Status  { get; set; }


		public string Item01  { get; set; }


		public string Item02  { get; set; }


		public string Item03  { get; set; }


		public string Item04  { get; set; }


		public string Item05  { get; set; }

        [ForeignKey("ParentID")]
        public virtual PROD_GROUP_INDEX ParentGroup { get; set; }
        public virtual ICollection<PROD_GROUP_INDEX> ChildGroup { get; set; }
    }
}

