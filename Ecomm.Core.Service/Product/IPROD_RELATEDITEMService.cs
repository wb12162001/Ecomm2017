//------------------------------------------------------------------------------
// <copyright file="IPROD_RELATEDITEMService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/2/6 12:08:37
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.Product;
using Ecomm.Site.Models.Product.PROD_RELATEDITEM;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.Product
{
	/// <summary>
    /// 服务层接口 —— IPROD_RELATEDITEMService
    /// </summary>
    public interface IPROD_RELATEDITEMService
    {
		#region 属性

        IQueryable<PROD_RELATEDITEM> PROD_RELATEDITEMList { get; }
        IEnumerable<PROD_RELATEDITEM_MASTER> PROD_RELATEDITEM_MASTERList { get; }
        #endregion

        #region 公共方法
        OperationResult Insert(PROD_RELATEDITEMModel model);
        OperationResult Update(UpdatePROD_RELATEDITEMModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  ProductNo,string  RelatedID);
        #endregion
	}
}

