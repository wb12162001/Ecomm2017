//------------------------------------------------------------------------------
// <copyright file="SALES_EORDERSRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/1/12
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.MyOffice;
using System.Text;
using System.Collections.Generic;

namespace Ecomm.Core.Repository.MyOffice
{
	/// <summary>
    /// 仓储操作层接口 —— SALES_EORDERS 
    /// </summary>
    [Export(typeof(ISALES_EORDERSRepository))]
    public class SALES_EORDERSRepository : EFRepositoryBase<SALES_EORDERS>, ISALES_EORDERSRepository
    {
        public SALES_EORDERSRepository() : base("default")
        {
        }

        public double GetOrdersByCurrentMonth(string custId, string shipId)
        {
            double ret = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select sum(isnull(UnitPrice,0)*isnull(Orderqty,0)) as sumMonth from dbo.SALES_EORDERDETAILS as a (nolock) inner join dbo.SALES_EORDERS as b (nolock)");
            sb.AppendLine(" on b.ID = a.OrderID");
            sb.AppendFormat(" where b.CustomerID='{0}' and b.ShipID='{1}' and datediff(m,b.CreateDate,getdate())=0", custId, shipId);
            //string sql = string.Format("a.CustomerID='{0}' and DATEPART(mm, OrderDate)=DATEPART(mm, '{1}') and DATEPART(yy, OrderDate)= DATEPART(yy, '{1}')", custId, orderDate);
            object obj = base.ExecuteScalar<double>(sb.ToString());
            if (obj != DBNull.Value) double.TryParse(obj.ToString(), out ret);
            return ret;
        }

        public IEnumerable<Order_Status> GetOrderStatus(string Custid)
        {
            System.Data.SqlClient.SqlParameter[] parameters = {
                base.GetParameter("@CUSTNMBR",Custid, System.Data.SqlDbType.VarChar,50)
            };
            return base.ExecuteProc<Order_Status>("zx_GetOrderStatusHeadByCustid", parameters);
        }

        public IEnumerable<OrderSalesByCustidByloca> GetsalesByCustidByloca(string Custid, string date1, string date2)
        {
            System.Data.SqlClient.SqlParameter[] parameters = {
                base.GetParameter("@CUSTNMBR",Custid, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@DATE1",date1, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@DATE2",date2, System.Data.SqlDbType.VarChar,50)
            };
            return base.ExecuteProc<OrderSalesByCustidByloca>("zx_GetsalesByCustidByloca", parameters);
        }

        public IEnumerable<OrderLocaByuseridModel> GetLocaByuserid(string Custid, string userId)
        {
            System.Data.SqlClient.SqlParameter[] parameters = {
                base.GetParameter("@custnmbr",Custid, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@loginid",userId, System.Data.SqlDbType.VarChar,80)
            };
            return base.ExecuteProc<OrderLocaByuseridModel>("zx_GetLocaByuserid", parameters);
        }

        public IEnumerable<OrderSalesByClasalesModel> GetClasalesByCustid(string Custid, string date1, string date2, string loca)
        {
            System.Data.SqlClient.SqlParameter[] parameters = {
                base.GetParameter("@CUSTNMBR",Custid, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@DATE1",date1, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@DATE2",date2, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@loca",loca, System.Data.SqlDbType.VarChar,50)
            };
            return base.ExecuteProc<OrderSalesByClasalesModel>("zx_GetClasalesByCustid", parameters);
        }

        public IEnumerable<OrderSalesByClasalesProductModel> GetclasalesByCustidByAllprod(string Custid, string date1, string date2, string loca)
        {
            System.Data.SqlClient.SqlParameter[] parameters = {
                base.GetParameter("@CUSTNMBR",Custid, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@DATE1",date1, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@DATE2",date2, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@loca",loca, System.Data.SqlDbType.VarChar,50)
            };
            return base.ExecuteProc<OrderSalesByClasalesProductModel>("zx_GetclasalesByCustidByAllprod", parameters);
        }

        public IEnumerable<OrderSalesByClasalesProductModel> GetclasalesByCustidByprod(string Custid, string date1, string date2, string itclass, string loca)
        {
            System.Data.SqlClient.SqlParameter[] parameters = {
                base.GetParameter("@CUSTNMBR",Custid, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@DATE1",date1, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@DATE2",date2, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@ITCLASS",itclass, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@loca",loca, System.Data.SqlDbType.VarChar,50)
            };
            return base.ExecuteProc<OrderSalesByClasalesProductModel>("zx_GetclasalesByCustidByprod", parameters);
        }

        public IEnumerable<OrderInvByProdModel> GetInvByProd(string Custid, string itmembr, string date1, string date2)
        {
            System.Data.SqlClient.SqlParameter[] parameters = {
                base.GetParameter("@CUSTNMBR",Custid, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@ITEMNMBR",itmembr, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@DATE1",date1, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@DATE2",date2, System.Data.SqlDbType.VarChar,50)
            };
            return base.ExecuteProc<OrderInvByProdModel>("zx_GetInvByProd", parameters);
        }


        /// <summary>
        /// Invoices
        /// </summary>
        /// <param name="Custid"></param>
        /// <param name="date1"></param>
        /// <param name="searchKey">invoiceNo. Or orderNo.</param>
        /// <returns></returns>
        public IEnumerable<InvByCustidModel> GetInvByCustid(string Custid, string dateFrom, string dateTo, string searchKey, string type)
        {
            System.Data.SqlClient.SqlParameter[] parameters = {
                base.GetParameter("@CUSTNMBR",Custid, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@formDATE",dateFrom, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@toDATE",dateTo, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@INVOICENUMBR",searchKey, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@Type",type, System.Data.SqlDbType.VarChar,2),
            };
            return base.ExecuteProc<InvByCustidModel>("zx_GetInvByCustid", parameters);
        }
        public IEnumerable<InvoiceDetailModel> GetInvdetailByCustid(string Custid, string invoiceNo, int invoiceType)
        {
            System.Data.SqlClient.SqlParameter[] parameters = {
                base.GetParameter("@CUSTNMBR",Custid, System.Data.SqlDbType.VarChar,50),
                base.GetParameter("@INVOICENUMBR",invoiceNo, System.Data.SqlDbType.VarChar,50),
                new System.Data.SqlClient.SqlParameter("@INVOICETYPE",invoiceType),
            };
            return base.ExecuteProc<InvoiceDetailModel>("zx_GetInvdetailByCustid", parameters);
        }

    }
}

