//------------------------------------------------------------------------------
// <copyright file="SALES_CLEARANCEService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/17 15:51:34
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
using Ecomm.Site.Models.MyOffice.SALES_CLEARANCE;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.MyOffice.Impl
{
	/// <summary>
    /// 服务层实现 —— SALES_CLEARANCEService
    /// </summary>
    [Export(typeof(ISALES_CLEARANCEService))]
    public class SALES_CLEARANCEService : CoreServiceBase, ISALES_CLEARANCEService
    {
        #region 属性

        [Import]
        public ISALES_CLEARANCERepository SALES_CLEARANCERepository { get; set; }

        public IQueryable<SALES_CLEARANCE> SALES_CLEARANCEList
        {
            get { return SALES_CLEARANCERepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(SALES_CLEARANCEModel model)
        {
            var entity = new SALES_CLEARANCE
            {
                ID = model.ID,
                Name = model.Name,
                ImgFile = model.ImgFile,
                Notes = model.Notes,
                SortNo = model.SortNo,
                CreateDate = model.CreateDate,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Status = model.Status,
            };
            SALES_CLEARANCERepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateSALES_CLEARANCEModel model)
        {
			var entity = SALES_CLEARANCEList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.Name = model.Name;
            entity.ImgFile = model.ImgFile;
            entity.Notes = model.Notes;
            entity.SortNo = model.SortNo;
            entity.CreateDate = model.CreateDate;
            entity.StartDate = model.StartDate;
            entity.EndDate = model.EndDate;
            entity.Status = model.Status;

            SALES_CLEARANCERepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = SALES_CLEARANCEList.FirstOrDefault(t => t.ID == ID);

            SALES_CLEARANCERepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

