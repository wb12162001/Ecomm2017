//------------------------------------------------------------------------------
// <copyright file="EOrderService.cs">
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
using Ecomm.Site.Models.InetApp.EOrder;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.InetApp.Impl
{
    /// <summary>
    /// 服务层实现 —— EOrderService
    /// </summary>
    [Export(typeof(IEOrderService))]
    public class EOrderService : CoreServiceBase, IEOrderService
    {
        #region 属性

        [Import]
        public IEOrderRepository EOrderRepository { get; set; }

        public IQueryable<EOrder> EOrderList
        {
            get { return EOrderRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(EOrderModel model)
        {
            var entity = new EOrder
            {
                OrderType = model.OrderType,
                //OrderID = model.OrderID,
                ORIGTYPE = model.ORIGTYPE,
                ORIGNUMB = model.ORIGNUMB,
                BACHNUMB = model.BACHNUMB,
                CustID = model.CustID,
                ShopID = model.ShopID,
                EmplID = model.EmplID,
                OrderDate = model.OrderDate,
                RequiredDate = model.RequiredDate,
                ShippedDate = model.ShippedDate,
                ShipID = model.ShipID,
                Freight = model.Freight,
                Ship_Name = model.Ship_Name,
                Ship_Address = model.Ship_Address,
                Ship_City = model.Ship_City,
                TerrID = model.TerrID,
                Ship_zip = model.Ship_zip,
                Ship_Country = model.Ship_Country,
                Ship_state = model.Ship_state,
                Ship_phone = model.Ship_phone,
                Auth_code = model.Auth_code,
                Bill_name = model.Bill_name,
                Bill_address = model.Bill_address,
                Bill_city = model.Bill_city,
                Bill_state = model.Bill_state,
                Bill_zip = model.Bill_zip,
                Bill_country = model.Bill_country,
                Bill_phone = model.Bill_phone,
                RepID = model.RepID,
                OrderStats = model.OrderStats,
                VoidStats = model.VoidStats,
                CommText = model.CommText,
                CretDate = model.CretDate,
                ModiDate = model.ModiDate,
                CretID = model.CretID,
                Cc_name = model.Cc_name,
                Cc_expmonth = model.Cc_expmonth,
                Cc_expyear = model.Cc_expyear,
                Cc_number = model.Cc_number,
                Cc_type = model.Cc_type,
                Verify_with = model.Verify_with,
                Pono = model.Pono,
                Prnstats = model.Prnstats,
                PROC_STATUS = model.PROC_STATUS,
                Miscellaneous = model.Miscellaneous,
            };
            EOrderRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(EOrderModel model)
        {
            var entity = EOrderList.First(t => t.OrderID == model.OrderID);
            entity.OrderType = model.OrderType;
            entity.OrderID = model.OrderID;
            entity.ORIGTYPE = model.ORIGTYPE;
            entity.ORIGNUMB = model.ORIGNUMB;
            entity.BACHNUMB = model.BACHNUMB;
            entity.CustID = model.CustID;
            entity.ShopID = model.ShopID;
            entity.EmplID = model.EmplID;
            entity.OrderDate = model.OrderDate;
            entity.RequiredDate = model.RequiredDate;
            entity.ShippedDate = model.ShippedDate;
            entity.ShipID = model.ShipID;
            entity.Freight = model.Freight;
            entity.Ship_Name = model.Ship_Name;
            entity.Ship_Address = model.Ship_Address;
            entity.Ship_City = model.Ship_City;
            entity.TerrID = model.TerrID;
            entity.Ship_zip = model.Ship_zip;
            entity.Ship_Country = model.Ship_Country;
            entity.Ship_state = model.Ship_state;
            entity.Ship_phone = model.Ship_phone;
            entity.Auth_code = model.Auth_code;
            entity.Bill_name = model.Bill_name;
            entity.Bill_address = model.Bill_address;
            entity.Bill_city = model.Bill_city;
            entity.Bill_state = model.Bill_state;
            entity.Bill_zip = model.Bill_zip;
            entity.Bill_country = model.Bill_country;
            entity.Bill_phone = model.Bill_phone;
            entity.RepID = model.RepID;
            entity.OrderStats = model.OrderStats;
            entity.VoidStats = model.VoidStats;
            entity.CommText = model.CommText;
            entity.CretDate = model.CretDate;
            entity.ModiDate = model.ModiDate;
            entity.CretID = model.CretID;
            entity.Cc_name = model.Cc_name;
            entity.Cc_expmonth = model.Cc_expmonth;
            entity.Cc_expyear = model.Cc_expyear;
            entity.Cc_number = model.Cc_number;
            entity.Cc_type = model.Cc_type;
            entity.Verify_with = model.Verify_with;
            entity.Pono = model.Pono;
            entity.Prnstats = model.Prnstats;
            entity.PROC_STATUS = model.PROC_STATUS;
            entity.Miscellaneous = model.Miscellaneous;

            EOrderRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(int OrderID)
        {
            var model = EOrderList.FirstOrDefault(t => t.OrderID == OrderID);

            EOrderRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }
        public int InsertOrder(EOrderModel model)
        {
            var entity = new EOrder
            {
                OrderType = model.OrderType,
                //OrderID = model.OrderID,
                ORIGTYPE = model.ORIGTYPE,
                ORIGNUMB = model.ORIGNUMB,
                BACHNUMB = model.BACHNUMB,
                CustID = model.CustID,
                ShopID = model.ShopID,
                EmplID = model.EmplID,
                OrderDate = model.OrderDate,
                RequiredDate = model.RequiredDate,
                ShippedDate = model.ShippedDate,
                ShipID = model.ShipID,
                Freight = model.Freight,
                Ship_Name = model.Ship_Name,
                Ship_Address = model.Ship_Address,
                Ship_City = model.Ship_City,
                TerrID = model.TerrID,
                Ship_zip = model.Ship_zip,
                Ship_Country = model.Ship_Country,
                Ship_state = model.Ship_state,
                Ship_phone = model.Ship_phone,
                Auth_code = model.Auth_code,
                Bill_name = model.Bill_name,
                Bill_address = model.Bill_address,
                Bill_city = model.Bill_city,
                Bill_state = model.Bill_state,
                Bill_zip = model.Bill_zip,
                Bill_country = model.Bill_country,
                Bill_phone = model.Bill_phone,
                RepID = model.RepID,
                OrderStats = model.OrderStats,
                VoidStats = model.VoidStats,
                CommText = model.CommText,
                CretDate = model.CretDate,
                ModiDate = model.ModiDate,
                CretID = model.CretID,
                Cc_name = model.Cc_name,
                Cc_expmonth = model.Cc_expmonth,
                Cc_expyear = model.Cc_expyear,
                Cc_number = model.Cc_number,
                Cc_type = model.Cc_type,
                Verify_with = model.Verify_with,
                Pono = model.Pono,
                Prnstats = model.Prnstats,
                PROC_STATUS = model.PROC_STATUS,
                Miscellaneous = model.Miscellaneous,
            };
            //EOrderRepository.Insert(entity); //这个返回影响的行数
            return EOrderRepository.InsertOrder(entity);
        }

        /// <summary>
        /// 获取hold 系统当前月的订单
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="shipId"></param>
        /// <param name="orderDt"></param>
        /// <returns></returns>
        public IEnumerable<double> GetOrdersByCurrentMonth(string custId, string shipId)
        {
            return EOrderRepository.GetOrdersByCurrentMonth(custId, shipId);
        }
        #endregion
    }
}

