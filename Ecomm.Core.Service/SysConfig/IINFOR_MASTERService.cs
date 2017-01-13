//------------------------------------------------------------------------------
// <copyright file="IINFOR_MASTERService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/5 15:15:54
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.SysConfig;
using Ecomm.Site.Models.SysConfig.INFOR_MASTER;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.SysConfig
{
	/// <summary>
    /// 服务层接口 —— IINFOR_MASTERService
    /// </summary>
    public interface IINFOR_MASTERService
    {
		#region 属性

        IQueryable<INFOR_MASTER> INFOR_MASTERList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(INFOR_MASTERModel model);
        OperationResult Update(INFOR_MASTERModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  ID);
        #endregion
	}
}

