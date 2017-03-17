// ===================================================================
// File: PROD_PROPERTIES.cs
// 2017/2/6: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.Product
{
    public class PROD_PROPERTIES : EntityBase<string>
    {
        public PROD_PROPERTIES()
        {
            
        }

		public string ID  { get; set; }


		public string ProductNo  { get; set; }


		public string PropertyID  { get; set; }


		public string PropertyValue  { get; set; }


		public int? PLevel  { get; set; }


		public string ParentID  { get; set; }


		public string RelationCode  { get; set; }


		public int RowID  { get; set; }


		public string RealProductNo  { get; set; }


		public int? DisplayOrder  { get; set; }


		public string Remark  { get; set; }


		public int? Status  { get; set; }

        
        
    }
    
    
}

