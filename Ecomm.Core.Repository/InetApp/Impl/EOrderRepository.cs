//------------------------------------------------------------------------------
// <copyright file="EOrderRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/3/22
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.InetApp;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace Ecomm.Core.Repository.InetApp
{
	/// <summary>
    /// 仓储操作层接口 —— EOrder 
    /// </summary>
    [Export(typeof(IEOrderRepository))]
    public class EOrderRepository : EFRepositoryBase<EOrder>, IEOrderRepository
    {
        public EOrderRepository() : base("inetapp")
        {

        }

        public int InsertOrder(EOrder EOrderInfo)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("declare @oid int;");
                sb.AppendLine();
                sb.AppendFormat("INSERT INTO EOrders (custid,shipid,ship_name,ship_address,ship_city,pono,CommText,CretDate,ModiDate,OrderStats,VoidStats,PROC_STATUS,Freight,ShopID,Miscellaneous) VALUES ('{0}', '{1}', {2}, {3}, {4}, {5},{6}, GetDate(), GetDate(),0,0,{7},{8},'{9}',{10});",
                    EOrderInfo.CustID
                   , EOrderInfo.ShipID
                   , "@ShipName"
                   , "@ShipAddress"
                   , "@ShipCity"
                   , "@PurchaseNo"
                   , "@CommText"
                   , EOrderInfo.PROC_STATUS
                   , EOrderInfo.Freight
                   , EOrderInfo.ShopID
                   , EOrderInfo.Miscellaneous
                    );
                sb.AppendLine();
                sb.AppendLine(" set @oid=@@IDENTITY; select @oid as oid");
                string query = sb.ToString();
                System.Data.SqlClient.SqlParameter[] parameters = {
                base.GetParameter("@ShipName", EOrderInfo.ShipID),
                base.GetParameter("@ShipAddress", EOrderInfo.Ship_Address),
                base.GetParameter("@ShipCity", EOrderInfo.Ship_City),
                base.GetParameter("@PurchaseNo", EOrderInfo.Pono),
                base.GetParameter("@CommText", EOrderInfo.CommText),
                };
                

                //2014-02-27 ben
                object obj = base.ExecuteScalar<int>(query, parameters);
                return int.Parse((obj != null || obj != DBNull.Value) ? obj.ToString() : "-1");
                /*
                int oid = -1;
                string skuNo = string.Empty;
                using (SqlDataReader reader = db.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("Sku"))) skuNo = reader.GetString(reader.GetOrdinal("Sku"));
                    }
                    reader.NextResult();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("oid"))) oid = reader.GetInt32(reader.GetOrdinal("oid"));
                    }
                }
                return oid;
                 */
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<double> GetOrdersByCurrentMonth(string custId, string shipId, DateTime orderDt)
        {
            StringBuilder sb = new StringBuilder();
            //Ben 2015-03-19
            sb.AppendLine("select (a.UnitPrice*a.orderqty) AS amount from EOrderdetails as a (nolock) inner join EOrders as b (nolock)");
            sb.AppendLine(" on a.OrderID = b.OrderID ");
            sb.AppendFormat(" where b.CustID='{0}' and b.ShipID='{1}' and datediff(m,b.CretDate,'{2}')=0;", custId, shipId, orderDt);
            return base.ExcuteQuery<double>(sb.ToString());
        }
        public IEnumerable<double> GetOrdersByCurrentMonth(string custId, string shipId)
        {
            return GetOrdersByCurrentMonth(custId, shipId, DateTime.Now);
        }
    }
}

