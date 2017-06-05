//------------------------------------------------------------------------------
// <copyright file="IINFOR_MASTERRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/1/5
// </copyright>
//------------------------------------------------------------------------------
using System;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.SysConfig;
using System.Collections.Generic;

namespace Ecomm.Core.Repository.SysConfig
{
	/// <summary>
    /// 仓储操作层接口 —— INFOR_MASTER 
    /// </summary>
    public interface IINFOR_MASTERRepository : IRepository<INFOR_MASTER>
    {
        IEnumerable<INFOR_MASTER_PAGE> QueryEntities(int count, string strWhere, string strOrder);
    }
}

