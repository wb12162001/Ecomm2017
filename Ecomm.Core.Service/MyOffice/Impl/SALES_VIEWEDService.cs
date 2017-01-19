//------------------------------------------------------------------------------
// <copyright file="SALES_VIEWEDService.cs">
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
using Ecomm.Site.Models.MyOffice.SALES_VIEWED;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.MyOffice.Impl
{
	/// <summary>
    /// 服务层实现 —— SALES_VIEWEDService
    /// </summary>
    [Export(typeof(ISALES_VIEWEDService))]
    public class SALES_VIEWEDService : CoreServiceBase, ISALES_VIEWEDService
    {
        #region 属性

        [Import]
        public ISALES_VIEWEDRepository SALES_VIEWEDRepository { get; set; }

        public IQueryable<SALES_VIEWED> SALES_VIEWEDList
        {
            get { return SALES_VIEWEDRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(SALES_VIEWEDModel model)
        {
            var entity = new SALES_VIEWED
            {
                ID = model.ID,
                ProductNo = model.ProductNo,
                CustomerID = model.CustomerID,
                ContactID = model.ContactID,
                CreateDate = model.CreateDate,
                ModiDate = model.ModiDate,
                Creator = model.Creator,
                Modifier = model.Modifier,
                RowID = model.RowID,
            };
            SALES_VIEWEDRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateSALES_VIEWEDModel model)
        {
			var entity = SALES_VIEWEDList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.ProductNo = model.ProductNo;
            entity.CustomerID = model.CustomerID;
            entity.ContactID = model.ContactID;
            entity.CreateDate = model.CreateDate;
            entity.ModiDate = model.ModiDate;
            entity.Creator = model.Creator;
            entity.Modifier = model.Modifier;
            entity.RowID = model.RowID;

            SALES_VIEWEDRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = SALES_VIEWEDList.FirstOrDefault(t => t.ID == ID);

            SALES_VIEWEDRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

