//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Collections.Generic;

using Quick.Framework.Tool;
using Ecomm.Domain.Models.MyOffice;
using Ecomm.Core.Repository.GPSPS;
using Ecomm.Site.Models;
using Ecomm.Site.Models.MyOffice.SALES_EBASKET;
using Quick.Framework.Common.SecurityHelper;
using Ecomm.Domain.Models.GPSPS;

namespace Ecomm.Core.Service.GPSPS
{
    /// <summary>
    /// 服务层实现 —— SALES_EBASKETService
    /// </summary>
    [Export(typeof(IDBService))]
    public class DBService : CoreServiceBase, IDBService
    {
        #region 属性

        [Import]
        public IDBRepository DBRepository { get; set; }
        #endregion

        public void GetFreightByCust(string cust, out float freight, out float admincost)
        {
            DBRepository.GetFreightByCust(cust, out freight, out admincost);
        }

        public IEnumerable<RM00102> GetRM00102(string custId, string shopId)
        {
            List<string> lt = new List<string>();
            if (!string.IsNullOrEmpty(custId))
            {
                lt.Add(string.Format("[CUSTNMBR] = '{0}'", custId));
            }
            if (!string.IsNullOrEmpty(shopId))
            {
                lt.Add(string.Format("[ADRSCODE] = '{0}'", shopId));
            }
            string strwhere = string.Empty;
            if (lt.Count > 0) strwhere = string.Join(" AND ", lt.ToArray());

            return DBRepository.GetRM00102(strwhere);
        }
        public IEnumerable<OrderItem> GetOrderItemStatusByPackslip(string packslip)
        {
            return DBRepository.GetOrderItemStatusByPackslip(packslip);
        }

        public IEnumerable<InvoiceItem> GetInvoiceLines(string invoiceNo, string soptype)
        {
            return DBRepository.GetInvoiceLines(invoiceNo, soptype);
        }

        public IEnumerable<InvoiceHeader> GetInvoiceHeader(string invoiceNo, string soptype)
        {
            return DBRepository.GetInvoiceHeader(invoiceNo, soptype);
        }
    }
}
