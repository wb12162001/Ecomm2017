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

        public string ID { get; set; }

        [NotMapped]
        public int RowID { get; set; }


        public int? OrderType { get; set; }


        public string CustomerID { get; set; }


        public string ShipID { get; set; }


        public double? Freight { get; set; }


        public string ShipName { get; set; }


        public string ShipAddress { get; set; }


        public string ShipCity { get; set; }


        public string ShipZip { get; set; }


        public string ShipCountry { get; set; }


        public string ShipState { get; set; }


        public string ShipPhone { get; set; }


        public string AuthCode { get; set; }


        public string BillTitle { get; set; }


        public string BillName { get; set; }


        public string BillAddress { get; set; }


        public string BillCity { get; set; }


        public string BillState { get; set; }


        public string BillZip { get; set; }


        public string BillCountry { get; set; }


        public string BillPhone { get; set; }


        public string CommText { get; set; }


        public string CreditCard { get; set; }


        public string CcName { get; set; }


        public string CcExpMonth { get; set; }


        public string CcExpYear { get; set; }


        public string CcNumber { get; set; }


        public string CcType { get; set; }


        public string VerifyWith { get; set; }


        public string PurchaseNo { get; set; }


        public DateTime? OrderDate { get; set; }


        public DateTime? RequiredDate { get; set; }


        public DateTime? ShippedDate { get; set; }


        public DateTime? CreateDate { get; set; }


        public DateTime? ModiDate { get; set; }


        public string Creator { get; set; }


        public string Modifier { get; set; }


        public bool IsPrint { get; set; }


        public int? ProcStatus { get; set; }


        public int? Status { get; set; }


        public string Item01 { get; set; }


        public string Item02 { get; set; }


        public string Item03 { get; set; }


        public string Item04 { get; set; }


        public string Item05 { get; set; }


        public string ContactID { get; set; }


        public double? Miscellaneous { get; set; }



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

    [NotMapped]
    public class OrderSalesByCustidByloca
    {
        public string PRSTADCD { get; set; }
        public Double? PRICE { get; set; }
        public int ORDERS { get; set; }

        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }

        public string CITY { get; set; }
        public string PHONE1 { get; set; }
        public string FAX { get; set; }
        public string CNTCPRSN { get; set; }
    }

    [NotMapped]
    public class OrderSalesByClasalesModel
    {
        public string ITCLASS { get; set; }
        public string CUSTNMBR { get; set; }
        public Double? PRICE { get; set; }
        public Double? ORDERS { get; set; }
    }

    [NotMapped]
    public class OrderSalesByClasalesProductModel
    {
        public string ITEMNMBR { get; set; }
        public string ITEMDESC { get; set; }
        public string UOFM { get; set; }
        public string CUSTNMBR { get; set; }

        public Double? PRICE { get; set; }
        public Double? QTY { get; set; }
        public Double? ORDERS { get; set; }
        public string CLASS1 { get; set; }
        public string CLASS3 { get; set; }
        public string CLASS6 { get; set; }
    }
    [NotMapped]
    public class OrderInvByProdModel
    {
        public Int16? SOPTYPE { get; set; }
        public string SOPNUMBE { get; set; }
        public Int16? ORIGTYPE { get; set; }
        public string ORIGNUMB { get; set; }
        public string CUSTNMBR { get; set; }
        public string SLPRSNID { get; set; }
        public int? IYEAR { get; set; }
        public int? IMONTH { get; set; }
        public int? IDAY { get; set; }
        public string ITEMNMBR { get; set; }
        public Decimal? QTYBSUOM { get; set; }
        public Decimal? QUANTITY { get; set; }
        public Decimal? UNITCOST { get; set; }
        public Decimal? EXTDCOST { get; set; }
        public Decimal? XTNDPRCE { get; set; }
        public string DOCID { get; set; }
        public DateTime IDATE { get; set; }
        public DateTime CREATDDT { get; set; }
        public string USERDEF1 { get; set; }
        public int? DEX_ROW_ID { get; set; }
        public string CSTPONBR { get; set; }
        public int? TABLEID { get; set; }
        public int? STATUS { get; set; }
        public int? TCOST { get; set; }
        public DateTime PTIME { get; set; }
        public int? GP { get; set; }
        public string LOCNCODE { get; set; }
        public string UOFM { get; set; }
        public string PRSTADCD { get; set; }
        public string BACHNUMB { get; set; }
        public string BCHSOURC { get; set; }
        public string PRCLEVEL { get; set; }
        public int? MSTRNUMB { get; set; }
        public string PRBTADCD { get; set; }
        public string SHIPMTHD { get; set; }
        public Decimal? SUBTOTAL { get; set; }
        public Decimal? TAXAMNT { get; set; }
        public Decimal? DOCAMNT { get; set; }
        public Decimal? ACCTAMNT { get; set; }
        public string SALSTERR { get; set; }
        public string USER2ENT { get; set; }
        public Decimal? FRTAMNT { get; set; }
        public Decimal? MISCAMNT { get; set; }
    }

    [NotMapped]
    public class InvoiceDetailModel: OrderInvByProdModel
    {
        public string ProductName { get; set; }
        public string CLASS1 { get; set; }
        public string ProdGroupID { get; set; }
    }

    [NotMapped]
    public class InvByCustidModel
    {
        public Int16? SOPTYPE { get; set; }
        public string SOPNUMBE { get; set; }
        public string CSTPONBR { get; set; }
        public DateTime? IDATE { get; set; }
        public Decimal? XTNDPRCE { get; set; }
        public Decimal? TAXAMNT { get; set; }
        public Decimal? FRTAMNT { get; set; }
        public Decimal? MISCAMNT { get; set; }
    }


    [NotMapped]
    public class OrderLocaByuseridModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string CITY { get; set; }
        public string CNTCPRSN { get; set; }
        public string contact_id { get; set; }
    }
}

