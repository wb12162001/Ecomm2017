//------------------------------------------------------------------------------
// <copyright file="SYS_PROPERTYService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/5 15:15:55
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
using Ecomm.Site.Models.SysConfig.SYS_PROPERTY;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.SysConfig.Impl
{
	/// <summary>
    /// 服务层实现 —— SYS_PROPERTYService
    /// </summary>
    [Export(typeof(ISYS_PROPERTYService))]
    public class SYS_PROPERTYService : CoreServiceBase, ISYS_PROPERTYService
    {
        #region 属性

        [Import]
        public ISYS_PROPERTYRepository SYS_PROPERTYRepository { get; set; }

        public IQueryable<SYS_PROPERTY> SYS_PROPERTYList
        {
            get { return SYS_PROPERTYRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(SYS_PROPERTYModel model)
        {
            var entity = new SYS_PROPERTY
            {
                PropertyID = model.PropertyID,
                PropertyName = model.PropertyName,
                Remark = model.Remark,
                Status = model.Status,
            };
            SYS_PROPERTYRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateSYS_PROPERTYModel model)
        {
			var entity = SYS_PROPERTYList.First(t => t.PropertyID == model.PropertyID);
            entity.PropertyID = model.PropertyID;
            entity.PropertyName = model.PropertyName;
            entity.Remark = model.Remark;
            entity.Status = model.Status;

            SYS_PROPERTYRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  PropertyID)
        {
            var model = SYS_PROPERTYList.FirstOrDefault(t => t.PropertyID == PropertyID);

            SYS_PROPERTYRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

