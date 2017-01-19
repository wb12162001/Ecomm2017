//------------------------------------------------------------------------------
// <copyright file="ISALES_CLEARANCEService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/17 15:51:34
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.MyOffice;
using Ecomm.Site.Models.MyOffice.SALES_CLEARANCE;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.MyOffice
{
	/// <summary>
    /// 服务层接口 —— ISALES_CLEARANCEService
    /// </summary>
    public interface ISALES_CLEARANCEService
    {
		#region 属性

        IQueryable<SALES_CLEARANCE> SALES_CLEARANCEList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(SALES_CLEARANCEModel model);
        OperationResult Update(UpdateSALES_CLEARANCEModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  ID);
        #endregion
	}
}

