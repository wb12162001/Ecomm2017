//------------------------------------------------------------------------------
// <copyright file="ISALES_EORDERSRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/1/12
// </copyright>
//------------------------------------------------------------------------------
using System;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.MyOffice;
using System.Collections.Generic;

namespace Ecomm.Core.Repository.MyOffice
{
	/// <summary>
    /// 仓储操作层接口 —— SALES_EORDERS 
    /// </summary>
    public interface ISALES_EORDERSRepository : IRepository<SALES_EORDERS>
    {
        double GetOrdersByCurrentMonth(string custId, string shipId);

        IEnumerable<Order_Status> GetOrderStatus(string Custid);

        IEnumerable<OrderSalesByCustidByloca> GetsalesByCustidByloca(string Custid, string date1, string date2);

        IEnumerable<OrderSalesByClasalesModel> GetClasalesByCustid(string Custid, string date1, string date2, string loca);
        IEnumerable<OrderSalesByClasalesProductModel> GetclasalesByCustidByAllprod(string Custid, string date1, string date2, string loca);

        IEnumerable<OrderSalesByClasalesProductModel> GetclasalesByCustidByprod(string Custid, string date1, string date2, string itclass, string loca);

        IEnumerable<OrderLocaByuseridModel> GetLocaByuserid(string Custid, string userId);
        IEnumerable<OrderInvByProdModel> GetInvByProd(string Custid, string itmembr, string date1, string date2);

        IEnumerable<InvByCustidModel> GetInvByCustid(string Custid, string dateFrom, string dateTo, string searchKey, string type);
        IEnumerable<InvoiceDetailModel> GetInvdetailByCustid(string Custid, string invoiceNo, int invoiceType);
    }
}

