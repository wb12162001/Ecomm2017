// ===================================================================
// File: EOrder.cs
// 2017/3/22: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Domain.Models.InetApp
{
    public class EOrder : EntityBase<int>  //这里要修改,因为它是int
    {
        public EOrder()
        {
            
        }

		public short? OrderType  { get; set; }
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] //产生递增 [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID  { get; set; }

		public short? ORIGTYPE  { get; set; }


		public string ORIGNUMB  { get; set; }


		public string BACHNUMB  { get; set; }


		public string CustID  { get; set; }


		public string ShopID  { get; set; }


		public string EmplID  { get; set; }


		public DateTime? OrderDate  { get; set; }


		public DateTime? RequiredDate  { get; set; }


		public DateTime? ShippedDate  { get; set; }


		public string ShipID  { get; set; }


		public decimal? Freight  { get; set; }


		public string Ship_Name  { get; set; }


		public string Ship_Address  { get; set; }


		public string Ship_City  { get; set; }


		public string TerrID  { get; set; }


		public string Ship_zip  { get; set; }


		public string Ship_Country  { get; set; }


		public string Ship_state  { get; set; }


		public string Ship_phone  { get; set; }


		public string Auth_code  { get; set; }


		public string Bill_name  { get; set; }


		public string Bill_address  { get; set; }


		public string Bill_city  { get; set; }


		public string Bill_state  { get; set; }


		public string Bill_zip  { get; set; }


		public string Bill_country  { get; set; }


		public string Bill_phone  { get; set; }


		public string RepID  { get; set; }


		public short? OrderStats  { get; set; }


		public short? VoidStats  { get; set; }


		public string CommText  { get; set; }


		public DateTime? CretDate  { get; set; }


		public DateTime? ModiDate  { get; set; }


		public string CretID  { get; set; }


		public string Cc_name  { get; set; }


		public int? Cc_expmonth  { get; set; }


		public int? Cc_expyear  { get; set; }


		public string Cc_number  { get; set; }


		public string Cc_type  { get; set; }


		public string Verify_with  { get; set; }


		public string Pono  { get; set; }


		public short? Prnstats  { get; set; }


		public byte? PROC_STATUS  { get; set; }


		public decimal? Miscellaneous  { get; set; }

        
        
    }
    
    [NotMapped]
    public class NoMapping_Eorder: EOrder
    {

    }
}

