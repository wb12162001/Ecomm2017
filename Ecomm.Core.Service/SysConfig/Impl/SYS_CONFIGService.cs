//------------------------------------------------------------------------------
// <copyright file="SYS_CONFIGService.cs">
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
using Ecomm.Site.Models.SysConfig.SYS_CONFIG;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.SysConfig.Impl
{
	/// <summary>
    /// 服务层实现 —— SYS_CONFIGService
    /// </summary>
    [Export(typeof(ISYS_CONFIGService))]
    public class SYS_CONFIGService : CoreServiceBase, ISYS_CONFIGService
    {
        #region 属性

        [Import]
        public ISYS_CONFIGRepository SYS_CONFIGRepository { get; set; }

        public IQueryable<SYS_CONFIG> SYS_CONFIGList
        {
            get { return SYS_CONFIGRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(SYS_CONFIGModel model)
        {
            var entity = new SYS_CONFIG
            {
                ID = model.ID,
                ConfigName = model.ConfigName,
                ConfigContent = model.ConfigContent,
                FieldProperty = model.FieldProperty,
                IsSystem = model.IsSystem,
            };
            SYS_CONFIGRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateSYS_CONFIGModel model)
        {
			var entity = SYS_CONFIGList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.ConfigName = model.ConfigName;
            entity.ConfigContent = model.ConfigContent;
            entity.FieldProperty = model.FieldProperty;
            entity.IsSystem = model.IsSystem;

            SYS_CONFIGRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = SYS_CONFIGList.FirstOrDefault(t => t.ID == ID);

            SYS_CONFIGRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

