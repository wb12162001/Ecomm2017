//------------------------------------------------------------------------------
// <copyright file="SYS_DICTIONARY_DATAService.cs">
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
using Ecomm.Site.Models.SysConfig.SYS_DICTIONARY_DATA;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.SysConfig.Impl
{
	/// <summary>
    /// 服务层实现 —— SYS_DICTIONARY_DATAService
    /// </summary>
    [Export(typeof(ISYS_DICTIONARY_DATAService))]
    public class SYS_DICTIONARY_DATAService : CoreServiceBase, ISYS_DICTIONARY_DATAService
    {
        #region 属性

        [Import]
        public ISYS_DICTIONARY_DATARepository SYS_DICTIONARY_DATARepository { get; set; }

        public IQueryable<SYS_DICTIONARY_DATA> SYS_DICTIONARY_DATAList
        {
            get { return SYS_DICTIONARY_DATARepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(SYS_DICTIONARY_DATAModel model)
        {
            var entity = new SYS_DICTIONARY_DATA
            {
                ID = model.ID,
                DictionaryValue = model.DictionaryValue,
                DictDataName = model.DictDataName,
                DictDataValue = model.DictDataValue,
                DictDataType = model.DictDataType,
                IsFixed = model.IsFixed,
                IsCancel = model.IsCancel,
                DictParentID = model.DictParentID,
                CreateDate = model.CreateDate,
                ModiDate = model.ModiDate,
                Remark = model.Remark,
                DisplayOrder = model.DisplayOrder,
            };
            SYS_DICTIONARY_DATARepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateSYS_DICTIONARY_DATAModel model)
        {
			var entity = SYS_DICTIONARY_DATAList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.DictionaryValue = model.DictionaryValue;
            entity.DictDataName = model.DictDataName;
            entity.DictDataValue = model.DictDataValue;
            entity.DictDataType = model.DictDataType;
            entity.IsFixed = model.IsFixed;
            entity.IsCancel = model.IsCancel;
            entity.DictParentID = model.DictParentID;
            entity.CreateDate = model.CreateDate;
            entity.ModiDate = model.ModiDate;
            entity.Remark = model.Remark;
            entity.DisplayOrder = model.DisplayOrder;

            SYS_DICTIONARY_DATARepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = SYS_DICTIONARY_DATAList.FirstOrDefault(t => t.ID == ID);

            SYS_DICTIONARY_DATARepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

