//------------------------------------------------------------------------------
// <copyright file="SALES_ESIORDERFORMService.cs">
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
using Ecomm.Site.Models.MyOffice.SALES_ESIORDERFORM;
using Quick.Framework.Common.SecurityHelper;
using Ecomm.Core.Service.EpSnell;

namespace Ecomm.Core.Service.MyOffice.Impl
{
    /// <summary>
    /// 服务层实现 —— SALES_ESIORDERFORMService
    /// </summary>
    [Export(typeof(ISALES_ESIORDERFORMService))]
    public class SALES_ESIORDERFORMService : CoreServiceBase, ISALES_ESIORDERFORMService
    {
        #region 属性

        [Import]
        public ISALES_ESIORDERFORMRepository SALES_ESIORDERFORMRepository { get; set; }

        [Import]
        public IRela_account_locationService Rela_account_locationService { get; set; }

        public IQueryable<SALES_ESIORDERFORM> SALES_ESIORDERFORMList
        {
            get { return SALES_ESIORDERFORMRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public IEnumerable<SALES_ESIORDERFORM_MASTER> QueryEntities(int count, string strWhere, string strOrder)
        {
            return SALES_ESIORDERFORMRepository.QueryEntities(count, strWhere, strOrder);
        }

        public OperationResult Insert(SALES_ESIORDERFORMModel model)
        {
            var entity = new SALES_ESIORDERFORM
            {
                CustomerID = model.CustomerID,
                ProductNo = model.ProductNo,
                ShipTo = model.ShipTo,
                Qty0 = model.Qty0,
                Qty1 = model.Qty1,
                Qty2 = model.Qty2,
                Qty3 = model.Qty3,
                Qty4 = model.Qty4,
                Qty5 = model.Qty5,
                Qty6 = model.Qty6,
                Qty7 = model.Qty7,
                Qty8 = model.Qty8,
                Qty9 = model.Qty9,
                Qty10 = model.Qty10,
                Qty11 = model.Qty11,
                Qty12 = model.Qty12,
                Qty13 = model.Qty13,
                QtyTotal = model.QtyTotal,
                Cost0 = model.Cost0,
                Cost1 = model.Cost1,
                Cost2 = model.Cost2,
                Cost3 = model.Cost3,
                Cost4 = model.Cost4,
                Cost5 = model.Cost5,
                Cost6 = model.Cost6,
                Cost7 = model.Cost7,
                Cost8 = model.Cost8,
                Cost9 = model.Cost9,
                Cost10 = model.Cost10,
                Cost11 = model.Cost11,
                Cost12 = model.Cost12,
                Cost13 = model.Cost13,
                CostTotal = model.CostTotal,
                Price0 = model.Price0,
                Price1 = model.Price1,
                Price2 = model.Price2,
                Price3 = model.Price3,
                Price4 = model.Price4,
                Price5 = model.Price5,
                Price6 = model.Price6,
                Price7 = model.Price7,
                Price8 = model.Price8,
                Price9 = model.Price9,
                Price10 = model.Price10,
                Price11 = model.Price11,
                Price12 = model.Price12,
                Price13 = model.Price13,
                PriceTotal = model.PriceTotal,
                ProdCategoryCode = model.ProdCategoryCode,
                IDate = model.IDate,
                ContactID = model.ContactID,
                CurrentPrice = model.CurrentPrice,
                PriceType = model.PriceType,
                Status = model.Status,
                Forecast = model.Forecast,
            };
            SALES_ESIORDERFORMRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateSALES_ESIORDERFORMModel model)
        {
            var entity = SALES_ESIORDERFORMList.First(t => t.CustomerID == model.CustomerID && t.ProductNo == model.ProductNo && t.ShipTo == model.ShipTo);
            entity.CustomerID = model.CustomerID;
            entity.ProductNo = model.ProductNo;
            entity.ShipTo = model.ShipTo;
            entity.Qty0 = model.Qty0;
            entity.Qty1 = model.Qty1;
            entity.Qty2 = model.Qty2;
            entity.Qty3 = model.Qty3;
            entity.Qty4 = model.Qty4;
            entity.Qty5 = model.Qty5;
            entity.Qty6 = model.Qty6;
            entity.Qty7 = model.Qty7;
            entity.Qty8 = model.Qty8;
            entity.Qty9 = model.Qty9;
            entity.Qty10 = model.Qty10;
            entity.Qty11 = model.Qty11;
            entity.Qty12 = model.Qty12;
            entity.Qty13 = model.Qty13;
            entity.QtyTotal = model.QtyTotal;
            entity.Cost0 = model.Cost0;
            entity.Cost1 = model.Cost1;
            entity.Cost2 = model.Cost2;
            entity.Cost3 = model.Cost3;
            entity.Cost4 = model.Cost4;
            entity.Cost5 = model.Cost5;
            entity.Cost6 = model.Cost6;
            entity.Cost7 = model.Cost7;
            entity.Cost8 = model.Cost8;
            entity.Cost9 = model.Cost9;
            entity.Cost10 = model.Cost10;
            entity.Cost11 = model.Cost11;
            entity.Cost12 = model.Cost12;
            entity.Cost13 = model.Cost13;
            entity.CostTotal = model.CostTotal;
            entity.Price0 = model.Price0;
            entity.Price1 = model.Price1;
            entity.Price2 = model.Price2;
            entity.Price3 = model.Price3;
            entity.Price4 = model.Price4;
            entity.Price5 = model.Price5;
            entity.Price6 = model.Price6;
            entity.Price7 = model.Price7;
            entity.Price8 = model.Price8;
            entity.Price9 = model.Price9;
            entity.Price10 = model.Price10;
            entity.Price11 = model.Price11;
            entity.Price12 = model.Price12;
            entity.Price13 = model.Price13;
            entity.PriceTotal = model.PriceTotal;
            entity.ProdCategoryCode = model.ProdCategoryCode;
            entity.IDate = model.IDate;
            entity.ContactID = model.ContactID;
            entity.CurrentPrice = model.CurrentPrice;
            entity.PriceType = model.PriceType;
            entity.Status = model.Status;
            entity.Forecast = model.Forecast;

            SALES_ESIORDERFORMRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string CustomerID, string ProductNo, string ShipTo)
        {
            var model = SALES_ESIORDERFORMList.FirstOrDefault(t => t.CustomerID == CustomerID && t.ProductNo == ProductNo && t.ShipTo == ShipTo);

            SALES_ESIORDERFORMRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        public IEnumerable<ESIORDERFORM_PAGE_MASTER> GetByCustIDAndShipto(string customer, string contactID, string shipTo, int curPage, int pageRows, string strWhere, string orderby, out int pageCount)
        {
            return SALES_ESIORDERFORMRepository.GetByCustIDAndShipto(customer, contactID, shipTo, curPage, pageRows, strWhere, orderby, out pageCount);
        }

        public IEnumerable<ESIORDERFORM_PAGE_MASTER> GetItems(string customer,string strWhrer, string location, string orderby, int pageIndex, int pageSize, out int pageCount)
        {
            //var user = GetCurrentUser();
            //locationList = GetEOFShipToCount(strWhrer);
            var dt = GetByCustIDAndShipto(customer, string.Empty, location ?? "ALL", pageIndex, pageSize, strWhrer, orderby, out pageCount);
            return dt;

        }
        public double getCurrentPrice(object currentPrice, object listPrice)
        {
            double r = 0;
            if (currentPrice != null && !DBNull.Value.Equals(currentPrice))//|| 
            {
                double.TryParse(currentPrice.ToString(), out r);
            }
            if (r == 0)
            {
                double.TryParse(listPrice.ToString(), out r);
            }
            return r;
        }
        public List<Location> GetEOFShipToCount(string strWhere)
        {
            return SALES_ESIORDERFORMRepository.GetEOFShipToCount(strWhere);
        }

        /// <summary>
        /// 返回所有的记录;
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="contactID"></param>
        /// <param name="shipTo"></param>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public IEnumerable<ESIORDERFORM_PAGE_MASTER> GetByCustIDAndShipto(string customer, string contactID, string shipTo, string strWhere, string orderby)
        {
            int pageCount = 0;
            return GetByCustIDAndShipto(customer, contactID, shipTo, -1, 0, strWhere, orderby, out pageCount);
        }

        public IEnumerable<CustomizedProduct_PAGE_MASTER> GetCustomizedProducts(string strwhere, string custnmbr, string sortModle, int pagesize, int pageIndex, out int totalCount)
        {
            return SALES_ESIORDERFORMRepository.GetCustomizedProducts(strwhere, custnmbr, sortModle, pagesize, pageIndex, out totalCount);
        }

        public IEnumerable<MyFavourite_QTY_MASTER> GetQTY(string customerID, string productNo)
        {
            return SALES_ESIORDERFORMRepository.GetQTY(customerID, productNo);
        }

        public double[] GetQTYBycustomerID(string customerID, string productNo)
        {
            IEnumerable<MyFavourite_QTY_MASTER> list = GetQTY(customerID, productNo);
            double[] qtys = new double[4] { 0.0, 0.0, 0.0, 0.0 };
            if (list.Count() > 0)
            {
                foreach (var item in list)
                {
                    qtys[0] = item.Qty0.Value;
                    qtys[1] = item.Qty1.Value;
                    qtys[2] = item.Qty2.Value;
                    qtys[3] = item.Qty3.Value;
                }
            }
            return qtys;
        }
        #endregion
    }
}

