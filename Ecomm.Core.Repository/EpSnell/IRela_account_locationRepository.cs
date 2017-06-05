//------------------------------------------------------------------------------
// <copyright file="IRela_account_locationRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/1/16
// </copyright>
//------------------------------------------------------------------------------
using System;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.EpSnell;
using System.Collections.Generic;

namespace Ecomm.Core.Repository.EpSnell
{
	/// <summary>
    /// 仓储操作层接口 —— Rela_account_location 
    /// </summary>
    public interface IRela_account_locationRepository : IRepository<Rela_account_location>
    {
        IEnumerable<Rela_account_location_shipto> Query_SHIPTO(string account_no, string contact_id);

        IEnumerable<Rela_account_location_shipto_item> QueryDropList(string account_no);
    }
}

