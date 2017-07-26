//------------------------------------------------------------------------------
// <copyright file="ISALES_EORDERSService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/12 16:18:05
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.MyOffice;
using Ecomm.Site.Models.MyOffice.SALES_EORDERS;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.MyOffice
{
	/// <summary>
    /// 服务层接口 —— ISALES_EORDERSService
    /// </summary>
    public interface ISALES_EORDERSService
    {
		#region 属性

        IQueryable<SALES_EORDERS> SALES_EORDERSList { get; }

        #endregion

        #region 公共方法
        int Insert2(SALES_EORDERSModel model);
        OperationResult Insert(SALES_EORDERSModel model);
        OperationResult Update(SALES_EORDERSModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  ID);

        double GetOrdersByCurrentMonth(string custId, string shipId);

        IEnumerable<Order_Status> GetOrderStatus(string Custid);
        IEnumerable<OrderSalesByCustidByloca> GetsalesByCustidByloca(string Custid, string date1, string date2);

        IEnumerable<OrderSalesByClasalesModel> GetClasalesByCustid(string Custid, string date1, string date2, string loca);

        IEnumerable<OrderSalesByClasalesProductModel> GetclasalesByCustidByAllprod(string Custid, string date1, string date2, string loca);

        IEnumerable<OrderSalesByClasalesProductModel> GetclasalesByCustidByprod(string Custid, string date1, string date2, string itclass, string loca);

        IEnumerable<OrderInvByProdModel> GetInvByProd(string Custid, string itmembr, string date1, string date2);

        IEnumerable<OrderLocaByuseridModel> GetLocaByuserid(string Custid, string userId);

        IEnumerable<InvByCustidModel> GetInvByCustid(string Custid, string dateFrom, string dateTo, string searchKey, string type);
        IEnumerable<InvoiceDetailModel> GetInvdetailByCustid(string Custid, string invoiceNo, int invoiceType);
        string GetStatus(object status);
        #endregion
    }
}

