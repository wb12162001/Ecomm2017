//------------------------------------------------------------------------------
// <copyright file="SALES_EORDERDETAILSService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/12 16:18:05
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
using Ecomm.Site.Models.MyOffice.SALES_EORDERDETAILS;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.MyOffice.Impl
{
	/// <summary>
    /// 服务层实现 —— SALES_EORDERDETAILSService
    /// </summary>
    [Export(typeof(ISALES_EORDERDETAILSService))]
    public class SALES_EORDERDETAILSService : CoreServiceBase, ISALES_EORDERDETAILSService
    {
        #region 属性

        [Import]
        public ISALES_EORDERDETAILSRepository SALES_EORDERDETAILSRepository { get; set; }

        public IQueryable<SALES_EORDERDETAILS> SALES_EORDERDETAILSList
        {
            get { return SALES_EORDERDETAILSRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(SALES_EORDERDETAILSModel model)
        {
            var entity = new SALES_EORDERDETAILS
            {
                OrderID = model.OrderID,
                ProductNo = model.ProductNo,
                OrderQty = model.OrderQty,
                Unit = model.Unit,
                UnitCost = model.UnitCost,
                UnitPrice = model.UnitPrice,
                Tax = model.Tax,
                Freight = model.Freight,
                CommText = model.CommText,
                Creator = model.Creator,
                Modifier = model.Modifier,
                ModiDate = model.ModiDate,
                CreateDate = model.CreateDate,
                RowID = model.RowID,
                Status = model.Status,
                Item01 = model.Item01,
                Item02 = model.Item02,
                Item03 = model.Item03,
                Item04 = model.Item04,
                Item05 = model.Item05,
                UnitPType = model.UnitPType,
            };
            SALES_EORDERDETAILSRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateSALES_EORDERDETAILSModel model)
        {
			var entity = SALES_EORDERDETAILSList.First(t => t.OrderID == model.OrderID && t.ProductNo == model.ProductNo);
            entity.OrderID = model.OrderID;
            entity.ProductNo = model.ProductNo;
            entity.OrderQty = model.OrderQty;
            entity.Unit = model.Unit;
            entity.UnitCost = model.UnitCost;
            entity.UnitPrice = model.UnitPrice;
            entity.Tax = model.Tax;
            entity.Freight = model.Freight;
            entity.CommText = model.CommText;
            entity.Creator = model.Creator;
            entity.Modifier = model.Modifier;
            entity.ModiDate = model.ModiDate;
            entity.CreateDate = model.CreateDate;
            entity.RowID = model.RowID;
            entity.Status = model.Status;
            entity.Item01 = model.Item01;
            entity.Item02 = model.Item02;
            entity.Item03 = model.Item03;
            entity.Item04 = model.Item04;
            entity.Item05 = model.Item05;
            entity.UnitPType = model.UnitPType;

            SALES_EORDERDETAILSRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  OrderID,string  ProductNo)
        {
            var model = SALES_EORDERDETAILSList.FirstOrDefault(t => t.OrderID == OrderID && t.ProductNo == ProductNo);

            SALES_EORDERDETAILSRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

