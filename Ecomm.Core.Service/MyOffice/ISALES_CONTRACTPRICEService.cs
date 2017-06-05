//------------------------------------------------------------------------------
// <copyright file="ISALES_CONTRACTPRICEService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/17 15:51:35
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.MyOffice;
using Ecomm.Site.Models.MyOffice.SALES_CONTRACTPRICE;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.MyOffice
{
	/// <summary>
    /// 服务层接口 —— ISALES_CONTRACTPRICEService
    /// </summary>
    public interface ISALES_CONTRACTPRICEService
    {
		#region 属性

        IQueryable<SALES_CONTRACTPRICE> SALES_CONTRACTPRICEList { get; }

        #endregion

        #region 公共方法

        IEnumerable<ContractPrice_PAGE_MASTER> GetContractPric(string strwhere, string orderby, int pagesize, int pageIndex, out int totalCount);
        OperationResult Insert(SALES_CONTRACTPRICEModel model);
        OperationResult Update(UpdateSALES_CONTRACTPRICEModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  CustomerID,string  ProductNo);

        bool IsExist(string customerID, string productNo);
        #endregion
    }
}

