//------------------------------------------------------------------------------
// <copyright file="IEOrderRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/3/22
// </copyright>
//------------------------------------------------------------------------------
using System;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.InetApp;
using System.Collections.Generic;

namespace Ecomm.Core.Repository.InetApp
{
	/// <summary>
    /// 仓储操作层接口 —— EOrder 
    /// </summary>
    public interface IEOrderRepository : IRepository<EOrder>
    {
        int InsertOrder(EOrder EOrderInfo);

        IEnumerable<double> GetOrdersByCurrentMonth(string custId, string shipId, DateTime orderDt);
        IEnumerable<double> GetOrdersByCurrentMonth(string custId, string shipId);
    }
}

