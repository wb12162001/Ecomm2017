﻿//------------------------------------------------------------------------------
// <copyright file="SALES_EORDERDETAILSRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/1/12
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
    /// 仓储操作层接口 —— SALES_EORDERDETAILS 
    /// </summary>
    [Export(typeof(ISALES_EORDERDETAILSRepository))]
    public class SALES_EORDERDETAILSRepository : EFRepositoryBase<SALES_EORDERDETAILS>, ISALES_EORDERDETAILSRepository
    {
        public SALES_EORDERDETAILSRepository() : base("default")
        {
        }

        public IEnumerable<SALES_EORDERDETAILS_MASTER> QueryEntities(int count, string strWhere, string strOrder)
        {
            System.Data.SqlClient.SqlParameter[] parameters = {
               new System.Data.SqlClient.SqlParameter("@count",count),
               new System.Data.SqlClient.SqlParameter("@strWhere", strWhere),
               new System.Data.SqlClient.SqlParameter("@strOrder",strOrder)
            };
            return base.ExecuteProc<SALES_EORDERDETAILS_MASTER>("USP_SALES_EORDERDETAILS_Query", parameters);
        }
    }
}

