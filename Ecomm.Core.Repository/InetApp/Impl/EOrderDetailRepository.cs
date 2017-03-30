﻿//------------------------------------------------------------------------------
// <copyright file="EOrderDetailRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/3/22
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.InetApp;
using System.Collections.Generic;

namespace Ecomm.Core.Repository.InetApp
{
	/// <summary>
    /// 仓储操作层接口 —— EOrderDetail 
    /// </summary>
    [Export(typeof(IEOrderDetailRepository))]
    public class EOrderDetailRepository : EFRepositoryBase<EOrderDetail>, IEOrderDetailRepository
    {
        public EOrderDetailRepository() : base("inetapp")
        {
        }

        public IEnumerable<EOrderDetail_MASTER> QueryEntities(int orderId)
        {
            System.Data.SqlClient.SqlParameter[] parameters = {
               new System.Data.SqlClient.SqlParameter("@orderId",orderId),
            };
            string sql = "select a*, f0.ITEMDESC as ProductName from dbo.EOrderDetails a left join dbo.EPRODUCTS f0 on a.Sku=f0.ITEMNMBR where a.OrderID=@orderId";
            return base.ExcuteQuery<EOrderDetail_MASTER>(sql, parameters);
        }
    }
}

