//------------------------------------------------------------------------------
// <copyright file="IEOrderService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/3/22 15:19:02
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.InetApp;
using Ecomm.Site.Models.InetApp.EOrder;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.InetApp
{
	/// <summary>
    /// 服务层接口 —— IEOrderService
    /// </summary>
    public interface IEOrderService
    {
		#region 属性

        IQueryable<EOrder> EOrderList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(EOrderModel model);
        OperationResult Update(EOrderModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(int  OrderID);

        int InsertOrder(EOrderModel model);

        /// <summary>
        /// 获取hold 系统当前月的订单
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="shipId"></param>
        /// <param name="orderDt"></param>
        /// <returns></returns>
        IEnumerable<double> GetOrdersByCurrentMonth(string custId, string shipId);
        #endregion
    }
}

