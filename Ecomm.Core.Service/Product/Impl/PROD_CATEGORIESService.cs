//------------------------------------------------------------------------------
// <copyright file="PROD_CATEGORIESService.cs">
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
using Ecomm.Site.Models.Product.PROD_CATEGORIES;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.Product.Impl
{
	/// <summary>
    /// 服务层实现 —— PROD_CATEGORIESService
    /// </summary>
    [Export(typeof(IPROD_CATEGORIESService))]
    public class PROD_CATEGORIESService : CoreServiceBase, IPROD_CATEGORIESService
    {
        #region 属性

        [Import]
        public IPROD_CATEGORIESRepository PROD_CATEGORIESRepository { get; set; }

        public IQueryable<PROD_CATEGORIES> PROD_CATEGORIESList
        {
            get { return PROD_CATEGORIESRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(PROD_CATEGORIESModel model)
        {
            var entity = new PROD_CATEGORIES
            {
                ID = model.ID,
                CategoryName = model.CategoryName,
                CategoryCode = model.CategoryCode,
                Description = model.Description,
                ParentID = model.ParentID,
                ColorBg = model.ColorBg,
                ColorText = model.ColorText,
                Picture = model.Picture,
                SmallPic = model.SmallPic,
                BigPic = model.BigPic,
                CLevel = model.CLevel,
                DisplayOrder = model.DisplayOrder,
                Creator = model.Creator,
                Modifier = model.Modifier,
                CreateDate = model.CreateDate,
                Modidate = model.Modidate,
                Status = model.Status,
                Item01 = model.Item01,
                Item02 = model.Item02,
                Item03 = model.Item03,
                Item04 = model.Item04,
                Item05 = model.Item05,
                MenuAlias = model.MenuAlias,
                IsAvailably = model.IsAvailably,
            };
            PROD_CATEGORIESRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdatePROD_CATEGORIESModel model)
        {
			var entity = PROD_CATEGORIESList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.CategoryName = model.CategoryName;
            entity.CategoryCode = model.CategoryCode;
            entity.Description = model.Description;
            entity.ParentID = model.ParentID;
            entity.ColorBg = model.ColorBg;
            entity.ColorText = model.ColorText;
            entity.Picture = model.Picture;
            entity.SmallPic = model.SmallPic;
            entity.BigPic = model.BigPic;
            entity.CLevel = model.CLevel;
            entity.DisplayOrder = model.DisplayOrder;
            entity.Creator = model.Creator;
            entity.Modifier = model.Modifier;
            entity.CreateDate = model.CreateDate;
            entity.Modidate = model.Modidate;
            entity.Status = model.Status;
            entity.Item01 = model.Item01;
            entity.Item02 = model.Item02;
            entity.Item03 = model.Item03;
            entity.Item04 = model.Item04;
            entity.Item05 = model.Item05;
            entity.MenuAlias = model.MenuAlias;
            entity.IsAvailably = model.IsAvailably;

            PROD_CATEGORIESRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = PROD_CATEGORIESList.FirstOrDefault(t => t.ID == ID);

            PROD_CATEGORIESRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

