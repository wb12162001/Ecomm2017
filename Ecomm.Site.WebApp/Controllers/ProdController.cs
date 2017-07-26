using Ecomm.Core.Service.Product;
using Ecomm.Core.Service.MyOffice;
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
using Chart.Mvc.ComplexChart;
using Chart.Mvc.Extensions;
using Newtonsoft.Json;
using Ecomm.Site.Models.MyOffice.SALES_ESIORDERFORM;

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

        [Import]
        public ISALES_ESIORDERFORMService SALES_ESIORDERFORMService { get; set; }

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

        public ActionResult Detail(string id,string ptype="id")
        {
            if (string.IsNullOrEmpty(id))
            {
                return View("Error");
            }

            var model = new ProductDetailModel();
            var entity = new PROD_MASTER();
            if (ptype == "id")
            {
                 entity = PROD_MASTERService.PROD_MASTERList.FirstOrDefault(t => t.ID == id);
            }
            else
            {
                 entity = PROD_MASTERService.PROD_MASTERList.FirstOrDefault(t => t.ProductNo == id);
            }
            
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
            var barChart = new BarChart();
            if (CurrentUser != null) Chart("Your most recently purchased quantities", model.ProductNo, barChart);
            ViewBag.Chart = barChart;
            return View();
        }

        private string BindPDF(string info)
        {
            if (!string.IsNullOrEmpty(info))
            {
                if (info.Trim().ToLower().LastIndexOf(".pdf") > -1)
                {
                    return string.Format("<div class='pro_pdf_info'><a title='Pdf Addtional Information' target='_blank' href='{0}'><img src='Themes/ecomm5/images/pdf_infor.gif' /></a></div>", Common.Util.UploadFilesRootURL + info.Trim());
                }
            }
            return string.Empty;
        }

        private void GetProductPrice(ProductDetailModel info)
        {
            if (info != null && info.ID != null)
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

        private void Chart(string ChartTitle, string pno, BarChart barChart)
        {
            var lst = SALES_ESIORDERFORMService.QueryEntities(0, string.Format("a.[CustomerID] ='{0}' and a.[ProductNo] ='{1}'", CurrentUser.AccountInfo.Account_no, pno), string.Empty);

            string qty0 = Common.Util.GetMonthName(DateTime.Now.Month);
            string qty1 = Common.Util.GetMonthName(DateTime.Now.AddMonths(-1).Month);
            string qty2 = Common.Util.GetMonthName(DateTime.Now.AddMonths(-2).Month);
            string qty3 = Common.Util.GetMonthName(DateTime.Now.AddMonths(-3).Month);
            string qty4 = Common.Util.GetMonthName(DateTime.Now.AddMonths(-4).Month);
            string qty5 = Common.Util.GetMonthName(DateTime.Now.AddMonths(-5).Month);
            string[] xMonths = { qty5, qty4, qty3, qty2, qty1, qty0 };

            var Ser = from s in lst
                      group s by s.ProductNo into g
                      select new
                      {
                          ProductNo = g.Key,
                          qty0 = g.Sum(p => p.Qty0),
                          qty1 = g.Sum(p => p.Qty1),
                          qty2 = g.Sum(p => p.Qty2),
                          qty3 = g.Sum(p => p.Qty3),
                          qty4 = g.Sum(p => p.Qty4),
                          qty5 = g.Sum(p => p.Qty5),
                      };//所有的Series

            var sum = from t in Ser select (t.qty0 + t.qty1 + t.qty2 + t.qty3 + t.qty4 + t.qty5);
            if (sum.Sum() > 0)
            {
                //var barChart = new BarChart();
                barChart.ComplexData.Labels.AddRange(xMonths);

                var Series = new List<ComplexDataset>();
                foreach (var serie in Ser)
                {
                    var cd = new ComplexDataset
                    {
                        Data = new List<double> { serie.qty5.Value, serie.qty4.Value, serie.qty3.Value, serie.qty2.Value, serie.qty1.Value, serie.qty0.Value },
                        Label = ChartTitle,
                        FillColor = "rgba(220,220,220,0.2)",
                        StrokeColor = "rgba(220,220,220,1)",
                        PointColor = "rgba(220,220,220,1)",
                        PointStrokeColor = "#fff",
                        PointHighlightFill = "#fff",
                        PointHighlightStroke = "rgba(220,220,220,1)",
                    };
                    Series.Add(cd);
                }
                barChart.ComplexData.Datasets.AddRange(Series);
            }
            else
            {
                //barChart = null;
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


        public ActionResult Hotspecials(string cate, int id = 1)
        {
            //分页控件语言定义
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            string tab_type = Common.Util.GetCookie("snell_product_tab_type");
            if (string.IsNullOrEmpty(tab_type))
            {
                Common.Util.SetCookie("snell_product_tab_type", "list");
            }
            var orderby = Request.Params["sortModle"] ?? " ProductName asc";
            var category = Request.Params["category"] ?? "";
            if (!string.IsNullOrEmpty(category))
            {
                var cates = JsonConvert.DeserializeObject<List<string>>(category);
                category = string.Join(",", cates.ToArray());
            }
            int pageSize = 40;
            int pageCount = 0;

            string strWhere = string.Empty;
            if (!string.IsNullOrEmpty(category))
            {
                string cateWhere = string.Empty;

                string[] cateArr = category.Split(',');
                List<string> cateList = new List<string>();
                foreach (string c in cateArr)
                {
                    cateList.Add("'" + c + "'");
                }
                cateWhere = string.Join(",", cateList.ToArray());

                strWhere = string.Format(" and {1} in ({0})", cateWhere, "a.CategoryCode");
            }
            //if (condition.Count > 0) strWhere = string.Join(" and ", condition.ToArray());

            var dt = PROD_MASTERService.GetHotSpecials(cate, strWhere,string.Empty);// Ben 2012-12-25
            if (dt != null && dt.Count() > 0)
            {
                pageCount = dt.Count();
                var items = dt.AsEnumerable()
                            .Select(t => new EOF_PAGE_MASTER
                            {
                                ProductID = t.ID,
                                ProductNo = t.ProductNo,
                                ProductName = t.ProductName,
                                BigPic = Common.Util.GetProductImgUrl(t.BigPic, false),
                                SmallPic = Common.Util.GetProductImgUrl(t.SmallPic),
                                MiddlePic = Common.Util.GetProductImgUrl(t.SmallPic).Replace("Small", "Middl"),
                                StockType = t.StockType,
                                SellPrice = PROD_MASTERService.GetSellPrice(t.ProductNo, Common.Util.TransformObjToDou(t.ListPrice), (double)t.SpecialPrice), //在EasiorderForm不需要对价格进行处理，因为已经登陆了
                                CategoryName = string.IsNullOrEmpty(t.CategoryName) ? t.CategoryCode : t.CategoryName,
                                CategoryCode = t.CategoryCode,
                                BaseUOFM = t.BaseUOFM,
                                ListPrice = t.ListPrice,
                                pCount = pageCount,
                                altPath = Common.Util.SiteRootURL + "detailchart.aspx?proNo=" + t.ProductNo
                            });

                if (!string.IsNullOrEmpty(orderby) && orderby.IndexOf("SellPrice") > -1)
                {
                    if (orderby.IndexOf("asc") > -1)
                    {
                        items.OrderBy(i => i.SellPrice);
                    }
                    if (orderby.IndexOf("desc") > -1)
                    {
                        items.OrderByDescending(i => i.SellPrice);
                    }
                }
                items = items.Skip((id - 1) * pageSize).Take(pageSize);

                ViewBag.PagedListModel = new PagedList<EOF_PAGE_MASTER>(items, id, pageSize, pageCount);

                EOF_PAGE_Other2_MASTER eof_master = new EOF_PAGE_Other2_MASTER();
                ViewBag.EOF_Model = eof_master;
                eof_master.Categories = BindHotspecialsCategory(items).ToList();
            }
            if (Request.IsAjaxRequest())
            {
                System.Threading.Thread.Sleep(1000);
                return PartialView("../Office/_CustomizedProdList");
            }
            
            return View();
        }

        private IEnumerable<EOF_Category> BindHotspecialsCategory(IEnumerable<EOF_PAGE_MASTER> rows)
        {
            var categories = from category in rows
                             group category by new { code = category.CategoryCode, name = category.CategoryName ?? category.MenuAlias } into cs
                             select new EOF_Category
                             {
                                 CategoryName = cs.Key.name,
                                 CategoryCode = cs.Key.code,
                                 Count = cs.Count()
                             };
            return categories;
        }
    }
}