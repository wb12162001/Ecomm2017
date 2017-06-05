using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.MyOffice;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using Ecomm.Domain.Models.GPSPS;

namespace Ecomm.Core.Repository.GPSPS
{

    /// <summary>
    /// 仓储操作层接口
    /// </summary>
    [Export(typeof(IDBRepository))]
    public class DBRepository : EFRepositoryBase<DBNull>, IDBRepository
    {
        public DBRepository() : base("gpsps")
        {
        }

        /// <summary>
        /// Example (使用Thomas写的SP 从SPliv数据库中获取)
        ///declare	@freight float, @admincost float 
        ///exec zx_GetFreightByCust 'OMEGPL', @freight output, @admincost output
        ///print @freight
        ///print @admincost
        /// </summary>
        /// <param name="cust"></param>
        /// <param name="freight"></param>
        /// <param name="admincost"></param>
        public void GetFreightByCust(string cust, out float freight, out float admincost)
        {
            float frt = 0;
            float acost = 0;

            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter();
            param.Direction = System.Data.ParameterDirection.Output;
            param.ParameterName = "@freight";
            param.SqlDbType = System.Data.SqlDbType.VarChar;
            param.Size = 100;
            System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter();
            param2.Direction = System.Data.ParameterDirection.Output;
            param2.ParameterName = "@admincost";
            param2.SqlDbType = System.Data.SqlDbType.VarChar;
            param2.Size = 100;
            System.Data.SqlClient.SqlParameter[] parameters = {
               new System.Data.SqlClient.SqlParameter("@custnmbr",cust),
                param,
                param2
            };
            base.ExecuteProcNo("zx_GetFreightByCust", parameters);

            float.TryParse(param.Value.ToString(), out frt);
            float.TryParse(param2.Value.ToString(), out acost);
            freight = frt;
            admincost = acost;
        }
   
        public IEnumerable<RM00102> GetRM00102(string strWhere)
        {
            if (!string.IsNullOrEmpty(strWhere))
            {
                strWhere = " Where " + strWhere;
            }
            string sql = string.Format("SELECT * FROM [dbo].[RM00102] {0}", strWhere);
            return base.ExcuteQuery<RM00102>(sql);
        }

        public IEnumerable<OrderItem> GetOrderItemStatusByPackslip(string packslip)
        {
            System.Data.SqlClient.SqlParameter[] parameters = {
               new System.Data.SqlClient.SqlParameter("@sopnumbe", packslip)
            };
            return base.ExecuteProc<OrderItem>("zx_GetOrderStatusByOrderId", parameters);
        }
    }
}
