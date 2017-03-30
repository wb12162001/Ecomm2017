//------------------------------------------------------------------------------
// <copyright file="ISALES_EORDERDETAILSService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/12 16:18:05
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.MyOffice;
using Ecomm.Site.Models.MyOffice.SALES_EORDERDETAILS;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.MyOffice
{
	/// <summary>
    /// 服务层接口 —— ISALES_EORDERDETAILSService
    /// </summary>
    public interface ISALES_EORDERDETAILSService
    {
		#region 属性

        IQueryable<SALES_EORDERDETAILS> SALES_EORDERDETAILSList { get; }

        #endregion

        #region 公共方法
        IEnumerable<SALES_EORDERDETAILS_MASTER> QueryEntities(int count, string strWhere, string strOrder);
        OperationResult Insert(SALES_EORDERDETAILSModel model);
        OperationResult Update(UpdateSALES_EORDERDETAILSModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  OrderID,string  ProductNo);
        #endregion
	}
}

