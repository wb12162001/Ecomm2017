//------------------------------------------------------------------------------
// <copyright file="ISALES_INTERNETPRICEService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/17 15:51:35
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.MyOffice;
using Ecomm.Site.Models.MyOffice.SALES_INTERNETPRICE;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.MyOffice
{
	/// <summary>
    /// 服务层接口 —— ISALES_INTERNETPRICEService
    /// </summary>
    public interface ISALES_INTERNETPRICEService
    {
		#region 属性

        IQueryable<SALES_INTERNETPRICE> SALES_INTERNETPRICEList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(SALES_INTERNETPRICEModel model);
        OperationResult Update(UpdateSALES_INTERNETPRICEModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  CustomerID,string  ProductNo);
        #endregion
	}
}

