//------------------------------------------------------------------------------
// <copyright file="PROD_GROUP_INDEXService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2016/12/28 11:15:59
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
using Ecomm.Site.Models.Product.PROD_GROUP_INDEX;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.Product.Impl
{
	/// <summary>
    /// 服务层实现 —— PROD_GROUP_INDEXService
    /// </summary>
    [Export(typeof(IPROD_GROUP_INDEXService))]
    public class PROD_GROUP_INDEXService : CoreServiceBase, IPROD_GROUP_INDEXService
    {
        #region 属性

        [Import]
        public IPROD_GROUP_INDEXRepository PROD_GROUP_INDEXRepository { get; set; }

        public IQueryable<PROD_GROUP_INDEX> PROD_GROUP_INDEXList
        {
            get { return PROD_GROUP_INDEXRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(PROD_GROUP_INDEXModel model)
        {
            var entity = new PROD_GROUP_INDEX
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                ParentID = model.ParentID,
                ColorBg = model.ColorBg,
                ColorText = model.ColorText,
                Picture = model.Picture,
                DisplayOrder = model.DisplayOrder,
                Creator = model.Creator,
                Modifier = model.Modifier,
                CreateDate = model.CreateDate,
                Modidate = model.Modidate,
                Status = model.Status?1:0,
                Item01 = model.Item01,
                Item02 = model.Item02,
                Item03 = model.Item03,
                Item04 = model.Item04,
                Item05 = model.Item05,
            };
            PROD_GROUP_INDEXRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(PROD_GROUP_INDEXModel model)
        {
			var entity = PROD_GROUP_INDEXList.First(t => t.ID == model.ID );
            //entity.ID = model.ID;
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.ParentID = model.ParentID;
            entity.ColorBg = model.ColorBg;
            entity.ColorText = model.ColorText;
            entity.Picture = model.Picture;
            entity.DisplayOrder = model.DisplayOrder;
            entity.Creator = model.Creator;
            entity.Modifier = model.Modifier;
            entity.CreateDate = model.CreateDate;
            entity.Modidate = model.Modidate;
            entity.Status = model.Status ? 1 : 0;
            entity.Item01 = model.Item01;
            entity.Item02 = model.Item02;
            entity.Item03 = model.Item03;
            entity.Item04 = model.Item04;
            entity.Item05 = model.Item05;

            PROD_GROUP_INDEXRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete( string ID )
        {
            var model = PROD_GROUP_INDEXList.FirstOrDefault(t => t.ID == ID );

            PROD_GROUP_INDEXRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

