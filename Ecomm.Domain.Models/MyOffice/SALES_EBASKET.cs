// ===================================================================
// File: SALES_EBASKET.cs
// 2017/1/12: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecomm.Domain.Models.MyOffice
{
    public class SALES_EBASKET : EntityBase<string>
    {
        public SALES_EBASKET()
        {
            
        }

		public string ID  { get; set; }


		public string CustomerID  { get; set; }


		public string ContactID  { get; set; }


		public string ProductNo  { get; set; }


		public double Quantity  { get; set; }


		public double? UnitPrice  { get; set; }


		public string Unit  { get; set; }


		public string Creator  { get; set; }


		public string Modifier  { get; set; }


		public DateTime? CreateDate  { get; set; }


		public DateTime? ModiDate  { get; set; }


		public string MakeOrderID  { get; set; }

        [NotMapped]
        public int RowID  { get; set; }


		public int? Status  { get; set; }


		public string UnitPType  { get; set; }

        //[ForeignKey("ProductNo")]
        //public virtual Models.Product.PROD_MASTER ProductInfo { get; set; }

    }
    /// <summary>
    /// 因为是SP去使用的数据对象,所以要使用NotMapped,不然它会EF加载映射表,但其实没有;
    /// </summary>
    [NotMapped]
    public class SALES_EBASKET_MASTER: SALES_EBASKET
    {
        public string ProductName { get; set; }
        public string ProductPic { get; set; }
        public string ProductID { get; set; }
    }
}

