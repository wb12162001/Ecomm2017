using System;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.MyOffice;
using System.Collections.Generic;
using Ecomm.Domain.Models.GPSPS;

namespace Ecomm.Core.Repository.GPSPS
{
    /// <summary>
    /// 仓储操作层接口 —— IDBRepository 
    /// </summary>
    public interface IDBRepository : IRepository<DBNull>
    {
        void GetFreightByCust(string cust, out float freight, out float admincost);

        IEnumerable<RM00102> GetRM00102(string strWhere);

        IEnumerable<OrderItem> GetOrderItemStatusByPackslip(string packslip);
    }
}
