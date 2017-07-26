//------------------------------------------------------------------------------
// <copyright file="EOrderDetailService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/3/22 15:19:02
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Collections.Generic;

using Quick.Framework.Tool;
using Ecomm.Domain.Models.InetApp;
using Ecomm.Core.Repository.InetApp;
using Ecomm.Site.Models;
using Ecomm.Site.Models.InetApp.EOrderDetail;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.InetApp.Impl
{
	/// <summary>
    /// 服务层实现 —— EOrderDetailService
    /// </summary>
    [Export(typeof(IEOrderDetailService))]
    public class EOrderDetailService : CoreServiceBase, IEOrderDetailService
    {
        #region 属性

        [Import]
        public IEOrderDetailRepository EOrderDetailRepository { get; set; }

        public IQueryable<EOrderDetail> EOrderDetailList
        {
            get { return EOrderDetailRepository.Entities; }
        }

        #endregion

        #region 公共方法
        public IEnumerable<EOrderDetail_MASTER> QueryEntities(int orderId)
        {
            return EOrderDetailRepository.QueryEntities(orderId);
        }
        public OperationResult Insert(EOrderDetailModel model)
        {
            var entity = new EOrderDetail
            {
                OrderType = model.OrderType,
                OrderID = model.OrderID,
                Sn = model.Sn,
                Sku = model.Sku,
                Skudesc = model.Skudesc,
                WareId = model.WareId,
                Unit = model.Unit,
                UnitCost = model.UnitCost,
                UnitPrice = model.UnitPrice,
                QtyonSales = model.QtyonSales,
                Orderqty = model.Orderqty,
                Bkoqty = model.Bkoqty,
                Fullqty = model.Fullqty,
                Discount = model.Discount,
                Tax = model.Tax,
                OrderStats = model.OrderStats,
                CommText = model.CommText,
                FullDate = model.FullDate,
                CretDate = model.CretDate,
                ModiDate = model.ModiDate,
                CretID = model.CretID,
                Class1 = model.Class1,
            };
            EOrderDetailRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public int InsertEOrderDetail(EOrderDetailModel model)
        {
            var entity = new EOrderDetail
            {
                OrderType = model.OrderType,
                OrderID = model.OrderID,
                Sn = model.Sn,
                Sku = model.Sku,
                Skudesc = model.Skudesc,
                WareId = model.WareId,
                Unit = model.Unit,
                UnitCost = model.UnitCost,
                UnitPrice = model.UnitPrice,
                QtyonSales = model.QtyonSales,
                Orderqty = model.Orderqty,
                Bkoqty = model.Bkoqty,
                Fullqty = model.Fullqty,
                Discount = model.Discount,
                Tax = model.Tax,
                OrderStats = model.OrderStats,
                CommText = model.CommText,
                FullDate = model.FullDate,
                CretDate = model.CretDate,
                ModiDate = model.ModiDate,
                CretID = model.CretID,
                Class1 = model.Class1,
            };
            return EOrderDetailRepository.Insert(entity);
        }

        public OperationResult Update(UpdateEOrderDetailModel model)
        {
			var entity = EOrderDetailList.First(t => t.OrderID == model.OrderID && t.Sku == model.Sku);
            entity.OrderType = model.OrderType;
            entity.OrderID = model.OrderID;
            entity.Sn = model.Sn;
            entity.Sku = model.Sku;
            entity.Skudesc = model.Skudesc;
            entity.WareId = model.WareId;
            entity.Unit = model.Unit;
            entity.UnitCost = model.UnitCost;
            entity.UnitPrice = model.UnitPrice;
            entity.QtyonSales = model.QtyonSales;
            entity.Orderqty = model.Orderqty;
            entity.Bkoqty = model.Bkoqty;
            entity.Fullqty = model.Fullqty;
            entity.Discount = model.Discount;
            entity.Tax = model.Tax;
            entity.OrderStats = model.OrderStats;
            entity.CommText = model.CommText;
            entity.FullDate = model.FullDate;
            entity.CretDate = model.CretDate;
            entity.ModiDate = model.ModiDate;
            entity.CretID = model.CretID;
            entity.Class1 = model.Class1;

            EOrderDetailRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(int  OrderID,string  Sku)
        {
            var model = EOrderDetailList.FirstOrDefault(t => t.OrderID == OrderID && t.Sku == Sku);

            EOrderDetailRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        public void UpdateOrderDetailQty(int orderID, string sku, float qty) {
            var model = EOrderDetailList.FirstOrDefault(t => t.OrderID == orderID && t.Sku == sku);
            model.Orderqty = qty;
            EOrderDetailRepository.Update(model);
        }

        public int DeleteOrderDetail(int orderID, string sku) {

            var model = EOrderDetailList.FirstOrDefault(t => t.OrderID == orderID && t.Sku == sku);

            return EOrderDetailRepository.Delete(model);
        }

        #endregion
    }
}

