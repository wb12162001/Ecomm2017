//------------------------------------------------------------------------------
// <copyright file="IRela_location_limitService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/16 17:42:27
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.EpSnell;
using Ecomm.Site.Models.EpSnell.Rela_location_limit;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.EpSnell
{
	/// <summary>
    /// 服务层接口 —— IRela_location_limitService
    /// </summary>
    public interface IRela_location_limitService
    {
		#region 属性

        IQueryable<Rela_location_limit> Rela_location_limitList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(Rela_location_limitModel model);
        OperationResult Update(UpdateRela_location_limitModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  Account_no,string  Address_id);
        #endregion
	}
}

