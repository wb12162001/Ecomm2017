//------------------------------------------------------------------------------
// <copyright file="IPROD_RELATEDITEMRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/2/6
// </copyright>
//------------------------------------------------------------------------------
using System;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.Product;
using System.Collections.Generic;

namespace Ecomm.Core.Repository.Product
{
	/// <summary>
    /// 仓储操作层接口 —— PROD_RELATEDITEM 
    /// </summary>
    public interface IPROD_RELATEDITEMRepository : IRepository<PROD_RELATEDITEM>
    {
        IEnumerable<PROD_RELATEDITEM_MASTER> GetEntitiesBySql();
    }
}

