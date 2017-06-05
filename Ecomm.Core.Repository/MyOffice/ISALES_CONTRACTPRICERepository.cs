//------------------------------------------------------------------------------
// <copyright file="ISALES_CONTRACTPRICERepository.cs">
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
    /// 仓储操作层接口 —— SALES_CONTRACTPRICE 
    /// </summary>
    public interface ISALES_CONTRACTPRICERepository : IRepository<SALES_CONTRACTPRICE>
    {
        IEnumerable<ContractPrice_PAGE_MASTER> GetContractPric(string strwhere, string orderby, int pagesize, int pageIndex, out int totalCount);
    }
}

