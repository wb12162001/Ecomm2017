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

        public double Qty_Ordered { get; set; }

        public double Qty_Shipped { get; set; }
        public double Qty_BackOrdered { get; set; }
    }
}
