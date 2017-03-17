//------------------------------------------------------------------------------
// <copyright file="PROD_PROMOTIONSService.cs">
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
using Ecomm.Site.Models.Product.PROD_PROMOTIONS;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.Product.Impl
{
	/// <summary>
    /// 服务层实现 —— PROD_PROMOTIONSService
    /// </summary>
    [Export(typeof(IPROD_PROMOTIONSService))]
    public class PROD_PROMOTIONSService : CoreServiceBase, IPROD_PROMOTIONSService
    {
        #region 属性

        [Import]
        public IPROD_PROMOTIONSRepository PROD_PROMOTIONSRepository { get; set; }

        public IQueryable<PROD_PROMOTIONS> PROD_PROMOTIONSList
        {
            get { return PROD_PROMOTIONSRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(PROD_PROMOTIONSModel model)
        {
            var entity = new PROD_PROMOTIONS
            {
                ID = model.ID,
                ProductNo = model.ProductNo,
                Title = model.Title,
                ImgFile = model.ImgFile,
                Description = model.Description,
                FootNote = model.FootNote,
                SortNo = model.SortNo,
                CreateDate = model.CreateDate,
                Status = model.Status,
            };
            PROD_PROMOTIONSRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdatePROD_PROMOTIONSModel model)
        {
			var entity = PROD_PROMOTIONSList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.ProductNo = model.ProductNo;
            entity.Title = model.Title;
            entity.ImgFile = model.ImgFile;
            entity.Description = model.Description;
            entity.FootNote = model.FootNote;
            entity.SortNo = model.SortNo;
            entity.CreateDate = model.CreateDate;
            entity.Status = model.Status;

            PROD_PROMOTIONSRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = PROD_PROMOTIONSList.FirstOrDefault(t => t.ID == ID);

            PROD_PROMOTIONSRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

