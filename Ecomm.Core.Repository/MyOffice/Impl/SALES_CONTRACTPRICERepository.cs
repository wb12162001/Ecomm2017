//------------------------------------------------------------------------------
// <copyright file="SALES_CONTRACTPRICERepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/1/17
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.MyOffice;
using System.Collections.Generic;

namespace Ecomm.Core.Repository.MyOffice
{
	/// <summary>
    /// 仓储操作层接口 —— SALES_CONTRACTPRICE 
    /// </summary>
    [Export(typeof(ISALES_CONTRACTPRICERepository))]
    public class SALES_CONTRACTPRICERepository : EFRepositoryBase<SALES_CONTRACTPRICE>, ISALES_CONTRACTPRICERepository
    {
        public SALES_CONTRACTPRICERepository() : base("default")
        {
        }

        public IEnumerable<ContractPrice_PAGE_MASTER> GetContractPric(string strwhere, string orderby, int pagesize, int pageIndex, out int totalCount)
        {
            System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter();
            param2.Direction = System.Data.ParameterDirection.Output;
            param2.ParameterName = "@TotalRecorder";
            param2.SqlDbType = System.Data.SqlDbType.Int;
            //param2.Size = 100;
            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@CurPage", pageIndex),
            new System.Data.SqlClient.SqlParameter("@PageRows", pagesize),
               base.GetParameter("@strWhere",strwhere, System.Data.SqlDbType.VarChar,1000),
               base.GetParameter("@strOrderby",orderby, System.Data.SqlDbType.VarChar,500),
               param2
            };
            var ds = base.ExecuteProc<ContractPrice_PAGE_MASTER>("USP_SALES_CONTRACTPRICE_GetByCustIDAndShipto", parameters);//注意：parameters 的次序一定要与SP中一样;
            int.TryParse(param2.Value.ToString(), out totalCount);
            return ds;
        }
    }
}

