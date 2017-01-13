//------------------------------------------------------------------------------
// <copyright file="ISYS_PROPERTYService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/5 15:15:55
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.SysConfig;
using Ecomm.Site.Models.SysConfig.SYS_PROPERTY;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.SysConfig
{
	/// <summary>
    /// 服务层接口 —— ISYS_PROPERTYService
    /// </summary>
    public interface ISYS_PROPERTYService
    {
		#region 属性

        IQueryable<SYS_PROPERTY> SYS_PROPERTYList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(SYS_PROPERTYModel model);
        OperationResult Update(UpdateSYS_PROPERTYModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  PropertyID);
        #endregion
	}
}

