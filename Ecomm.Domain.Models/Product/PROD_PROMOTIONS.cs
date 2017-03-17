// ===================================================================
// File: PROD_PROMOTIONS.cs
// 2017/2/6: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.Product
{
    public class PROD_PROMOTIONS : EntityBase<string>
    {
        public PROD_PROMOTIONS()
        {
            
        }

		public string ID  { get; set; }


		public string ProductNo  { get; set; }


		public string Title  { get; set; }


		public string ImgFile  { get; set; }


		public string Description  { get; set; }


		public string FootNote  { get; set; }


		public string SortNo  { get; set; }


		public DateTime? CreateDate  { get; set; }


		public int? Status  { get; set; }

        
        
    }
    
    
}

