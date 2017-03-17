//------------------------------------------------------------------------------
// <copyright file="PROD_RELATED_PROPERTYService.cs">
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
using Ecomm.Site.Models.Product.PROD_RELATED_PROPERTY;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.Product.Impl
{
	/// <summary>
    /// 服务层实现 —— PROD_RELATED_PROPERTYService
    /// </summary>
    [Export(typeof(IPROD_RELATED_PROPERTYService))]
    public class PROD_RELATED_PROPERTYService : CoreServiceBase, IPROD_RELATED_PROPERTYService
    {
        #region 属性

        [Import]
        public IPROD_RELATED_PROPERTYRepository PROD_RELATED_PROPERTYRepository { get; set; }

        public IQueryable<PROD_RELATED_PROPERTY> PROD_RELATED_PROPERTYList
        {
            get { return PROD_RELATED_PROPERTYRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(PROD_RELATED_PROPERTYModel model)
        {
            var entity = new PROD_RELATED_PROPERTY
            {
                ProductNo = model.ProductNo,
                PropertyID = model.PropertyID,
                CLevel = model.CLevel,
            };
            PROD_RELATED_PROPERTYRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdatePROD_RELATED_PROPERTYModel model)
        {
			var entity = PROD_RELATED_PROPERTYList.First(t => t.ProductNo == model.ProductNo && t.PropertyID == model.PropertyID);
            entity.ProductNo = model.ProductNo;
            entity.PropertyID = model.PropertyID;
            entity.CLevel = model.CLevel;

            PROD_RELATED_PROPERTYRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ProductNo,string  PropertyID)
        {
            var model = PROD_RELATED_PROPERTYList.FirstOrDefault(t => t.ProductNo == ProductNo && t.PropertyID == PropertyID);

            PROD_RELATED_PROPERTYRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

