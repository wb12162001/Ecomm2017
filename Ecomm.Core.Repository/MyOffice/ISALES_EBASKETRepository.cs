//------------------------------------------------------------------------------
// <copyright file="ISALES_EBASKETRepository.cs">
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
    /// 仓储操作层接口 —— SALES_EBASKET 
    /// </summary>
    public interface ISALES_EBASKETRepository : IRepository<SALES_EBASKET>
    {
        IEnumerable<SALES_EBASKET> GetEntitiesBySql();
        int UpdateEBasketQuantity(string custId, string contactId, string proNo, float quantity);
        int ModificationByProce(SALES_EBASKET oSALES_EBASKETInfo);

        IEnumerable<SALES_EBASKET_MASTER> QueryEntities(int count, string strWhere, string strOrder);
    }
}

