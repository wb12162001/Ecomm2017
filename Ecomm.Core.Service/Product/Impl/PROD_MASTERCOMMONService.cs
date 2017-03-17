//------------------------------------------------------------------------------
// <copyright file="PROD_MASTERCOMMONService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/2/6 10:57:52
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
using Ecomm.Site.Models.Product.PROD_MASTERCOMMON;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.Product.Impl
{
	/// <summary>
    /// 服务层实现 —— PROD_MASTERCOMMONService
    /// </summary>
    [Export(typeof(IPROD_MASTERCOMMONService))]
    public class PROD_MASTERCOMMONService : CoreServiceBase, IPROD_MASTERCOMMONService
    {
        #region 属性

        [Import]
        public IPROD_MASTERCOMMONRepository PROD_MASTERCOMMONRepository { get; set; }

        public IQueryable<PROD_MASTERCOMMON> PROD_MASTERCOMMONList
        {
            get { return PROD_MASTERCOMMONRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(PROD_MASTERCOMMONModel model)
        {
            var entity = new PROD_MASTERCOMMON
            {
                ID = model.ID,
                ProductNo = model.ProductNo,
                CommTitle = model.CommTitle,
                CommSummary = model.CommSummary,
                CommContent = model.CommContent,
                Creator = model.Creator,
                CreateDate = model.CreateDate,
                Modifier = model.Modifier,
                ModiDate = model.ModiDate,
                Status = model.Status,
                Item01 = model.Item01,
                Item02 = model.Item02,
                Item03 = model.Item03,
                Item04 = model.Item04,
                Item05 = model.Item05,
            };
            PROD_MASTERCOMMONRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdatePROD_MASTERCOMMONModel model)
        {
			var entity = PROD_MASTERCOMMONList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.ProductNo = model.ProductNo;
            entity.CommTitle = model.CommTitle;
            entity.CommSummary = model.CommSummary;
            entity.CommContent = model.CommContent;
            entity.Creator = model.Creator;
            entity.CreateDate = model.CreateDate;
            entity.Modifier = model.Modifier;
            entity.ModiDate = model.ModiDate;
            entity.Status = model.Status;
            entity.Item01 = model.Item01;
            entity.Item02 = model.Item02;
            entity.Item03 = model.Item03;
            entity.Item04 = model.Item04;
            entity.Item05 = model.Item05;

            PROD_MASTERCOMMONRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = PROD_MASTERCOMMONList.FirstOrDefault(t => t.ID == ID);

            PROD_MASTERCOMMONRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

