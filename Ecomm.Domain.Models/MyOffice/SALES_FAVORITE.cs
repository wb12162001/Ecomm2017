// ===================================================================
// File: SALES_FAVORITE.cs
// 2017/1/17: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Domain.Models.MyOffice
{
    public class SALES_FAVORITE : EntityBase<string>
    {
        public SALES_FAVORITE()
        {
            
        }

		public string ID  { get; set; }


		public string FavFolderID  { get; set; }


		public string ProductNo  { get; set; }


		public string CustomerID  { get; set; }


		public string ContactID  { get; set; }


		public DateTime? CreateDate  { get; set; }


		public DateTime? ModiDate  { get; set; }


		public string Creator  { get; set; }


		public string Modifier  { get; set; }


		public int? Status  { get; set; }

        
        
    }

    [NotMapped]
    public class SALES_FAVORITE_MASTER:SALES_FAVORITE
    {
        public string ProductName { get; set; }
        public int ProductType { get; set; }
        public string ProductID { get; set; }

        public double? ListPrice { get; set; }
        public double? SpecialPrice { get; set; }

        public string CategoryCode { get; set; }
        public string BaseUOFM { get; set; }
        public string Description { get; set; }
        public string StockType { get; set; }
        public string SmallPic { get; set; }
        public string BigPic { get; set; }

        public string FolderName { get; set; }

        public string Item04 { get; set; }

        public string CategoryName { get; set; }
        public string MenuAlias { get; set; }
    }
    
}

