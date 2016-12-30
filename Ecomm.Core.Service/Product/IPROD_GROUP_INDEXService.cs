//------------------------------------------------------------------------------
// <copyright file="IPROD_GROUP_INDEXService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2016/12/28 11:15:59
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.Product;
using Ecomm.Site.Models.Product.PROD_GROUP_INDEX;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.Product
{
	/// <summary>
    /// 服务层接口 —— IPROD_GROUP_INDEXService
    /// </summary>
    public interface IPROD_GROUP_INDEXService
    {
		#region 属性

        IQueryable<PROD_GROUP_INDEX> PROD_GROUP_INDEXList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(PROD_GROUP_INDEXModel model);
        OperationResult Update(PROD_GROUP_INDEXModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete( string ID );
        #endregion
	}
}

