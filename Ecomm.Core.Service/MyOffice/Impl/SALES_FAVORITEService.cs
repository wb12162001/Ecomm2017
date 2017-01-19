//------------------------------------------------------------------------------
// <copyright file="SALES_FAVORITEService.cs">
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
using Ecomm.Site.Models.MyOffice.SALES_FAVORITE;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.MyOffice.Impl
{
	/// <summary>
    /// 服务层实现 —— SALES_FAVORITEService
    /// </summary>
    [Export(typeof(ISALES_FAVORITEService))]
    public class SALES_FAVORITEService : CoreServiceBase, ISALES_FAVORITEService
    {
        #region 属性

        [Import]
        public ISALES_FAVORITERepository SALES_FAVORITERepository { get; set; }

        public IQueryable<SALES_FAVORITE> SALES_FAVORITEList
        {
            get { return SALES_FAVORITERepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(SALES_FAVORITEModel model)
        {
            var entity = new SALES_FAVORITE
            {
                ID = model.ID,
                FavFolderID = model.FavFolderID,
                ProductNo = model.ProductNo,
                CustomerID = model.CustomerID,
                ContactID = model.ContactID,
                CreateDate = model.CreateDate,
                ModiDate = model.ModiDate,
                Creator = model.Creator,
                Modifier = model.Modifier,
                Status = model.Status,
            };
            SALES_FAVORITERepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateSALES_FAVORITEModel model)
        {
			var entity = SALES_FAVORITEList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.FavFolderID = model.FavFolderID;
            entity.ProductNo = model.ProductNo;
            entity.CustomerID = model.CustomerID;
            entity.ContactID = model.ContactID;
            entity.CreateDate = model.CreateDate;
            entity.ModiDate = model.ModiDate;
            entity.Creator = model.Creator;
            entity.Modifier = model.Modifier;
            entity.Status = model.Status;

            SALES_FAVORITERepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = SALES_FAVORITEList.FirstOrDefault(t => t.ID == ID);

            SALES_FAVORITERepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

