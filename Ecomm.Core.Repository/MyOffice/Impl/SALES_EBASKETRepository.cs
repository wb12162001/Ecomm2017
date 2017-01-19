//------------------------------------------------------------------------------
// <copyright file="SALES_EBASKETRepository.cs">
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
    /// 仓储操作层接口 —— SALES_EBASKET 
    /// </summary>
    [Export(typeof(ISALES_EBASKETRepository))]
    public class SALES_EBASKETRepository : EFRepositoryBase<SALES_EBASKET>, ISALES_EBASKETRepository
    {
        public SALES_EBASKETRepository() : base("default")
        {
        }

        public IEnumerable<SALES_EBASKET> GetEntitiesBySql()
        {
            return base.EFContext.DbContext.Database.SqlQuery<SALES_EBASKET>("select * from dbo.SALES_EBASKET");
        }
        public int UpdateEBasketQuantity(string custId, string contactId, string proNo, float quantity)
        {
            System.Data.SqlClient.SqlParameter[] parameters = {
               new System.Data.SqlClient.SqlParameter("@CustomerID",custId),
               new System.Data.SqlClient.SqlParameter("@ContactID", contactId),
               new System.Data.SqlClient.SqlParameter("@ProductNo",proNo),
               new System.Data.SqlClient.SqlParameter("@Quantity",quantity),
            };
            return base.ExcuteNoQuery(@"EXEC USP_SALES_EBASKET_UpdateQuntity @CustomerID,@ContactID,@ProductNo,@Quantity", System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, false, "", parameters);
        }

        public int ModificationByProce(SALES_EBASKET oSALES_EBASKETInfo)
        {
            System.Data.SqlClient.SqlParameter[] parameters = {
            new System.Data.SqlClient.SqlParameter("@ID", oSALES_EBASKETInfo.ID),
            new System.Data.SqlClient.SqlParameter("@CustomerID", oSALES_EBASKETInfo.CustomerID),
            new System.Data.SqlClient.SqlParameter("@ContactID", oSALES_EBASKETInfo.ContactID),
            new System.Data.SqlClient.SqlParameter("@ProductNo", oSALES_EBASKETInfo.ProductNo),
            new System.Data.SqlClient.SqlParameter("@Quantity", oSALES_EBASKETInfo.Quantity),
            new System.Data.SqlClient.SqlParameter("@UnitPrice", oSALES_EBASKETInfo.UnitPrice),
            new System.Data.SqlClient.SqlParameter("@Unit", oSALES_EBASKETInfo.Unit),
            new System.Data.SqlClient.SqlParameter("@Creator", oSALES_EBASKETInfo.Creator),
            new System.Data.SqlClient.SqlParameter("@Modifier", oSALES_EBASKETInfo.Modifier),
            new System.Data.SqlClient.SqlParameter("@CreateDate", oSALES_EBASKETInfo.CreateDate),
            new System.Data.SqlClient.SqlParameter("@ModiDate", oSALES_EBASKETInfo.ModiDate),
            new System.Data.SqlClient.SqlParameter("@MakeOrderID", oSALES_EBASKETInfo.MakeOrderID),
            new System.Data.SqlClient.SqlParameter("@Status", oSALES_EBASKETInfo.Status),
            new System.Data.SqlClient.SqlParameter("@UnitPType", oSALES_EBASKETInfo.UnitPType),
        };
            //return base.ExcuteNoQuery("USP_SALES_EBASKET_Modification", System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, false, "", parameters);
            return base.ExecuteProcNo("USP_SALES_EBASKET_Modification", parameters);
        }
    }
}

