//------------------------------------------------------------------------------
// <copyright file="SALES_EBASKETService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/12 16:18:04
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
using Ecomm.Site.Models.MyOffice.SALES_EBASKET;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.MyOffice.Impl
{
	/// <summary>
    /// 服务层实现 —— SALES_EBASKETService
    /// </summary>
    [Export(typeof(ISALES_EBASKETService))]
    public class SALES_EBASKETService : CoreServiceBase, ISALES_EBASKETService
    {
        #region 属性

        [Import]
        public ISALES_EBASKETRepository SALES_EBASKETRepository { get; set; }

        public IQueryable<SALES_EBASKET> SALES_EBASKETList
        {
            get { return SALES_EBASKETRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(SALES_EBASKETModel model)
        {
            var entity = new SALES_EBASKET
            {
                ID = model.ID,
                CustomerID = model.CustomerID,
                ContactID = model.ContactID,
                ProductNo = model.ProductNo,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
                Unit = model.Unit,
                Creator = model.Creator,
                Modifier = model.Modifier,
                CreateDate = model.CreateDate,
                ModiDate = model.ModiDate,
                MakeOrderID = model.MakeOrderID,
                RowID = model.RowID,
                Status = model.Status,
                UnitPType = model.UnitPType,
            };
            SALES_EBASKETRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateSALES_EBASKETModel model)
        {
			var entity = SALES_EBASKETList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.CustomerID = model.CustomerID;
            entity.ContactID = model.ContactID;
            entity.ProductNo = model.ProductNo;
            entity.Quantity = model.Quantity;
            entity.UnitPrice = model.UnitPrice;
            entity.Unit = model.Unit;
            entity.Creator = model.Creator;
            entity.Modifier = model.Modifier;
            entity.CreateDate = model.CreateDate;
            entity.ModiDate = model.ModiDate;
            entity.MakeOrderID = model.MakeOrderID;
            entity.RowID = model.RowID;
            entity.Status = model.Status;
            entity.UnitPType = model.UnitPType;

            SALES_EBASKETRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = SALES_EBASKETList.FirstOrDefault(t => t.ID == ID);

            SALES_EBASKETRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

