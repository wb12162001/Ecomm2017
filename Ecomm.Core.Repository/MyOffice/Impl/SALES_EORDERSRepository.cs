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
    }
}

