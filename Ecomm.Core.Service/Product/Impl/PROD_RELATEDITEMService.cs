//------------------------------------------------------------------------------
// <copyright file="PROD_RELATEDITEMService.cs">
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
using Ecomm.Site.Models.Product.PROD_RELATEDITEM;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.Product.Impl
{
	/// <summary>
    /// 服务层实现 —— PROD_RELATEDITEMService
    /// </summary>
    [Export(typeof(IPROD_RELATEDITEMService))]
    public class PROD_RELATEDITEMService : CoreServiceBase, IPROD_RELATEDITEMService
    {
        #region 属性

        [Import]
        public IPROD_RELATEDITEMRepository PROD_RELATEDITEMRepository { get; set; }

        public IQueryable<PROD_RELATEDITEM> PROD_RELATEDITEMList
        {
            get { return PROD_RELATEDITEMRepository.Entities; }
        }

        public IEnumerable<PROD_RELATEDITEM_MASTER> PROD_RELATEDITEM_MASTERList
        {
            get { return PROD_RELATEDITEMRepository.GetEntitiesBySql(); }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(PROD_RELATEDITEMModel model)
        {
            var entity = new PROD_RELATEDITEM
            {
                ProductNo = model.ProductNo,
                RelatedID = model.RelatedID,
                Ranking = model.Ranking,
            };
            PROD_RELATEDITEMRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdatePROD_RELATEDITEMModel model)
        {
			var entity = PROD_RELATEDITEMList.First(t => t.ProductNo == model.ProductNo && t.RelatedID == model.RelatedID);
            entity.ProductNo = model.ProductNo;
            entity.RelatedID = model.RelatedID;
            entity.Ranking = model.Ranking;

            PROD_RELATEDITEMRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ProductNo,string  RelatedID)
        {
            var model = PROD_RELATEDITEMList.FirstOrDefault(t => t.ProductNo == ProductNo && t.RelatedID == RelatedID);

            PROD_RELATEDITEMRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

