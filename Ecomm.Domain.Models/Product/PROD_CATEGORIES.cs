// ===================================================================
// File: PROD_CATEGORIES.cs
// 2017/2/6: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Domain.Models.Product
{
    public class PROD_CATEGORIES : EntityBase<string>
    {
        public PROD_CATEGORIES()
        {
            this.ProductList = new List<PROD_MASTER>();
            this.ChildCategory = new List<PROD_CATEGORIES>();
        }

		public string ID  { get; set; }


		public string CategoryName  { get; set; }


		public string CategoryCode  { get; set; }


		public string Description  { get; set; }


		public string ParentID  { get; set; }


		public string ColorBg  { get; set; }


		public string ColorText  { get; set; }


		public string Picture  { get; set; }


		public string SmallPic  { get; set; }


		public string BigPic  { get; set; }


		public int? CLevel  { get; set; }


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


		public string MenuAlias  { get; set; }


		public bool IsAvailably  { get; set; }

        [ForeignKey("ParentID")]
        public virtual PROD_CATEGORIES ParentCategory { get; set; }

        public virtual ICollection<PROD_CATEGORIES> ChildCategory { get; set; }


        public virtual ICollection<PROD_MASTER> ProductList { get; set; }

    }
    
    
}

