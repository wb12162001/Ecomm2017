//------------------------------------------------------------------------------
// <copyright file="IRela_account_quoteService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/16 17:42:27
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.EpSnell;
using Ecomm.Site.Models.EpSnell.Rela_account_quote;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.EpSnell
{
	/// <summary>
    /// 服务层接口 —— IRela_account_quoteService
    /// </summary>
    public interface IRela_account_quoteService
    {
		#region 属性

        IQueryable<Rela_account_quote> Rela_account_quoteList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(Rela_account_quoteModel model);
        OperationResult Update(UpdateRela_account_quoteModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  Quote_id,string  Account_no,string  Item_no);
        #endregion
	}
}

