//------------------------------------------------------------------------------
// <copyright file="ISALES_EORDERDETAILSRepository.cs">
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
    /// 仓储操作层接口 —— SALES_EORDERDETAILS 
    /// </summary>
    public interface ISALES_EORDERDETAILSRepository : IRepository<SALES_EORDERDETAILS>
    {
        IEnumerable<SALES_EORDERDETAILS_MASTER> QueryEntities(int count, string strWhere, string strOrder);
    }
}

