// ===================================================================
// File: PROD_GROUP_ITEM.cs
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
    public class PROD_GROUP_ITEM : EntityBase<string>
    {
        public PROD_GROUP_ITEM()
        {
        }

		public string ProductID  { get; set; }

		public string GROUP_INDEX  { get; set; }


		public string Notes  { get; set; }


		public string Picture  { get; set; }


		public byte? Status  { get; set; }

        [ForeignKey("ProductID")]
        public virtual PROD_MASTER Product { get; set; }

        [ForeignKey("GROUP_INDEX")]
        public virtual PROD_GROUP_INDEX Group { get; set; }
    }
}

