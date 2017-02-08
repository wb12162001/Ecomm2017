using Ecomm.Core.Service.Product;
using Ecomm.Site.Models.Product.PROD_MASTER;
using Quick.Site.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace Ecomm.Site.WebApp.Controllers
{
    public class ProdController : Ecomm.Site.WebApp.Common.BaseController
    {
        #region 属性
        [Import]
        public IPROD_MASTERService PROD_MASTERService { get; set; }
        #endregion

        // GET: Product
        public ActionResult Index(int id =1)
        {
            //分页控件语言定义
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            var categorycode = Request.Params["categorycode"];
            if (!string.IsNullOrEmpty( categorycode )) {
                ViewBag.LeftMenusModel = base.InitNavMenu(categorycode);
            }

            var filterResult = PROD_MASTERService.PROD_MASTERList.Where(t =>t.CategoryCode.Equals(categorycode) || t.ProdGroupID.Equals(categorycode) || t.ProdSubclassID.Equals(categorycode))
                .AsEnumerable()
                .Select(t => new ProductModel
                {
                    ID = t.ID,
                    ProductNo = t.ProductNo,
                    ProductName = t.Item03 == "1" ? t.Item02 : t.ProductName,
                    ProductType = t.ProductType,
                    StockType = t.StockType,
                    BigPic = Common.Util.GetProductImgUrl(t.BigPic,false),
                    MiddlePic = Common.Util.GetProductImgUrl(t.SmallPic).Replace("Small", "Middl"),
                    SmallPic = Common.Util.GetProductImgUrl(t.SmallPic),
                    ProdCategoryCode = t.CategoryCode,
                    BaseUOFM = t.BaseUOFM,
                    ListPrice = Common.Util.TransformObjToDou(t.ListPrice),
                    SellPrice = PROD_MASTERService.GetSellPrice(t.ProductNo, Common.Util.TransformObjToDou(t.ListPrice),(double)t.SpecialPrice),
                }).OrderByDescending(t => t.ID).ToPagedList(id, 24);
            ViewBag.PagedListProductModel = filterResult;
            if (Request.IsAjaxRequest())
                return PartialView("_ProductsList");

            return View();
        }

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

            int total = PROD_MASTERService.PROD_MASTERList.Count();

            var filterResult = PROD_MASTERService.PROD_MASTERList.Where(t => 1 == 1)
                .Select(t => new PROD_MASTERModel
                {
                    ID = t.ID,
                    ProductNo = t.ProductNo,
                    ProductName = t.ProductName,

                    ProductType = t.ProductType,
                    StndCost = t.StndCost,
                    BaseUOFM = t.BaseUOFM,
                }).OrderBy(t=>t.ID)
                .Skip(param.iDisplayStart)
                .Take(param.iDisplayLength).ToList();

            int sortId = param.iDisplayStart + 1;

            var result = from c in filterResult
                         select new[]
                             {
                                 sortId++.ToString(),
                                 c.ProductNo,
                                 c.ProductName,
                                 c.ProductType == 1 ? "Packing" : "Safety",
                                 c.StndCost.ToString(),
                                 c.BaseUOFM
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


    }
}