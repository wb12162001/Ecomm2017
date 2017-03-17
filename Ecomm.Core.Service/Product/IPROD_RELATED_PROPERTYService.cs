//------------------------------------------------------------------------------
// <copyright file="IPROD_RELATED_PROPERTYService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/2/6 12:08:37
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.Product;
using Ecomm.Site.Models.Product.PROD_RELATED_PROPERTY;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.Product
{
	/// <summary>
    /// 服务层接口 —— IPROD_RELATED_PROPERTYService
    /// </summary>
    public interface IPROD_RELATED_PROPERTYService
    {
		#region 属性

        IQueryable<PROD_RELATED_PROPERTY> PROD_RELATED_PROPERTYList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(PROD_RELATED_PROPERTYModel model);
        OperationResult Update(UpdatePROD_RELATED_PROPERTYModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  ProductNo,string  PropertyID);
        #endregion
	}
}

