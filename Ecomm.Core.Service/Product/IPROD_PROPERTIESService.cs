//------------------------------------------------------------------------------
// <copyright file="IPROD_PROPERTIESService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/2/6 12:08:37
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.Product;
using Ecomm.Site.Models.Product.PROD_PROPERTIES;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.Product
{
	/// <summary>
    /// 服务层接口 —— IPROD_PROPERTIESService
    /// </summary>
    public interface IPROD_PROPERTIESService
    {
		#region 属性

        IQueryable<PROD_PROPERTIES> PROD_PROPERTIESList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(PROD_PROPERTIESModel model);
        OperationResult Update(UpdatePROD_PROPERTIESModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  ID);
        #endregion
	}
}

