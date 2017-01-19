//------------------------------------------------------------------------------
// <copyright file="SALES_FAVFOLDERService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/17 15:51:35
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Collections.Generic;

using Quick.Framework.Tool;
using Ecomm.Domain.Models.MyOffice;
using Ecomm.Core.Repository.MyOffice;
using Ecomm.Site.Models;
using Ecomm.Site.Models.MyOffice.SALES_FAVFOLDER;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.MyOffice.Impl
{
	/// <summary>
    /// 服务层实现 —— SALES_FAVFOLDERService
    /// </summary>
    [Export(typeof(ISALES_FAVFOLDERService))]
    public class SALES_FAVFOLDERService : CoreServiceBase, ISALES_FAVFOLDERService
    {
        #region 属性

        [Import]
        public ISALES_FAVFOLDERRepository SALES_FAVFOLDERRepository { get; set; }

        public IQueryable<SALES_FAVFOLDER> SALES_FAVFOLDERList
        {
            get { return SALES_FAVFOLDERRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(SALES_FAVFOLDERModel model)
        {
            var entity = new SALES_FAVFOLDER
            {
                ID = model.ID,
                FolderName = model.FolderName,
                CustomerID = model.CustomerID,
                ContactID = model.ContactID,
                Creator = model.Creator,
                Modifier = model.Modifier,
                CreateDate = model.CreateDate,
                ModiDate = model.ModiDate,
                Status = model.Status,
            };
            SALES_FAVFOLDERRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateSALES_FAVFOLDERModel model)
        {
			var entity = SALES_FAVFOLDERList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.FolderName = model.FolderName;
            entity.CustomerID = model.CustomerID;
            entity.ContactID = model.ContactID;
            entity.Creator = model.Creator;
            entity.Modifier = model.Modifier;
            entity.CreateDate = model.CreateDate;
            entity.ModiDate = model.ModiDate;
            entity.Status = model.Status;

            SALES_FAVFOLDERRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = SALES_FAVFOLDERList.FirstOrDefault(t => t.ID == ID);

            SALES_FAVFOLDERRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

