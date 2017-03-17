//------------------------------------------------------------------------------
// <copyright file="IRela_contactService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/3 15:51:19
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.EpSnell;
using Ecomm.Site.Models.EpSnell.Rela_contact;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.EpSnell
{
	/// <summary>
    /// 服务层接口 —— IRela_contactService
    /// </summary>
    public interface IRela_contactService
    {
		#region 属性

        IQueryable<Rela_contact> Rela_contactList { get; }

        #endregion

        #region 公共方法
        void GetFreightByCust(string cust, out float freight, out float admincost);


        OperationResult Insert(Rela_contactModel model);
        OperationResult Update(UpdateRela_contactModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  Id);
        #endregion
	}
}

