//------------------------------------------------------------------------------
// <copyright file="IPROD_CATEGORIESService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/2/6 12:08:37
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.Product;
using Ecomm.Site.Models.Product.PROD_CATEGORIES;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.Product
{
	/// <summary>
    /// 服务层接口 —— IPROD_CATEGORIESService
    /// </summary>
    public interface IPROD_CATEGORIESService
    {
		#region 属性

        IQueryable<PROD_CATEGORIES> PROD_CATEGORIESList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(PROD_CATEGORIESModel model);
        OperationResult Update(UpdatePROD_CATEGORIESModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  ID);
        #endregion
	}
}

