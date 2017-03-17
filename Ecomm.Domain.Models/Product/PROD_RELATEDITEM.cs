// ===================================================================
// File: PROD_RELATEDITEM.cs
// 2017/2/6: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecomm.Domain.Models.Product
{
    public class PROD_RELATEDITEM : EntityBase<string>
    {
        public PROD_RELATEDITEM()
        {
            
        }

		public string ProductNo  { get; set; }


		public string RelatedID  { get; set; }


		public short? Ranking  { get; set; }

        //[ForeignKey("RelatedID")]
        //public virtual PROD_MASTER Product { get; set; }

    }

    public class PROD_RELATEDITEM_MASTER : PROD_RELATEDITEM
    {

        public string ID { get; set; }
        public string RELATD_ProductNo { get; set; }


        public string ProductName { get; set; }
        public string SmallPic { get; set; }
        public string BigPic { get; set; }
        public string CategoryCode { get; set; }
        public string BaseUOFM { get; set; }
        public string StockType { get; set; }
        public double? ListPrice { get; set; }

        public double? SpecialPrice { get; set; }

    }



}

