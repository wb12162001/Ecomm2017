//------------------------------------------------------------------------------
// <copyright file="PROD_PROPERTIESService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/2/6 12:08:37
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Collections.Generic;

using Quick.Framework.Tool;
using Ecomm.Domain.Models.Product;
using Ecomm.Core.Repository.Product;
using Ecomm.Site.Models;
using Ecomm.Site.Models.Product.PROD_PROPERTIES;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.Product.Impl
{
	/// <summary>
    /// 服务层实现 —— PROD_PROPERTIESService
    /// </summary>
    [Export(typeof(IPROD_PROPERTIESService))]
    public class PROD_PROPERTIESService : CoreServiceBase, IPROD_PROPERTIESService
    {
        #region 属性

        [Import]
        public IPROD_PROPERTIESRepository PROD_PROPERTIESRepository { get; set; }

        public IQueryable<PROD_PROPERTIES> PROD_PROPERTIESList
        {
            get { return PROD_PROPERTIESRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(PROD_PROPERTIESModel model)
        {
            var entity = new PROD_PROPERTIES
            {
                ID = model.ID,
                ProductNo = model.ProductNo,
                PropertyID = model.PropertyID,
                PropertyValue = model.PropertyValue,
                PLevel = model.PLevel,
                ParentID = model.ParentID,
                RelationCode = model.RelationCode,
                RowID = model.RowID,
                RealProductNo = model.RealProductNo,
                DisplayOrder = model.DisplayOrder,
                Remark = model.Remark,
                Status = model.Status,
            };
            PROD_PROPERTIESRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdatePROD_PROPERTIESModel model)
        {
			var entity = PROD_PROPERTIESList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.ProductNo = model.ProductNo;
            entity.PropertyID = model.PropertyID;
            entity.PropertyValue = model.PropertyValue;
            entity.PLevel = model.PLevel;
            entity.ParentID = model.ParentID;
            entity.RelationCode = model.RelationCode;
            entity.RowID = model.RowID;
            entity.RealProductNo = model.RealProductNo;
            entity.DisplayOrder = model.DisplayOrder;
            entity.Remark = model.Remark;
            entity.Status = model.Status;

            PROD_PROPERTIESRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = PROD_PROPERTIESList.FirstOrDefault(t => t.ID == ID);

            PROD_PROPERTIESRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

