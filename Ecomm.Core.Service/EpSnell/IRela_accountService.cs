//------------------------------------------------------------------------------
// <copyright file="IRela_accountService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/16 17:42:26
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.EpSnell;
using Ecomm.Site.Models.EpSnell.Rela_account;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.EpSnell
{
	/// <summary>
    /// 服务层接口 —— IRela_accountService
    /// </summary>
    public interface IRela_accountService
    {
		#region 属性

        IQueryable<Rela_account> Rela_accountList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(Rela_accountModel model);
        OperationResult Update(UpdateRela_accountModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  Id);
        #endregion
	}
}

