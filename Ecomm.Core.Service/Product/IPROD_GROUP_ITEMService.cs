//------------------------------------------------------------------------------
// <copyright file="IPROD_GROUP_ITEMService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2016/12/28 11:15:59
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.Product;
using Ecomm.Site.Models.Product.PROD_GROUP_ITEM;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.Product
{
	/// <summary>
    /// 服务层接口 —— IPROD_GROUP_ITEMService
    /// </summary>
    public interface IPROD_GROUP_ITEMService
    {
		#region 属性

        IQueryable<PROD_GROUP_ITEM> PROD_GROUP_ITEMList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(PROD_GROUP_ITEMModel model);
        OperationResult Update(PROD_GROUP_ITEMModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete( string ProductID, string GROUP_INDEX );
        #endregion
	}
}

