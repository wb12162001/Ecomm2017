//------------------------------------------------------------------------------
// <copyright file="SYS_DICTIONARYService.cs">
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
using Ecomm.Site.Models.SysConfig.SYS_DICTIONARY;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.SysConfig.Impl
{
	/// <summary>
    /// 服务层实现 —— SYS_DICTIONARYService
    /// </summary>
    [Export(typeof(ISYS_DICTIONARYService))]
    public class SYS_DICTIONARYService : CoreServiceBase, ISYS_DICTIONARYService
    {
        #region 属性

        [Import]
        public ISYS_DICTIONARYRepository SYS_DICTIONARYRepository { get; set; }

        public IQueryable<SYS_DICTIONARY> SYS_DICTIONARYList
        {
            get { return SYS_DICTIONARYRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(SYS_DICTIONARYModel model)
        {
            var entity = new SYS_DICTIONARY
            {
                DictionaryName = model.DictionaryName,
                DictionaryValue = model.DictionaryValue,
                Remark = model.Remark,
            };
            SYS_DICTIONARYRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateSYS_DICTIONARYModel model)
        {
			var entity = SYS_DICTIONARYList.First(t => t.DictionaryValue == model.DictionaryValue);
            entity.DictionaryName = model.DictionaryName;
            entity.DictionaryValue = model.DictionaryValue;
            entity.Remark = model.Remark;

            SYS_DICTIONARYRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(int  DictionaryValue)
        {
            var model = SYS_DICTIONARYList.FirstOrDefault(t => t.DictionaryValue == DictionaryValue);

            SYS_DICTIONARYRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

