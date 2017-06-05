// ===================================================================
// File: SALES_EORDERS.cs
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
    public class SALES_EORDERS : EntityBase<string>
    {
        public SALES_EORDERS()
        {
            
        }

		public string ID  { get; set; }

        [NotMapped]
        public int RowID  { get; set; }


		public int? OrderType  { get; set; }


		public string CustomerID  { get; set; }


		public string ShipID  { get; set; }


		public double? Freight  { get; set; }


		public string ShipName  { get; set; }


		public string ShipAddress  { get; set; }


		public string ShipCity  { get; set; }


		public string ShipZip  { get; set; }


		public string ShipCountry  { get; set; }


		public string ShipState  { get; set; }


		public string ShipPhone  { get; set; }


		public string AuthCode  { get; set; }


		public string BillTitle  { get; set; }


		public string BillName  { get; set; }


		public string BillAddress  { get; set; }


		public string BillCity  { get; set; }


		public string BillState  { get; set; }


		public string BillZip  { get; set; }


		public string BillCountry  { get; set; }


		public string BillPhone  { get; set; }


		public string CommText  { get; set; }


		public string CreditCard  { get; set; }


		public string CcName  { get; set; }


		public string CcExpMonth  { get; set; }


		public string CcExpYear  { get; set; }


		public string CcNumber  { get; set; }


		public string CcType  { get; set; }


		public string VerifyWith  { get; set; }


		public string PurchaseNo  { get; set; }


		public DateTime? OrderDate  { get; set; }


		public DateTime? RequiredDate  { get; set; }


		public DateTime? ShippedDate  { get; set; }


		public DateTime? CreateDate  { get; set; }


		public DateTime? ModiDate  { get; set; }


		public string Creator  { get; set; }


		public string Modifier  { get; set; }


		public bool IsPrint  { get; set; }


		public int? ProcStatus  { get; set; }


		public int? Status  { get; set; }


		public string Item01  { get; set; }


		public string Item02  { get; set; }


		public string Item03  { get; set; }


		public string Item04  { get; set; }


		public string Item05  { get; set; }


		public string ContactID  { get; set; }


		public double? Miscellaneous  { get; set; }

        
        
    }


    [NotMapped]
    public class Order_Status
    {
        public string gSOPNUMBE { get; set; }

        public string PONO { get; set; }

        public DateTime? DOCDATE { get; set; }

        public string gCUSTNMBR { get; set; }

        public string gCUSTNAME { get; set; }

        public string PACKSLIP { get; set; }
        public string PROCSTEP { get; set; }
    }
    
}

