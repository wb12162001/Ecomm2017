//------------------------------------------------------------------------------
// <copyright file="SALES_QUOTEService.cs">
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
using Ecomm.Site.Models.MyOffice.SALES_QUOTE;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.MyOffice.Impl
{
	/// <summary>
    /// 服务层实现 —— SALES_QUOTEService
    /// </summary>
    [Export(typeof(ISALES_QUOTEService))]
    public class SALES_QUOTEService : CoreServiceBase, ISALES_QUOTEService
    {
        #region 属性

        [Import]
        public ISALES_QUOTERepository SALES_QUOTERepository { get; set; }

        public IQueryable<SALES_QUOTE> SALES_QUOTEList
        {
            get { return SALES_QUOTERepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(SALES_QUOTEModel model)
        {
            var entity = new SALES_QUOTE
            {
                ID = model.ID,
                CustomerID = model.CustomerID,
                ContactID = model.ContactID,
                ProductNo = model.ProductNo,
                Unit = model.Unit,
                UnitPrice = model.UnitPrice,
                CreateDate = model.CreateDate,
                Creator = model.Creator,
                CommText = model.CommText,
                Status = model.Status,
                RowID = model.RowID,
            };
            SALES_QUOTERepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateSALES_QUOTEModel model)
        {
			var entity = SALES_QUOTEList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.CustomerID = model.CustomerID;
            entity.ContactID = model.ContactID;
            entity.ProductNo = model.ProductNo;
            entity.Unit = model.Unit;
            entity.UnitPrice = model.UnitPrice;
            entity.CreateDate = model.CreateDate;
            entity.Creator = model.Creator;
            entity.CommText = model.CommText;
            entity.Status = model.Status;
            entity.RowID = model.RowID;

            SALES_QUOTERepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = SALES_QUOTEList.FirstOrDefault(t => t.ID == ID);

            SALES_QUOTERepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

