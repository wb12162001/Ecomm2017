//------------------------------------------------------------------------------
// <copyright file="IPROD_MASTERCOMMONService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/2/6 10:57:52
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.Product;
using Ecomm.Site.Models.Product.PROD_MASTERCOMMON;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.Product
{
	/// <summary>
    /// 服务层接口 —— IPROD_MASTERCOMMONService
    /// </summary>
    public interface IPROD_MASTERCOMMONService
    {
		#region 属性

        IQueryable<PROD_MASTERCOMMON> PROD_MASTERCOMMONList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(PROD_MASTERCOMMONModel model);
        OperationResult Update(UpdatePROD_MASTERCOMMONModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  ID);
        #endregion
	}
}

