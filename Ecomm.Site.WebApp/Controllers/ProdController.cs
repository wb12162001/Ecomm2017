﻿using Ecomm.Core.Service.Product;
using Ecomm.Site.Models.Product.PROD_MASTER;
using Quick.Site.Common.Models;
using Ecomm.Domain.Models.Product;
using Ecomm.Site.Models.Product.PROD_PHOTO;
using Ecomm.Site.Models.Product.PROD_MASTERCOMMON;
using Ecomm.Site.Models.Product.PROD_PROPERTIES;
using Ecomm.Site.Models.Product.PROD_RELATEDITEM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;
using System.Text;
using Ecomm.Site.WebApp.Extension.Filters;

namespace Ecomm.Site.WebApp.Controllers
{
    [MyofficePermission(PermissionCustomMode.Ignore)]
    public class ProdController : Ecomm.Site.WebApp.Common.BaseController
    {
        #region 属性
        [Import]
        public IPROD_MASTERService PROD_MASTERService { get; set; }

        [Import]
        public IPROD_PHOTOService PROD_PHOTOService { get; set; }

        [Import]
        public IPROD_MASTERCOMMONService PROD_MASTERCOMMONService { get; set; }

        [Import]
        public IPROD_PROPERTIESService PROD_PROPERTIESService { get; set; }

        [Import]
        public IPROD_RELATEDITEMService PROD_RELATEDITEMService { get; set; }

        #endregion

        // GET: Product
        public ActionResult Index(int id =1)
        {
            //分页控件语言定义
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            string tab_type = Common.Util.GetCookie("snell_product_tab_type");
            if (string.IsNullOrEmpty(tab_type))
            {
                Common.Util.SetCookie("snell_product_tab_type", "list");
            }

            var categorycode = Request.Params["categorycode"]??"P01";
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

        public ActionResult Detail(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View("Error");
            }

            var model = new ProductDetailModel();
            var entity = PROD_MASTERService.PROD_MASTERList.FirstOrDefault(t => t.ID == id);
            if (null != entity)
            {
                var photos = PROD_PHOTOService.PROD_PHOTOList.Where(t => t.EntityID == entity.ID)
                    .AsEnumerable()
                    .Select(t => new PROD_PHOTOModel
                {
                    ID = t.ID,
                    PhotoTitle = t.PhotoTitle,
                    FilePath = t.FilePath,
                    IsDefault = t.IsDefault,
                    PhotoType = t.PhotoType,
                    EntityID = t.EntityID,
                    SmallPic = Common.Util.GetProductImgUrl(t.SmallPic),
                    BigPic = Common.Util.GetProductImgUrl(t.BigPic),
                    MiddlePic = t.MiddlePic,
                    CreateDate = t.CreateDate,
                    ModiDate = t.ModiDate,
                    Creator = t.Creator,
                    Modifier = t.Modifier,
                    DisplayOrder = t.DisplayOrder,
                    Status = t.Status,
                    Item01 = t.Item01,
                    Item02 = t.Item02,
                    Item03 = t.Item03,
                    Item04 = t.Item04,
                    Item05 = t.Item05,
                }).Take(4);
                var commonItems = PROD_MASTERCOMMONService.PROD_MASTERCOMMONList.Where(t => t.ProductNo == entity.ProductNo)
                    .Select(t => new PROD_MASTERCOMMONModel
                    {
                        ID = t.ID,
                        ProductNo = t.ProductNo,
                        CommTitle = t.CommTitle,
                        CommSummary = t.CommSummary,
                        CommContent = t.CommContent,
                        Creator = t.Creator,
                        CreateDate = t.CreateDate,
                        Modifier = t.Modifier,
                        ModiDate = t.ModiDate,
                        Status = t.Status,
                        Item01 = t.Item01,
                        Item02 = t.Item02,
                        Item03 = t.Item03,
                        Item04 = t.Item04,
                        Item05 = t.Item05,
                    });
                var subItems = PROD_PROPERTIESService.PROD_PROPERTIESList.Where(t => t.ProductNo == entity.ProductNo)
                    .Select(t => new PROD_PROPERTIESModel
                    {
                        ID = t.ID,
                        ProductNo = t.ProductNo,
                        PropertyID = t.PropertyID,
                        PropertyValue = t.PropertyValue,
                        PLevel = t.PLevel,
                        ParentID = t.ParentID,
                        RelationCode = t.RelationCode,
                        RowID = t.RowID,
                        RealProductNo = t.RealProductNo,
                        DisplayOrder = t.DisplayOrder,
                        Remark = t.Remark,
                        Status = t.Status,
                    });
                var recommonItems = PROD_RELATEDITEMService.PROD_RELATEDITEM_MASTERList.Where(t => t.ProductNo == entity.ProductNo)
                    .AsEnumerable()
                    .Select(t => new ProductModel
                    {
                        ProductNo = t.ProductNo,
                        ProductName = t.ProductName,
                        BigPic = Common.Util.GetProductImgUrl(t.BigPic, false),
                        SmallPic = Common.Util.GetProductImgUrl(t.SmallPic),
                        ProdCategoryCode = t.CategoryCode,
                        BaseUOFM = t.BaseUOFM,
                        ListPrice = Common.Util.TransformObjToDou(t.ListPrice),
                        SellPrice = PROD_MASTERService.GetSellPrice(t.ProductNo, Common.Util.TransformObjToDou(t.ListPrice), (double)t.SpecialPrice),

                    }).Take(10);
                model = new ProductDetailModel
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
                    BigPic = Common.Util.GetProductImgUrl(entity.BigPic, false),
                    SmallPic = Common.Util.GetProductImgUrl(entity.SmallPic),
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

                    PhotoList = photos.ToList(),
                    CommonItems = commonItems.ToList(),
                    SubItems = subItems.ToList(),
                    RecommonItems = recommonItems.ToList(),
                    PDF_file = BindPDF(entity.Introduction),
                };
            }
            GetProductPrice(model);
            BindInformation(model);
            BindRecommend(model);
            BindDefalultPic(model);
            ViewBag.ProductDetailModel = model;
            return View();
        }

