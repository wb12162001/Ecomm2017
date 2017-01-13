//------------------------------------------------------------------------------
// <copyright file="ISALES_EORDERSService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/12 16:18:05
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.MyOffice;
using Ecomm.Site.Models.MyOffice.SALES_EORDERS;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.MyOffice
{
	/// <summary>
    /// 服务层接口 —— ISALES_EORDERSService
    /// </summary>
    public interface ISALES_EORDERSService
    {
		#region 属性

        IQueryable<SALES_EORDERS> SALES_EORDERSList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(SALES_EORDERSModel model);
        OperationResult Update(UpdateSALES_EORDERSModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  ID);
        #endregion
	}
}

