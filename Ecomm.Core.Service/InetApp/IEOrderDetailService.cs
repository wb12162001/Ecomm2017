//------------------------------------------------------------------------------
// <copyright file="IEOrderDetailService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/3/22 15:19:02
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.InetApp;
using Ecomm.Site.Models.InetApp.EOrderDetail;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.InetApp
{
	/// <summary>
    /// 服务层接口 —— IEOrderDetailService
    /// </summary>
    public interface IEOrderDetailService
    {
		#region 属性

        IQueryable<EOrderDetail> EOrderDetailList { get; }

        #endregion

        #region 公共方法
        IEnumerable<EOrderDetail_MASTER> QueryEntities(int orderId);
        OperationResult Insert(EOrderDetailModel model);

        int InsertEOrderDetail(EOrderDetailModel model);

        OperationResult Update(UpdateEOrderDetailModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(int  OrderID,string  Sku);


        void UpdateOrderDetailQty(int orderID, string sku, float qty);
        int DeleteOrderDetail(int orderID, string sku);
        #endregion
    }
}

