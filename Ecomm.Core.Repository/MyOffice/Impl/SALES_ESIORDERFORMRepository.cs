//------------------------------------------------------------------------------
// <copyright file="SALES_ESIORDERFORMRepository.cs">
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
    /// 仓储操作层接口 —— SALES_ESIORDERFORM 
    /// </summary>
    [Export(typeof(ISALES_ESIORDERFORMRepository))]
    public class SALES_ESIORDERFORMRepository : EFRepositoryBase<SALES_ESIORDERFORM>, ISALES_ESIORDERFORMRepository
    {
        public SALES_ESIORDERFORMRepository() : base("default")
        {
        }

        public IEnumerable<SALES_ESIORDERFORM_MASTER> QueryEntities(int count, string strWhere, string strOrder)
        {
            System.Data.SqlClient.SqlParameter[] parameters = {
               new System.Data.SqlClient.SqlParameter("@count",count),
               new System.Data.SqlClient.SqlParameter("@strWhere", strWhere),
               new System.Data.SqlClient.SqlParameter("@strOrder",strOrder)
            };
            return base.ExecuteProc<SALES_ESIORDERFORM_MASTER>("USP_SALES_ESIORDERFORM_Query", parameters);
        }

        public IEnumerable<ESIORDERFORM_PAGE_MASTER> GetByCustIDAndShipto(string customer, string contactID, string shipTo, int curPage, int pageRows, string strWhere, string orderby, out int pageCount)
        {

            System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter();
            param2.Direction = System.Data.ParameterDirection.Output;
            param2.ParameterName = "@TotalRecorder";
            param2.SqlDbType = System.Data.SqlDbType.VarChar;
            param2.Size = 100;
            System.Data.SqlClient.SqlParameter[] parameters = {
               new System.Data.SqlClient.SqlParameter("@CurPage", curPage),
            new System.Data.SqlClient.SqlParameter("@PageRows", pageRows),
               new System.Data.SqlClient.SqlParameter("@strWhere", strWhere),
               new System.Data.SqlClient.SqlParameter("@strOrderby", orderby),
               param2
            };
            var ds = base.ExecuteProc<ESIORDERFORM_PAGE_MASTER>("USP_SALES_ESIORDERFORM_GetByCustIDAndShipto", parameters);
            int.TryParse(param2.Value.ToString(), out pageCount);
            return ds;
        }

        public List<Location> GetEOFShipToCount(string strWhere)
        {
            string sql = string.Format("select count(1) as Total,ShipTo from dbo.SALES_ESIORDERFORM {0} group by ShipTo", strWhere);
            var ds = base.ExcuteQuery<Location>(sql);
            return ds;
        }

        public IEnumerable<CustomizedProduct_PAGE_MASTER> GetCustomizedProducts(string strwhere, string custnmbr, string sortModle, int pagesize, int pageIndex, out int totalCount)
        {
            System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter();
            param2.Direction = System.Data.ParameterDirection.Output;
            param2.ParameterName = "@TotalRecorder";
            param2.SqlDbType = System.Data.SqlDbType.VarChar;
            param2.Size = 100;
            System.Data.SqlClient.SqlParameter[] parameters = {
               new System.Data.SqlClient.SqlParameter("@strwhere", strwhere),
               new System.Data.SqlClient.SqlParameter("@custnmbr", custnmbr),
               new System.Data.SqlClient.SqlParameter("@Order", sortModle),
               new System.Data.SqlClient.SqlParameter("@CurPage", pageIndex),
            new System.Data.SqlClient.SqlParameter("@PageRows", pagesize),
               param2
            };
            var ds = base.ExecuteProc<CustomizedProduct_PAGE_MASTER>("zx_GetCustomizedProducts", parameters);
            int.TryParse(param2.Value.ToString(), out totalCount);
            return ds;
        }

        public IEnumerable<MyFavourite_QTY_MASTER> GetQTY(string customerID, string productNo)
        {
            string sql = "select CustomerID,ProductNo,ShipTo,Qty0,Qty1,Qty2,Qty3,Forecast from SALES_ESIORDERFORM where CustomerID=@customerID and ProductNo=@productNo ";
            System.Data.SqlClient.SqlParameter[] parameters = {
               new System.Data.SqlClient.SqlParameter("@customerID", customerID),
               new System.Data.SqlClient.SqlParameter("@productNo", productNo),
            };
            return base.ExcuteQuery<MyFavourite_QTY_MASTER>(sql, parameters);
        }
    }
}

