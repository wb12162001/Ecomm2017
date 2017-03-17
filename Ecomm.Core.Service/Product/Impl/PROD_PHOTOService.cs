//------------------------------------------------------------------------------
// <copyright file="PROD_PHOTOService.cs">
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
using Ecomm.Site.Models.Product.PROD_PHOTO;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.Product.Impl
{
	/// <summary>
    /// 服务层实现 —— PROD_PHOTOService
    /// </summary>
    [Export(typeof(IPROD_PHOTOService))]
    public class PROD_PHOTOService : CoreServiceBase, IPROD_PHOTOService
    {
        #region 属性

        [Import]
        public IPROD_PHOTORepository PROD_PHOTORepository { get; set; }

        public IQueryable<PROD_PHOTO> PROD_PHOTOList
        {
            get { return PROD_PHOTORepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(PROD_PHOTOModel model)
        {
            var entity = new PROD_PHOTO
            {
                ID = model.ID,
                PhotoTitle = model.PhotoTitle,
                FilePath = model.FilePath,
                IsDefault = model.IsDefault,
                PhotoType = model.PhotoType,
                EntityID = model.EntityID,
                SmallPic = model.SmallPic,
                BigPic = model.BigPic,
                MiddlePic = model.MiddlePic,
                CreateDate = model.CreateDate,
                ModiDate = model.ModiDate,
                Creator = model.Creator,
                Modifier = model.Modifier,
                DisplayOrder = model.DisplayOrder,
                Status = model.Status,
                Item01 = model.Item01,
                Item02 = model.Item02,
                Item03 = model.Item03,
                Item04 = model.Item04,
                Item05 = model.Item05,
            };
            PROD_PHOTORepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdatePROD_PHOTOModel model)
        {
			var entity = PROD_PHOTOList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.PhotoTitle = model.PhotoTitle;
            entity.FilePath = model.FilePath;
            entity.IsDefault = model.IsDefault;
            entity.PhotoType = model.PhotoType;
            entity.EntityID = model.EntityID;
            entity.SmallPic = model.SmallPic;
            entity.BigPic = model.BigPic;
            entity.MiddlePic = model.MiddlePic;
            entity.CreateDate = model.CreateDate;
            entity.ModiDate = model.ModiDate;
            entity.Creator = model.Creator;
            entity.Modifier = model.Modifier;
            entity.DisplayOrder = model.DisplayOrder;
            entity.Status = model.Status;
            entity.Item01 = model.Item01;
            entity.Item02 = model.Item02;
            entity.Item03 = model.Item03;
            entity.Item04 = model.Item04;
            entity.Item05 = model.Item05;

            PROD_PHOTORepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = PROD_PHOTOList.FirstOrDefault(t => t.ID == ID);

            PROD_PHOTORepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