        private string BindPDF(string info)
        {
            if (!string.IsNullOrEmpty(info))
            {
                if (info.Trim().ToLower().LastIndexOf(".pdf") > -1)
                {
                    return string.Format("<div class='pro_pdf_info'><a title='Pdf Addtional Information' target='_blank' href='{0}'><img src='Themes/ecomm5/images/pdf_infor.gif' /></a></div>", Common.CommonHelper.UploadFilesRootURL + info.Trim());
                }
            }
            return string.Empty;
        }

        private void GetProductPrice(ProductDetailModel info)
        {
            if (info != null)
            {
                info.SellPrice = (double)info.ListPrice;
                if (base.CurrentUser != null && base.CurrentUser.AccountInfo != null)
                {
                    string custnmbr = base.CurrentUser.AccountInfo.Account_no;
                    double price = 0;
                    string ptype = string.Empty;
                    PROD_MASTERService.GetSellingPrice(info.ProductNo, custnmbr, out price, out ptype);
                    info.PriceType = ptype;
                    info.SellPrice = price;

                }
                else
                {
                    if (info.SpecialPrice > 0 && info.SpecialPrice < info.ListPrice)
                    {
                        info.PriceType = "S";
                        info.SellPrice = (double)info.SpecialPrice;
                    }
                }
                string cla = "";
                switch (info.PriceType)
                {
                    case "S":
                        cla = "prod_price_sp";
                        break;
                    case "C":
                        cla = "prod_price_cp";
                        break;
                    case "I":
                        cla = "prod_price_ip";
                        break;
                    case "L":
                        break;
                }
                info.PriceTypeCss = cla;
            }
        }

        private void BindDefalultPic(ProductDetailModel info)
        {
            if (info.PhotoList.Count == 0)
            {
                int i = 0;
                foreach(var item in info.PhotoList)
                {
                    if(i == 0)
                    {
                        info.BigPic = item.BigPic;
                    }
                    if(item.IsDefault == 1)
                    {
                        info.BigPic = item.BigPic;
                        break;
                    }
                    i++;
                }
            }
        }

        private void BindInformation(ProductDetailModel info)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder top = new StringBuilder();
            StringBuilder infor = new StringBuilder();
            if (info.CommonItems.Count > 0)
            {
                sb.AppendLine("  <div id=\"tabs-pdp\" class=\"clearfloat tabs-pdp-padding\">");
                sb.AppendLine("            <ul class=\"sub_pro_tab_top\">");
                int i = 0;
                foreach (var item in info.CommonItems)
                {
                    i++;
                    string top_css = string.Empty;
                    string content_css = string.Empty;
                    if (i == 1) { top_css = "ui-state-active"; content_css = " class=\"tab_content_list\""; }
                    top.AppendFormat("                <li class=\"ui-state-default {0}\"><a href=\"javascript:void(0);\">", top_css);
                    top.AppendLine();
                    top.AppendFormat("                <span class=\"tab_top_center block\">{0}</span>", item.CommTitle);
                    top.AppendLine();
                    top.AppendLine("                </a>");
                    top.AppendLine("                </li>");

                    infor.AppendFormat("                <div{1}>{0}</div>", item.CommContent, content_css);
                    infor.AppendLine();
                }
                sb.Append(top);
                sb.AppendLine("            </ul>");
                sb.AppendLine("            <div class=\"tab_content\">");
                sb.Append(infor);
                sb.AppendLine("            </div>");
                sb.AppendLine("  </div>");
            }
            info.Information = sb.ToString();

        }

        private void BindRecommend(ProductDetailModel info)
        {
            if(info.RecommonItems.Count == 0)
            {
                var items = PROD_MASTERService.PROD_MASTERList.Where(t => t.CategoryCode == info.CategoryCode)
                    .AsEnumerable()
                     .Select(t => new ProductModel
                     {
                         ID = t.ID,
                         ProductNo = t.ProductNo,
                         ProductName = t.Item03 == "1" ? t.Item02 : t.ProductName,
                         ProductType = t.ProductType,
                         StockType = t.StockType,
                         BigPic = Common.Util.GetProductImgUrl(t.BigPic, false),
                         MiddlePic = Common.Util.GetProductImgUrl(t.SmallPic).Replace("Small", "Middl"),
                         SmallPic = Common.Util.GetProductImgUrl(t.SmallPic),
                         ProdCategoryCode = t.CategoryCode,
                         BaseUOFM = t.BaseUOFM,
                         ListPrice = Common.Util.TransformObjToDou(t.ListPrice),
                         SellPrice = PROD_MASTERService.GetSellPrice(t.ProductNo, Common.Util.TransformObjToDou(t.ListPrice), (double)t.SpecialPrice),
                     }).Take(4);

                info.RecommonItems = items.ToList();
            }
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

        public ActionResult TabShow(string tab_type)
        {
            if (!string.IsNullOrEmpty(tab_type))
            {
                Common.Util.SetCookie("snell_product_tab_type", tab_type);
            }
            else
            {
                tab_type = Common.Util.GetCookie("snell_product_tab_type");
            }
            return Json(new { success = 1, type = tab_type }, JsonRequestBehavior.AllowGet);
        }
    }
}