//------------------------------------------------------------------------------
// <copyright file="IPROD_MASTERService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2016/12/20 17:55:35
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.Product;
using Ecomm.Site.Models.Product.PROD_MASTER;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.Product
{
	/// <summary>
    /// 服务层接口 —— IPROD_MASTERService
    /// </summary>
    public interface IPROD_MASTERService
    {
		#region 属性

        IQueryable<PROD_MASTER> PROD_MASTERList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(PROD_MASTERModel model);
        OperationResult Update(UpdatePROD_MASTERModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string Id);
        #endregion
	}
}

