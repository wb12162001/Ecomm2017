using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.MyOffice;
using Ecomm.Site.Models.MyOffice.SALES_EBASKET;
using System.Collections.Generic;
using Quick.Site.Common.Models;
using Ecomm.Domain.Models.GPSPS;

namespace Ecomm.Core.Service.GPSPS
{
    public interface IDBService
    {
        void GetFreightByCust(string cust, out float freight, out float admincost);
        IEnumerable<RM00102> GetRM00102(string custId, string shopId);

        IEnumerable<OrderItem> GetOrderItemStatusByPackslip(string packslip);

        IEnumerable<InvoiceItem> GetInvoiceLines(string invoiceNo, string soptype);

        IEnumerable<InvoiceHeader> GetInvoiceHeader(string invoiceNo, string soptype);
    }
}
