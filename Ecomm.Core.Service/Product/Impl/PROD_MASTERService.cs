//------------------------------------------------------------------------------
// <copyright file="PROD_MASTERService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2016/12/20 17:55:35
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Collections.Generic;

using Quick.Framework.Tool;
using Ecomm.Domain.Models.Product;
using Ecomm.Core.Repository.Product;
using Ecomm.Site.Models;
using Ecomm.Site.Models.Product.PROD_MASTER;
using Quick.Framework.Common.SecurityHelper;

namespace Ecomm.Core.Service.Product.Impl
{
	/// <summary>
    /// 服务层实现 —— PROD_MASTERService
    /// </summary>
    [Export(typeof(IPROD_MASTERService))]
    public class PROD_MASTERService : CoreServiceBase, IPROD_MASTERService
    {
        #region 属性
        [Import]
        public IPROD_MASTERRepository PROD_MASTERRepository { get; set; }

        public IQueryable<PROD_MASTER> PROD_MASTERList
        {
            get {
                string key = "PROD_MASTER_list_service";
                Quick.Framework.Common.CacheHelper.ApplicationCache cache = new Quick.Framework.Common.CacheHelper.ApplicationCache();
                var entity = cache.GetApplicationCache(key);
                if(entity != null){
                    return (IQueryable<PROD_MASTER>)entity;
                }else
                {
                    cache.SetApplicationCache(key, PROD_MASTERRepository.Entities);
                }
                return PROD_MASTERRepository.Entities;
            }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(PROD_MASTERModel model)
        {
            var entity = new PROD_MASTER
            {
                ID = model.ID,
                ProductNo = model.ProductNo,
                ProductName = model.ProductName,
                Description = model.Description,
                ProductType = model.ProductType,
                StndCost = model.StndCost,
                CurrCost = model.CurrCost,
                ListPrice = model.ListPrice,
                SpecialPrice = model.SpecialPrice,
                ClearPrice = model.ClearPrice,
                ProdCategoryID = model.ProdCategoryID,
                CategoryCode = model.CategoryCode,
                SchdlUOM = model.SchdlUOM,
                PriceShed = model.PriceShed,
                BaseUOFM = model.BaseUOFM,
                AvailableQTY = model.AvailableQTY,
                ProdGroupID = model.ProdGroupID,
                ProdSubclassID = model.ProdSubclassID,
                LeadTime = model.LeadTime,
                QtySales = model.QtySales,
                QtyMin = model.QtyMin,
                QtyMax = model.QtyMax,
                CustomerID = model.CustomerID,
                StockType = model.StockType,
                SalesRepID = model.SalesRepID,
                PriceBookItem = model.PriceBookItem,
                PriceLevel = model.PriceLevel,
                BarCode = model.BarCode,
                Ranking = model.Ranking,
                Notes = model.Notes,
                Substitute1 = model.Substitute1,
                Substitute2 = model.Substitute2,
                Qty1 = model.Qty1,
                Qty3 = model.Qty3,
                Qty6 = model.Qty6,
                Qty12 = model.Qty12,
                Sales1 = model.Sales1,
                Sales3 = model.Sales3,
                Sales6 = model.Sales6,
                Sales12 = model.Sales12,
                GPD1 = model.GPD1,
                GPD3 = model.GPD3,
                GPD6 = model.GPD6,
                GPD12 = model.GPD12,
                LastDate = model.LastDate,
                CreateDate = model.CreateDate,
                Creator = model.Creator,
                Modifier = model.Modifier,
                ModiDate = model.ModiDate,
                Status = model.Status,
                P01 = model.P01,
                P02 = model.P02,
                P03 = model.P03,
                P04 = model.P04,
                P05 = model.P05,
                P06 = model.P06,
                P07 = model.P07,
                P08 = model.P08,
                P09 = model.P09,
                P10 = model.P10,
                IsCommend = model.IsCommend,
                IsHot = model.IsHot,
                ExteriorPart = model.ExteriorPart,
                ExteriorPartPrice = model.ExteriorPartPrice,
                ViewTimes = model.ViewTimes,
                SmallPic = model.SmallPic,
                BigPic = model.BigPic,
                LocationStocks1 = model.LocationStocks1,
                LocationStocks2 = model.LocationStocks2,
                LocationStocks3 = model.LocationStocks3,
                LocationStocks4 = model.LocationStocks4,
                LocationStocks5 = model.LocationStocks5,
                LocationStocks6 = model.LocationStocks6,
                LocationStocks7 = model.LocationStocks7,
                LocationStocks8 = model.LocationStocks8,
                LocationStocks9 = model.LocationStocks9,
                LocationStocks10 = model.LocationStocks10,
                LocationStocks11 = model.LocationStocks11,
                LocationStocks12 = model.LocationStocks12,
                LocationStocks13 = model.LocationStocks13,
                LocationStocks14 = model.LocationStocks14,
                LocationStocks15 = model.LocationStocks15,
                LocationAllocate1 = model.LocationAllocate1,
                LocationAllocate2 = model.LocationAllocate2,
                LocationAllocate3 = model.LocationAllocate3,
                LocationAllocate4 = model.LocationAllocate4,
                LocationAllocate5 = model.LocationAllocate5,
                LocationAllocate6 = model.LocationAllocate6,
                LocationAllocate7 = model.LocationAllocate7,
                LocationAllocate8 = model.LocationAllocate8,
                LocationAllocate9 = model.LocationAllocate9,
                LocationAllocate10 = model.LocationAllocate10,
                LocationAllocate11 = model.LocationAllocate11,
                LocationAllocate12 = model.LocationAllocate12,
                LocationAllocate13 = model.LocationAllocate13,
                LocationAllocate14 = model.LocationAllocate14,
                LocationAllocate15 = model.LocationAllocate15,
                Introduction = model.Introduction,
                Brand = model.Brand,
                Item01 = model.Item01,
                Item02 = model.Item02,
                Item03 = model.Item03,
                Item04 = model.Item04,
                Item05 = model.Item05,
            };
            PROD_MASTERRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdatePROD_MASTERModel model)
        {
			var entity = PROD_MASTERList.First(t =>t.ID == model.ID );
            entity.ID = model.ID;
            entity.ProductNo = model.ProductNo;
            entity.ProductName = model.ProductName;
            entity.Description = model.Description;
            entity.ProductType = model.ProductType;
            entity.StndCost = model.StndCost;
            entity.CurrCost = model.CurrCost;
            entity.ListPrice = model.ListPrice;
            entity.SpecialPrice = model.SpecialPrice;
            entity.ClearPrice = model.ClearPrice;
            entity.ProdCategoryID = model.ProdCategoryID;
            entity.CategoryCode = model.CategoryCode;
            entity.SchdlUOM = model.SchdlUOM;
            entity.PriceShed = model.PriceShed;
            entity.BaseUOFM = model.BaseUOFM;
            entity.AvailableQTY = model.AvailableQTY;
            entity.ProdGroupID = model.ProdGroupID;
            entity.ProdSubclassID = model.ProdSubclassID;
            entity.LeadTime = model.LeadTime;
            entity.QtySales = model.QtySales;
            entity.QtyMin = model.QtyMin;
            entity.QtyMax = model.QtyMax;
            entity.CustomerID = model.CustomerID;
            entity.StockType = model.StockType;
            entity.SalesRepID = model.SalesRepID;
            entity.PriceBookItem = model.PriceBookItem;
            entity.PriceLevel = model.PriceLevel;
            entity.BarCode = model.BarCode;
            entity.Ranking = model.Ranking;
            entity.Notes = model.Notes;
            entity.Substitute1 = model.Substitute1;
            entity.Substitute2 = model.Substitute2;
            entity.Qty1 = model.Qty1;
            entity.Qty3 = model.Qty3;
            entity.Qty6 = model.Qty6;
            entity.Qty12 = model.Qty12;
            entity.Sales1 = model.Sales1;
            entity.Sales3 = model.Sales3;
            entity.Sales6 = model.Sales6;
            entity.Sales12 = model.Sales12;
            entity.GPD1 = model.GPD1;
            entity.GPD3 = model.GPD3;
            entity.GPD6 = model.GPD6;
            entity.GPD12 = model.GPD12;
            entity.LastDate = model.LastDate;
            entity.CreateDate = model.CreateDate;
            entity.Creator = model.Creator;
            entity.Modifier = model.Modifier;
            entity.ModiDate = model.ModiDate;
            entity.Status = model.Status;
            entity.P01 = model.P01;
            entity.P02 = model.P02;
            entity.P03 = model.P03;
            entity.P04 = model.P04;
            entity.P05 = model.P05;
            entity.P06 = model.P06;
            entity.P07 = model.P07;
            entity.P08 = model.P08;
            entity.P09 = model.P09;
            entity.P10 = model.P10;
            entity.IsCommend = model.IsCommend;
            entity.IsHot = model.IsHot;
            entity.ExteriorPart = model.ExteriorPart;
            entity.ExteriorPartPrice = model.ExteriorPartPrice;
            entity.ViewTimes = model.ViewTimes;
            entity.SmallPic = model.SmallPic;
            entity.BigPic = model.BigPic;
            entity.LocationStocks1 = model.LocationStocks1;
            entity.LocationStocks2 = model.LocationStocks2;
            entity.LocationStocks3 = model.LocationStocks3;
            entity.LocationStocks4 = model.LocationStocks4;
            entity.LocationStocks5 = model.LocationStocks5;
            entity.LocationStocks6 = model.LocationStocks6;
            entity.LocationStocks7 = model.LocationStocks7;
            entity.LocationStocks8 = model.LocationStocks8;
            entity.LocationStocks9 = model.LocationStocks9;
            entity.LocationStocks10 = model.LocationStocks10;
            entity.LocationStocks11 = model.LocationStocks11;
            entity.LocationStocks12 = model.LocationStocks12;
            entity.LocationStocks13 = model.LocationStocks13;
            entity.LocationStocks14 = model.LocationStocks14;
            entity.LocationStocks15 = model.LocationStocks15;
            entity.LocationAllocate1 = model.LocationAllocate1;
            entity.LocationAllocate2 = model.LocationAllocate2;
            entity.LocationAllocate3 = model.LocationAllocate3;
            entity.LocationAllocate4 = model.LocationAllocate4;
            entity.LocationAllocate5 = model.LocationAllocate5;
            entity.LocationAllocate6 = model.LocationAllocate6;
            entity.LocationAllocate7 = model.LocationAllocate7;
            entity.LocationAllocate8 = model.LocationAllocate8;
            entity.LocationAllocate9 = model.LocationAllocate9;
            entity.LocationAllocate10 = model.LocationAllocate10;
            entity.LocationAllocate11 = model.LocationAllocate11;
            entity.LocationAllocate12 = model.LocationAllocate12;
            entity.LocationAllocate13 = model.LocationAllocate13;
            entity.LocationAllocate14 = model.LocationAllocate14;
            entity.LocationAllocate15 = model.LocationAllocate15;
            entity.Introduction = model.Introduction;
            entity.Brand = model.Brand;
            entity.Item01 = model.Item01;
            entity.Item02 = model.Item02;
            entity.Item03 = model.Item03;
            entity.Item04 = model.Item04;
            entity.Item05 = model.Item05;

            PROD_MASTERRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string Id)
        {
            var model = PROD_MASTERList.FirstOrDefault(t =>t.ID == Id );

            PROD_MASTERRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

