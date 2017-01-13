// ===================================================================
// File: UpdateSALES_EORDERSModel.cs
// 2017/1/12: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using Quick.Site.Common.Models;
using System.Web.Mvc;
using Quick.Site.Common;

namespace Ecomm.Site.Models.MyOffice.SALES_EORDERS
{
    public class UpdateSALES_EORDERSModel : EntityCommon
    {
        public UpdateSALES_EORDERSModel()
        {
        }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID can not be empty")]
		public string ID  { get; set; }


        [Display(Name = "RowID")]
        [Required(ErrorMessage = "RowID can not be empty")]
		public int RowID  { get; set; }


        [Display(Name = "OrderType")]
		public int? OrderType  { get; set; }


        [Display(Name = "CustomerID")]
		public string CustomerID  { get; set; }


        [Display(Name = "ShipID")]
		public string ShipID  { get; set; }


        [Display(Name = "Freight")]
		public double? Freight  { get; set; }


        [Display(Name = "ShipName")]
		public string ShipName  { get; set; }


        [Display(Name = "ShipAddress")]
		public string ShipAddress  { get; set; }


        [Display(Name = "ShipCity")]
		public string ShipCity  { get; set; }


        [Display(Name = "ShipZip")]
		public string ShipZip  { get; set; }


        [Display(Name = "ShipCountry")]
		public string ShipCountry  { get; set; }


        [Display(Name = "ShipState")]
		public string ShipState  { get; set; }


        [Display(Name = "ShipPhone")]
		public string ShipPhone  { get; set; }


        [Display(Name = "AuthCode")]
		public string AuthCode  { get; set; }


        [Display(Name = "BillTitle")]
		public string BillTitle  { get; set; }


        [Display(Name = "BillName")]
		public string BillName  { get; set; }


        [Display(Name = "BillAddress")]
		public string BillAddress  { get; set; }


        [Display(Name = "BillCity")]
		public string BillCity  { get; set; }


        [Display(Name = "BillState")]
		public string BillState  { get; set; }


        [Display(Name = "BillZip")]
		public string BillZip  { get; set; }


        [Display(Name = "BillCountry")]
		public string BillCountry  { get; set; }


        [Display(Name = "BillPhone")]
		public string BillPhone  { get; set; }


        [Display(Name = "CommText")]
		public string CommText  { get; set; }


        [Display(Name = "CreditCard")]
		public string CreditCard  { get; set; }


        [Display(Name = "CcName")]
		public string CcName  { get; set; }


        [Display(Name = "CcExpMonth")]
		public string CcExpMonth  { get; set; }


        [Display(Name = "CcExpYear")]
		public string CcExpYear  { get; set; }


        [Display(Name = "CcNumber")]
		public string CcNumber  { get; set; }


        [Display(Name = "CcType")]
		public string CcType  { get; set; }


        [Display(Name = "VerifyWith")]
		public string VerifyWith  { get; set; }


        [Display(Name = "PurchaseNo")]
		public string PurchaseNo  { get; set; }


        [Display(Name = "OrderDate")]
		public DateTime? OrderDate  { get; set; }


        [Display(Name = "RequiredDate")]
		public DateTime? RequiredDate  { get; set; }


        [Display(Name = "ShippedDate")]
		public DateTime? ShippedDate  { get; set; }


        [Display(Name = "CreateDate")]
		public DateTime? CreateDate  { get; set; }


        [Display(Name = "ModiDate")]
		public DateTime? ModiDate  { get; set; }


        [Display(Name = "Creator")]
		public string Creator  { get; set; }


        [Display(Name = "Modifier")]
		public string Modifier  { get; set; }


        [Display(Name = "IsPrint")]
		public bool IsPrint  { get; set; }


        [Display(Name = "ProcStatus")]
		public int? ProcStatus  { get; set; }


        [Display(Name = "Status")]
		public int? Status  { get; set; }


        [Display(Name = "Item01")]
		public string Item01  { get; set; }


        [Display(Name = "Item02")]
		public string Item02  { get; set; }


        [Display(Name = "Item03")]
		public string Item03  { get; set; }


        [Display(Name = "Item04")]
		public string Item04  { get; set; }


        [Display(Name = "Item05")]
		public string Item05  { get; set; }


        [Display(Name = "ContactID")]
		public string ContactID  { get; set; }


        [Display(Name = "Miscellaneous")]
		public double? Miscellaneous  { get; set; }

    }
    
}

