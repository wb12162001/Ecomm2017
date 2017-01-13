//------------------------------------------------------------------------------
// <copyright file="INFOR_CATEGORIESService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/5 15:15:54
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Collections.Generic;

using Quick.Framework.Tool;
using Ecomm.Domain.Models.SysConfig;
using Ecomm.Core.Repository.SysConfig;
using Ecomm.Site.Models;
using Ecomm.Site.Models.SysConfig.INFOR_CATEGORIES;
using Quick.Framework.Common.SecurityHelper;


namespace Ecomm.Core.Service.SysConfig.Impl
{
	/// <summary>
    /// 服务层实现 —— INFOR_CATEGORIESService
    /// </summary>
    [Export(typeof(IINFOR_CATEGORIESService))]
    public class INFOR_CATEGORIESService : CoreServiceBase, IINFOR_CATEGORIESService
    {
        #region 属性

        [Import]
        public IINFOR_CATEGORIESRepository INFOR_CATEGORIESRepository { get; set; }

        public IQueryable<INFOR_CATEGORIES> INFOR_CATEGORIESList
        {
            get { return INFOR_CATEGORIESRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(INFOR_CATEGORIESModel model)
        {
            var entity = new INFOR_CATEGORIES
            {
                ID = model.ID,
                InforCategoryName = model.InforCategoryName,
                DisplayOrder = model.DisplayOrder,
                ParentID = model.ParentID,
                Clevel = model.Clevel,
                Status = model.Status,
                Item01 = model.Item01,
                Item02 = model.Item02,
                Item03 = model.Item03,
                Item04 = model.Item04,
                Item05 = model.Item05,
            };
            INFOR_CATEGORIESRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(INFOR_CATEGORIESModel model)
        {
			var entity = INFOR_CATEGORIESList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.InforCategoryName = model.InforCategoryName;
            entity.DisplayOrder = model.DisplayOrder;
            entity.ParentID = model.ParentID;
            entity.Clevel = model.Clevel;
            entity.Status = model.Status;
            entity.Item01 = model.Item01;
            entity.Item02 = model.Item02;
            entity.Item03 = model.Item03;
            entity.Item04 = model.Item04;
            entity.Item05 = model.Item05;

            INFOR_CATEGORIESRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = INFOR_CATEGORIESList.FirstOrDefault(t => t.ID == ID);

            INFOR_CATEGORIESRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }


        #endregion
    }
}

