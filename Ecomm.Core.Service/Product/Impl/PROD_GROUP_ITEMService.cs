//------------------------------------------------------------------------------
// <copyright file="PROD_GROUP_ITEMService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2016/12/28 11:15:59
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Quick.Framework.Tool;
using Ecomm.Domain.Models.Product;
using Ecomm.Core.Repository.Product;
using Ecomm.Site.Models;
using Ecomm.Site.Models.Product.PROD_GROUP_ITEM;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.Product.Impl
{
	/// <summary>
    /// 服务层实现 —— PROD_GROUP_ITEMService
    /// </summary>
    [Export(typeof(IPROD_GROUP_ITEMService))]
    public class PROD_GROUP_ITEMService : CoreServiceBase, IPROD_GROUP_ITEMService
    {
        #region 属性

        [Import]
        public IPROD_GROUP_ITEMRepository PROD_GROUP_ITEMRepository { get; set; }

        public IQueryable<PROD_GROUP_ITEM> PROD_GROUP_ITEMList
        {
            get { return PROD_GROUP_ITEMRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(PROD_GROUP_ITEMModel model)
        {
            var entity = new PROD_GROUP_ITEM
            {
                ProductID = model.ProductID,
                GROUP_INDEX = model.GROUP_INDEX,
                Notes = model.Notes,
                Picture = model.Picture,
                Status = (byte)(model.Status ? 1  :0),
            };
            PROD_GROUP_ITEMRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdatePROD_GROUP_ITEMModel model)
        {
            //因为这里使用两个联合主键为约束
            /*
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE dbo.[PROD_GROUP_ITEM]");
            sb.AppendLine("   SET [ProductID] = @ProductID");
            sb.AppendLine("      ,[GROUP_INDEX] = @GROUP_INDEX");
            sb.AppendLine("      ,[Notes] = @Notes");
            sb.AppendLine("      ,[Picture] = @Picture");
            sb.AppendLine("      ,[Status] = @Status");
            sb.AppendLine(" WHERE [ProductID] = @oldProductID");
            sb.AppendLine("       and [GROUP_INDEX] = @oldGROUP_INDEX");

            System.Data.SqlClient.SqlParameter[] parameters = {
               new System.Data.SqlClient.SqlParameter("@ProductID",model.NewProductID),
               new System.Data.SqlClient.SqlParameter("@GROUP_INDEX",model.NewGROUP_INDEX),
               new System.Data.SqlClient.SqlParameter("@Notes",model.Notes),
               new System.Data.SqlClient.SqlParameter("@Picture",model.Picture),
               new System.Data.SqlClient.SqlParameter("@Status",model.Status),
               new System.Data.SqlClient.SqlParameter("@oldProductID",model.ProductID),
               new System.Data.SqlClient.SqlParameter("@oldGROUP_INDEX",model.GROUP_INDEX),
            };
            //这里以在数据库中修改成功;
            PROD_GROUP_ITEMRepository.ExcuteNoQuery(sb.ToString(), System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction,false,"", parameters);
            //这里的Entities没有更新??
            */

            var entity = PROD_GROUP_ITEMList.First(t => t.ProductID == model.ProductID && t.GROUP_INDEX == model.GROUP_INDEX);
            //entity.ProductID = model.NewProductID;
            //entity.GROUP_INDEX = model.NewGROUP_INDEX;
            entity.Notes = model.Notes;
            entity.Picture = model.Picture;
            entity.Status = (byte)(model.Status ? 1 : 0);

            PROD_GROUP_ITEMRepository.Update(entity);

            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete( string ProductID, string GROUP_INDEX )
        {
            var model = PROD_GROUP_ITEMList.FirstOrDefault(t => t.ProductID == ProductID && t.GROUP_INDEX == GROUP_INDEX );

            PROD_GROUP_ITEMRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

