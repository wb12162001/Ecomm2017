//------------------------------------------------------------------------------
// <copyright file="IPROD_MASTERRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2016/12/20
// </copyright>
//------------------------------------------------------------------------------
using System;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.Product;
using System.Collections.Generic;

namespace Ecomm.Core.Repository.Product
{
	/// <summary>
    /// 仓储操作层接口 —— PROD_MASTER 
    /// </summary>
    public interface IPROD_MASTERRepository : IRepository<PROD_MASTER>
    {
        void GetSellingPrice(string itemnmbr, string custnmbr, out double sellPrice, out string priceType);

        IEnumerable<PROD_MASTER_PAGE> QueryEntities(int count, string strWhere, string strOrder);
    }
}

