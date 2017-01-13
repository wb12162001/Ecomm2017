//------------------------------------------------------------------------------
// <copyright file="ISYS_DICTIONARY_DATAService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/5 15:15:54
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.SysConfig;
using Ecomm.Site.Models.SysConfig.SYS_DICTIONARY_DATA;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.SysConfig
{
	/// <summary>
    /// 服务层接口 —— ISYS_DICTIONARY_DATAService
    /// </summary>
    public interface ISYS_DICTIONARY_DATAService
    {
		#region 属性

        IQueryable<SYS_DICTIONARY_DATA> SYS_DICTIONARY_DATAList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(SYS_DICTIONARY_DATAModel model);
        OperationResult Update(UpdateSYS_DICTIONARY_DATAModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  ID);
        #endregion
	}
}

