using System;
using Quick.Framework.Tool.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Domain.Models.GPSPS
{
    [NotMapped]
    public class OrderItem
    {
        public string ITEMNMBR { get; set; }

        public string ITEMDESC { get; set; }

        public string UOFM { get; set; }

        public string ITMCLSCD { get; set; }

        public decimal? Qty_Ordered { get; set; }

        public decimal? Qty_Shipped { get; set; }
        public decimal? Qty_BackOrdered { get; set; }
    }

    [NotMapped]
    public class InvoiceItem
    {
        public string ITEMNMBR { get; set; }
        public string ITEMDESC { get; set; }
        public decimal? QTY_ORDERED { get; set; }

        public decimal? QTY_SHIPPED { get; set; }
        public string UOFM { get; set; }
        public decimal? UNITPRCE { get; set; }

        public decimal? XTNDPRCE { get; set; }

    }


    [NotMapped]
    public class InvoiceHeader
    {
        public DateTime DOCDATE { get; set; }
        public string SOPNUMBE { get; set; }
        public string PCKSLPNO { get; set; }
        public int? MSTRNUMB { get; set; }
        public string ORIGNUMB { get; set; }
        public string CUSTNMBR { get; set; }
        public string CUSTNAME { get; set; }
        public string CSTPONBR { get; set; }

        public string SLPRSNID { get; set; }
        public string PRSTADCD { get; set; }
        public decimal? SUBTOTAL { get; set; }
        public decimal? MISCAMNT { get; set; }
        public decimal? FRTAMNT { get; set; }

        public decimal? TAXAMNT { get; set; }
        public decimal? DOCAMNT { get; set; }
        public string SHIP_ADDR1 { get; set; }
        public string SHIP_ADDR2 { get; set; }
        public string SHIP_CITY { get; set; }
        public string BILL_ADDR1 { get; set; }
        public string BILL_ADDR2 { get; set; }
        public string BILL_CITY { get; set; }

    }
}
