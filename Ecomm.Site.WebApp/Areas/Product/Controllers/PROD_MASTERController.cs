//------------------------------------------------------------------------------
// <copyright file="PROD_MASTERController.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Site.WebApp.Areas
//		生成时间：2016/12/21 10:45:26
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

using Quick.Framework.Tool;
using Ecomm.Site.WebApp.Extension.Filters;
using Quick.Site.Common.Models;
using Ecomm.Site.WebApp.Common;
using Ecomm.Site.Models.AdminCommon;
using Ecomm.Site.Models.Product.PROD_MASTER;
using Quick.Framework.Common.ToolsHelper;
using Ecomm.Domain.Models.Product;
using Quick.Framework.Common.SecurityHelper;
using Ecomm.Core.Service.Product;

namespace Ecomm.Site.WebApp.Areas.Product.Controllers
{
	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class PROD_MASTERController : AdminController
	{
		//
		#region 属性
		[Import]
		public IPROD_MASTERService PROD_MASTERService { get; set; }
		#endregion	

		[AdminLayout]
        public ActionResult Index()
        {
            base.SetDisplayBtn();
            base.SetCreateBtn();
            base.SetEditBtn();
            base.SetDeleteBtn();

            var model = new PROD_MASTERModel();
            return View(model);
        }

        [AdminPermission(PermissionCustomMode.Ignore)]
        public ActionResult List(DataTableParameter param)
        {
            string columns = Request["sColumns"];
            string sortCol = Request["iSortCol_0"];
            string sortDir = Request["sSortDir_0"];

            string[] sortColumns = columns.Split(',');

            //Sort Name & sort Direction
            string sortName = null;
            ListSortDirection sortDirection = ListSortDirection.Ascending;

            if (sortDir != "asc")
            {
                sortDirection = ListSortDirection.Descending;
            }

            switch (sortCol)
            {
                case "1": sortName = sortColumns[1]; break;
                case "2": sortName = sortColumns[2]; break;
                case "5": sortName = sortColumns[5]; break;
                case "6": sortName = sortColumns[6]; break;
                case "7": sortName = sortColumns[7]; break;
                default: sortName = sortColumns[1]; break;
            }

            //构建查询表达式
            var expr = BuildSearchCriteria();

            int total = PROD_MASTERService.PROD_MASTERList.Count(expr);

            var filterResult = PROD_MASTERService.PROD_MASTERList.Where(expr).Select(t => new PROD_MASTERModel
            {
                ID = t.ID,
                ProductNo = t.ProductNo,
                ProductName = t.ProductName,

                ProductType = t.ProductType,
                StndCost = t.StndCost,
                BaseUOFM = t.BaseUOFM,
            }
                                          ).OrderBy(sortName, sortDirection).Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

            int sortId = param.iDisplayStart + 1;

            var result = from c in filterResult
                         select new[]
                             {
                                 sortId++.ToString(),
                                 c.ProductNo,
                                 c.ProductName,
                                 c.ProductType == 1 ? "Packing" : "Safety",
                                 c.StndCost.ToString(),
                                 c.BaseUOFM,
                                 c.ID
                         };

            return Json(new
            {
                sEcho = param.sEcho,
                iDisplayStart = param.iDisplayStart,
                iTotalRecords = total,
                iTotalDisplayRecords = total,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }

		#region 构建查询表达式
		/// <summary>
		/// 构建查询表达式
		/// </summary>
		/// <returns></returns>
		private Expression<Func<PROD_MASTER, Boolean>> BuildSearchCriteria()
		{
			DynamicLambda<PROD_MASTER> bulider = new DynamicLambda<PROD_MASTER>();
			Expression<Func<PROD_MASTER, Boolean>> expr = null;
            if (!string.IsNullOrEmpty(Request["ProductName"]))
            {
                var data = Request["ProductName"].Trim();
                Expression<Func<PROD_MASTER, Boolean>> tmp = t => t.ProductName.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["ProductNo"]))
            {
                var data = Request["ProductNo"].Trim();
                Expression<Func<PROD_MASTER, Boolean>> tmp = t => t.ProductNo.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (Request["Enabled"] == "0" || Request["Enabled"] == "1")
            {
                var data = Request["Enabled"] == "1" ? 1 : 0;
                Expression<Func<PROD_MASTER, Boolean>> tmp = t => t.Status == data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }

            if (!string.IsNullOrEmpty(Request["StartTime"]))
            {
                var data = Convert.ToDateTime(Request["StartTime"].Trim());
                Expression<Func<PROD_MASTER, Boolean>> tmp = t => t.LeadTime >= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["EndTime"]))
            {
                var data = Convert.ToDateTime(Request["EndTime"].Trim()).AddDays(1);
                Expression<Func<PROD_MASTER, Boolean>> tmp = t => t.LeadTime <= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }

            Expression<Func<PROD_MASTER, Boolean>> tmpSolid = t => 1 == 1;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);

            return expr;
		}

		#endregion

        public ActionResult Create()
        {
            var model = new PROD_MASTERModel();
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Create(PROD_MASTERModel model)
        {
            if (ModelState.IsValid)
            {
				this.CreateBaseData<PROD_MASTERModel>(model);
                OperationResult result = PROD_MASTERService.Insert(model);
                if (result.ResultType == OperationResultType.Success)
                {
                    return Json(result);
                }
                else
                {
                    return PartialView(model);
                }
            }
            else
            {
                return PartialView(model);
            }          
        }

        public ActionResult Edit(string Id)
        {
            var model = new UpdatePROD_MASTERModel();
            var entity = PROD_MASTERService.PROD_MASTERList.FirstOrDefault(t =>t.ID == Id);
            if (null != entity)
            { 
                model = new UpdatePROD_MASTERModel 
                { 
                    ID = entity.ID,
                    ProductNo = entity.ProductNo,
                    ProductName = entity.ProductName,
                    Description = entity.Description,
                    ProductType = entity.ProductType,
                    StndCost = entity.StndCost,
                    CurrCost = entity.CurrCost,
                    ListPrice = entity.ListPrice,
                    SpecialPrice = entity.SpecialPrice,
                    ClearPrice = entity.ClearPrice,
                    ProdCategoryID = entity.ProdCategoryID,
                    CategoryCode = entity.CategoryCode,
                    SchdlUOM = entity.SchdlUOM,
                    PriceShed = entity.PriceShed,
                    BaseUOFM = entity.BaseUOFM,
                    AvailableQTY = entity.AvailableQTY,
                    ProdGroupID = entity.ProdGroupID,
                    ProdSubclassID = entity.ProdSubclassID,
                    LeadTime = entity.LeadTime,
                    QtySales = entity.QtySales,
                    QtyMin = entity.QtyMin,
                    QtyMax = entity.QtyMax,
                    CustomerID = entity.CustomerID,
                    StockType = entity.StockType,
                    SalesRepID = entity.SalesRepID,
                    PriceBookItem = entity.PriceBookItem,
                    PriceLevel = entity.PriceLevel,
                    BarCode = entity.BarCode,
                    Ranking = entity.Ranking,
                    Notes = entity.Notes,
                    Substitute1 = entity.Substitute1,
                    Substitute2 = entity.Substitute2,
                    Qty1 = entity.Qty1,
                    Qty3 = entity.Qty3,
                    Qty6 = entity.Qty6,
                    Qty12 = entity.Qty12,
                    Sales1 = entity.Sales1,
                    Sales3 = entity.Sales3,
                    Sales6 = entity.Sales6,
                    Sales12 = entity.Sales12,
                    GPD1 = entity.GPD1,
                    GPD3 = entity.GPD3,
                    GPD6 = entity.GPD6,
                    GPD12 = entity.GPD12,
                    LastDate = entity.LastDate,
                    CreateDate = entity.CreateDate,
                    Creator = entity.Creator,
                    Modifier = entity.Modifier,
                    ModiDate = entity.ModiDate,
                    Status = entity.Status,
                    P01 = entity.P01,
                    P02 = entity.P02,
                    P03 = entity.P03,
                    P04 = entity.P04,
                    P05 = entity.P05,
                    P06 = entity.P06,
                    P07 = entity.P07,
                    P08 = entity.P08,
                    P09 = entity.P09,
                    P10 = entity.P10,
                    IsCommend = entity.IsCommend,
                    IsHot = entity.IsHot,
                    ExteriorPart = entity.ExteriorPart,
                    ExteriorPartPrice = entity.ExteriorPartPrice,
                    ViewTimes = entity.ViewTimes,
                    SmallPic = entity.SmallPic,
                    BigPic = entity.BigPic,
                    LocationStocks1 = entity.LocationStocks1,
                    LocationStocks2 = entity.LocationStocks2,
                    LocationStocks3 = entity.LocationStocks3,
                    LocationStocks4 = entity.LocationStocks4,
                    LocationStocks5 = entity.LocationStocks5,
                    LocationStocks6 = entity.LocationStocks6,
                    LocationStocks7 = entity.LocationStocks7,
                    LocationStocks8 = entity.LocationStocks8,
                    LocationStocks9 = entity.LocationStocks9,
                    LocationStocks10 = entity.LocationStocks10,
                    LocationStocks11 = entity.LocationStocks11,
                    LocationStocks12 = entity.LocationStocks12,
                    LocationStocks13 = entity.LocationStocks13,
                    LocationStocks14 = entity.LocationStocks14,
                    LocationStocks15 = entity.LocationStocks15,
                    LocationAllocate1 = entity.LocationAllocate1,
                    LocationAllocate2 = entity.LocationAllocate2,
                    LocationAllocate3 = entity.LocationAllocate3,
                    LocationAllocate4 = entity.LocationAllocate4,
                    LocationAllocate5 = entity.LocationAllocate5,
                    LocationAllocate6 = entity.LocationAllocate6,
                    LocationAllocate7 = entity.LocationAllocate7,
                    LocationAllocate8 = entity.LocationAllocate8,
                    LocationAllocate9 = entity.LocationAllocate9,
                    LocationAllocate10 = entity.LocationAllocate10,
                    LocationAllocate11 = entity.LocationAllocate11,
                    LocationAllocate12 = entity.LocationAllocate12,
                    LocationAllocate13 = entity.LocationAllocate13,
                    LocationAllocate14 = entity.LocationAllocate14,
                    LocationAllocate15 = entity.LocationAllocate15,
                    Introduction = entity.Introduction,
                    Brand = entity.Brand,
                    Item01 = entity.Item01,
                    Item02 = entity.Item02,
                    Item03 = entity.Item03,
                    Item04 = entity.Item04,
                    Item05 = entity.Item05,
                };                
            }
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Edit(UpdatePROD_MASTERModel model)
        {
            if (ModelState.IsValid)
            {
				this.UpdateBaseData<UpdatePROD_MASTERModel>(model);
                OperationResult result = PROD_MASTERService.Update(model);
                if (result.ResultType == OperationResultType.Success)
                {
                    return Json(result);
                }
                else
                {
                    return PartialView(model);
                }
            }
            else
            {
                return PartialView(model);
            }   
        }
        [AdminLayout]
        public ActionResult Display(string Id)
        {
            var model = new PROD_MASTERModel();
            var entity = PROD_MASTERService.PROD_MASTERList.FirstOrDefault(t => t.ID == Id);
            if (null != entity)
            {
                model = new PROD_MASTERModel
                {
                    ID = entity.ID,
                    ProductNo = entity.ProductNo,
                    ProductName = entity.ProductName,
                    Description = entity.Description,
                    ProductType = entity.ProductType,
                    StndCost = entity.StndCost,
                    CurrCost = entity.CurrCost,
                    ListPrice = entity.ListPrice,
                    SpecialPrice = entity.SpecialPrice,
                    ClearPrice = entity.ClearPrice,
                    ProdCategoryID = entity.ProdCategoryID,
                    CategoryCode = entity.CategoryCode,
                    SchdlUOM = entity.SchdlUOM,
                    PriceShed = entity.PriceShed,
                    BaseUOFM = entity.BaseUOFM,
                    AvailableQTY = entity.AvailableQTY,
                    ProdGroupID = entity.ProdGroupID,
                    ProdSubclassID = entity.ProdSubclassID,
                    LeadTime = entity.LeadTime,
                    QtySales = entity.QtySales,
                    QtyMin = entity.QtyMin,
                    QtyMax = entity.QtyMax,
                    CustomerID = entity.CustomerID,
                    StockType = entity.StockType,
                    SalesRepID = entity.SalesRepID,
                    PriceBookItem = entity.PriceBookItem,
                    PriceLevel = entity.PriceLevel,
                    BarCode = entity.BarCode,
                    Ranking = entity.Ranking,
                    Notes = entity.Notes,
                    Substitute1 = entity.Substitute1,
                    Substitute2 = entity.Substitute2,
                    Qty1 = entity.Qty1,
                    Qty3 = entity.Qty3,
                    Qty6 = entity.Qty6,
                    Qty12 = entity.Qty12,
                    Sales1 = entity.Sales1,
                    Sales3 = entity.Sales3,
                    Sales6 = entity.Sales6,
                    Sales12 = entity.Sales12,
                    GPD1 = entity.GPD1,
                    GPD3 = entity.GPD3,
                    GPD6 = entity.GPD6,
                    GPD12 = entity.GPD12,
                    LastDate = entity.LastDate,
                    CreateDate = entity.CreateDate,
                    Creator = entity.Creator,
                    Modifier = entity.Modifier,
                    ModiDate = entity.ModiDate,
                    Status = entity.Status,
                    P01 = entity.P01,
                    P02 = entity.P02,
                    P03 = entity.P03,
                    P04 = entity.P04,
                    P05 = entity.P05,
                    P06 = entity.P06,
                    P07 = entity.P07,
                    P08 = entity.P08,
                    P09 = entity.P09,
                    P10 = entity.P10,
                    IsCommend = entity.IsCommend,
                    IsHot = entity.IsHot,
                    ExteriorPart = entity.ExteriorPart,
                    ExteriorPartPrice = entity.ExteriorPartPrice,
                    ViewTimes = entity.ViewTimes,
                    SmallPic = entity.SmallPic,
                    BigPic = entity.BigPic,
                    LocationStocks1 = entity.LocationStocks1,
                    LocationStocks2 = entity.LocationStocks2,
                    LocationStocks3 = entity.LocationStocks3,
                    LocationStocks4 = entity.LocationStocks4,
                    LocationStocks5 = entity.LocationStocks5,
                    LocationStocks6 = entity.LocationStocks6,
                    LocationStocks7 = entity.LocationStocks7,
                    LocationStocks8 = entity.LocationStocks8,
                    LocationStocks9 = entity.LocationStocks9,
                    LocationStocks10 = entity.LocationStocks10,
                    LocationStocks11 = entity.LocationStocks11,
                    LocationStocks12 = entity.LocationStocks12,
                    LocationStocks13 = entity.LocationStocks13,
                    LocationStocks14 = entity.LocationStocks14,
                    LocationStocks15 = entity.LocationStocks15,
                    LocationAllocate1 = entity.LocationAllocate1,
                    LocationAllocate2 = entity.LocationAllocate2,
                    LocationAllocate3 = entity.LocationAllocate3,
                    LocationAllocate4 = entity.LocationAllocate4,
                    LocationAllocate5 = entity.LocationAllocate5,
                    LocationAllocate6 = entity.LocationAllocate6,
                    LocationAllocate7 = entity.LocationAllocate7,
                    LocationAllocate8 = entity.LocationAllocate8,
                    LocationAllocate9 = entity.LocationAllocate9,
                    LocationAllocate10 = entity.LocationAllocate10,
                    LocationAllocate11 = entity.LocationAllocate11,
                    LocationAllocate12 = entity.LocationAllocate12,
                    LocationAllocate13 = entity.LocationAllocate13,
                    LocationAllocate14 = entity.LocationAllocate14,
                    LocationAllocate15 = entity.LocationAllocate15,
                    Introduction = entity.Introduction,
                    Brand = entity.Brand,
                    Item01 = entity.Item01,
                    Item02 = entity.Item02,
                    Item03 = entity.Item03,
                    Item04 = entity.Item04,
                    Item05 = entity.Item05,
                };
            }
            return View(model);
        }

        [AdminOperateLog]
        public ActionResult Delete(string Id)
        {
			//var model = new PROD_MASTERModel { 
			//};
			//this.UpdateBaseData<PROD_MASTERModel>(model);
			OperationResult result = PROD_MASTERService.Delete(Id);
            return Json(result);
        }

        /// <summary>
        /// 用户json 分页加载使用; 比方在下拉框中分页加载
        /// </summary>
        /// <param name="q"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public JsonResult GetProdJson(string q, string page)
        {
            /*
             var lstRes = new List<Province>();
             for (var i = 0; i < 30; i++)
             {
                 var oProvince = new Province();
                 oProvince.id = i;
                 oProvince.name = lstProvince[i];
                 lstRes.Add(oProvince);
             }
             if (!string.IsNullOrEmpty(q.Trim()))
             {
                 lstRes = lstRes.Where(x => x.name.Contains(q)).ToList();
             }
             */
            var filterResult = PROD_MASTERService.PROD_MASTERList.Select(t => new PROD_MASTERModel
            {
                ID = t.ID,
                ProductNo = t.ProductNo,
                ProductName = t.ProductName
            }
                                          ).OrderBy(t => t.ProductNo).ToList();

            if (!string.IsNullOrEmpty(q))
            {
                filterResult = filterResult.Where(x => x.ProductNo.Contains(q)).ToList();
            }
            var lstCurPageRes = string.IsNullOrEmpty(page) ? filterResult.Take(10) : filterResult.Skip(Convert.ToInt32(page) * 10 - 10).Take(10);
            return Json(new { items = lstCurPageRes, total_count = filterResult.Count }, JsonRequestBehavior.AllowGet);
        }
    }
}
