//------------------------------------------------------------------------------
// <copyright file="ISALES_ESIORDERFORMRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/1/17
// </copyright>
//------------------------------------------------------------------------------
using System;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.MyOffice;
using System.Collections.Generic;

namespace Ecomm.Core.Repository.MyOffice
{
	/// <summary>
    /// 仓储操作层接口 —— SALES_ESIORDERFORM 
    /// </summary>
    public interface ISALES_ESIORDERFORMRepository : IRepository<SALES_ESIORDERFORM>
    {
        IEnumerable<SALES_ESIORDERFORM_MASTER> QueryEntities(int count, string strWhere, string strOrder);
    }
}

