//------------------------------------------------------------------------------
// <copyright file="PROD_GROUP_ITEMController.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Site.WebApp.Areas
//		生成时间：2016/12/28 11:15:59
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
using Ecomm.Site.Models.Product.PROD_GROUP_ITEM;
using Quick.Framework.Common.ToolsHelper;
using Ecomm.Domain.Models.Product;
using Quick.Framework.Common.SecurityHelper;
using Ecomm.Core.Service.Product;
using Ecomm.Site.Models.Product.PROD_GROUP_INDEX;

namespace Ecomm.Site.WebApp.Areas.Product.Controllers
{
	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class PROD_GROUP_ITEMController : AdminController
	{
		//
		// GET: /Authen/User/

		#region 属性
		[Import]
		public IPROD_GROUP_ITEMService PROD_GROUP_ITEMService { get; set; }
        [Import]
        public IPROD_GROUP_INDEXService PROD_GROUP_INDEXService { get; set; }

        [Import]
        public IPROD_MASTERService PROD_MASTERService { get; set; }
        #endregion

        [AdminLayout]
        public ActionResult Index()
        {
            //base.SetDisplayBtn();
            base.SetCreateBtn();
            base.SetEditBtn();
            base.SetDeleteBtn();

            var model = new PROD_GROUP_ITEMModel();
            return View(model);
        }

		[AdminPermission(PermissionCustomMode.Ignore)]
        public ActionResult List(DataTableParameter param)
        {
			string columns = Request["sColumns"];
			string sortCol = Request["iSortCol_0"];
			string sortDir = Request["sSortDir_0"];

			string [] sortColumns = columns.Split(',');

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
				default: sortName = sortColumns[6]; break;
			}
            //构建查询表达式
            var expr = BuildSearchCriteria();
            int total = PROD_GROUP_ITEMService.PROD_GROUP_ITEMList.Count(expr);
			
			var filterResult = PROD_GROUP_ITEMService.PROD_GROUP_ITEMList.Where(expr).Select(t => new PROD_GROUP_ITEMModel
            {
                ProductName=t.Product.ProductName,
                GroupName = t.Group.Name,
                ProductID = t.ProductID,
                GROUP_INDEX = t.GROUP_INDEX,
                Notes = t.Notes,
                Picture = t.Picture,
                Status = t.Status == 1? true:false
            }
										  ).OrderBy(t=>t.GROUP_INDEX).Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

            int sortId = param.iDisplayStart + 1;

            var result = from c in filterResult
                         select new[]
                             {
                                 sortId++.ToString(),
                                 c.ProductName,
                                 c.GroupName,
                                 c.Notes,
                                 CommonHelper.GetImageString(c.Picture),
                                 CommonHelper.GetStatusString(c.Status),
                                 c.ProductID,
                                 c.GROUP_INDEX,
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
		private Expression<Func<PROD_GROUP_ITEM, Boolean>> BuildSearchCriteria()
		{
			DynamicLambda<PROD_GROUP_ITEM> bulider = new DynamicLambda<PROD_GROUP_ITEM>();
			Expression<Func<PROD_GROUP_ITEM, Boolean>> expr = null;
            /*
            if (Request["Enabled"] == "0" || Request["Enabled"] == "1")
            {
                var data = Request["Enabled"] == "1" ? 1 : 0;
                Expression<Func<PROD_GROUP_ITEM, Boolean>> tmp = t => t.Status == data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            */
            Expression<Func<PROD_GROUP_ITEM, Boolean>> tmpSolid = t => 1 == 1;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);
			return expr;
		}

		#endregion

        public ActionResult Create()
        {
            var model = new PROD_GROUP_ITEMModel();
            InitParentGroup(model);
            //InitProducts(model);
            model.Products = GetProducts();
            return PartialView(model);
        }
        private List<SelectListItem> GetParentGroup()
        {
            List<SelectListItem> lt = new List<SelectListItem>();
            var parentModuleData = PROD_GROUP_INDEXService.PROD_GROUP_INDEXList.Where(t => string.IsNullOrEmpty(t.ParentID) && t.Status == 1)
                .Select(t => new PROD_GROUP_INDEXModel
                {
                    ID = t.ID,
                    Name = t.Name
                });
            foreach (var item in parentModuleData)
            {
                lt.Add(new SelectListItem { Text = item.Name, Value = item.ID });
                lt.AddRange(GetProdGroup(item.ID, "|--"));
            }
            return lt;
        }
        /// <summary>
        /// 父列表
        /// </summary>
        /// <param name="model"></param>
        private void InitParentGroup(PROD_GROUP_ITEMModel model)
        {
            var parentModuleData = PROD_GROUP_INDEXService.PROD_GROUP_INDEXList.Where(t => string.IsNullOrEmpty(t.ParentID) && t.Status == 1)
                .Select(t => new PROD_GROUP_INDEXModel
                {
                    ID = t.ID,
                    Name = t.Name
                });
            foreach (var item in parentModuleData)
            {
                model.Groups.Add(new SelectListItem { Text = item.Name, Value = item.ID });
                model.Groups.AddRange(GetProdGroup(item.ID, "|--"));
            }
        }
        [NonAction]
        public List<SelectListItem> GetProdGroup(string id, string level)
        {
            List<SelectListItem> cmbTreeList = new List<SelectListItem>();
            var parentList = PROD_GROUP_INDEXService.PROD_GROUP_INDEXList.Where(t => t.ParentID == id && t.Status == 1).OrderBy(t => t.Name).Select(t => new SelectListItem
            {
                Text = level + t.Name,
                Value = t.ID
            }).ToList();

            if (parentList.Count >= 1)
            {
                foreach (var item in parentList)
                {
                    cmbTreeList.Add(item);
                    List<SelectListItem> tempList = GetProdGroup(item.Value, " |---");
                    if (tempList.Count >= 1)
                    {
                        cmbTreeList.AddRange(tempList);
                    }

                }
            }
            return cmbTreeList;
        }
        private List<SelectListItem> GetProducts()
        {
            List<SelectListItem> lt = new List<SelectListItem>();
            var parentModuleData = PROD_MASTERService.PROD_MASTERList
                .Select(t => new PROD_GROUP_INDEXModel
                {
                    ID = t.ID,
                    Name = t.ProductNo
                });
            foreach (var item in parentModuleData)
            {
                lt.Add(new SelectListItem { Text = item.Name, Value = item.ID });
            }
            return lt;
        }
        //private void InitProducts(PROD_GROUP_ITEMModel model)
        //{
        //    var parentModuleData = PROD_MASTERService.PROD_MASTERList
        //        .Select(t => new PROD_GROUP_INDEXModel
        //        {
        //            ID = t.ID,
        //            Name = t.ProductNo
        //        });
        //    foreach (var item in parentModuleData)
        //    {
        //        model.Products.Add(new SelectListItem { Text = item.Name, Value = item.ID });
        //    }
        //}
        [HttpPost]
		[AdminOperateLog]
        public ActionResult Create(PROD_GROUP_ITEMModel model)
        {
            if (ModelState.IsValid)
            {
				//this.CreateBaseData<PROD_GROUP_ITEMModel>(model);
                OperationResult result = PROD_GROUP_ITEMService.Insert(model);
                if (result.ResultType == OperationResultType.Success)
                {
                    return Json(result);
                }
                else
                {
                    InitParentGroup(model);
                    model.Products = GetProducts();
                    return PartialView(model);
                }
            }
            else
            {
                InitParentGroup(model);
                model.Products = GetProducts();
                return PartialView(model);
            }          
        }

        public ActionResult Edit( string ProductID, string GROUP_INDEX )
        {
            var model = new UpdatePROD_GROUP_ITEMModel();
            var entity = PROD_GROUP_ITEMService.PROD_GROUP_ITEMList.FirstOrDefault(t => t.ProductID == ProductID && t.GROUP_INDEX == GROUP_INDEX );
            if (null != entity)
            { 
                model = new UpdatePROD_GROUP_ITEMModel
                { 
                    ProductID = entity.ProductID,
                    NewProductID = entity.ProductID,
                    GROUP_INDEX = entity.GROUP_INDEX,
                    NewGROUP_INDEX = entity.GROUP_INDEX,
                    Notes = entity.Notes,
                    Picture = entity.Picture,
                    Status = entity.Status==1?true:false,
                };
                model.Groups = GetParentGroup();
                //InitParentGroup(model);
                model.Products = GetProducts();
            }
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Edit(UpdatePROD_GROUP_ITEMModel model)
        {
            if (ModelState.IsValid)
            {
				//this.UpdateBaseData<UpdatePROD_GROUP_ITEMModel>(model);
                OperationResult result = PROD_GROUP_ITEMService.Update(model);
                if (result.ResultType == OperationResultType.Success)
                {
                    return Json(result);
                }
                else
                {
                    model.Groups = GetParentGroup();
                    model.Products = GetProducts();
                    return PartialView(model);
                }
            }
            else
            {
                model.Groups = GetParentGroup();
                model.Products = GetProducts();
                return PartialView(model);
            }   
        }
        [AdminLayout]
        public ActionResult Display( string ProductID, string GROUP_INDEX )
        {
            var model = new PROD_GROUP_ITEMModel();
            var entity = PROD_GROUP_ITEMService.PROD_GROUP_ITEMList.FirstOrDefault(t => t.ProductID == ProductID && t.GROUP_INDEX == GROUP_INDEX );
            if (null != entity)
            { 
                model = new PROD_GROUP_ITEMModel 
                { 
                    ProductID = entity.ProductID,
                    GROUP_INDEX = entity.GROUP_INDEX,
                    Notes = entity.Notes,
                    Picture = entity.Picture,
                    Status = entity.Status == 1 ? true : false,
                };                
            }
            return View(model);
        }

		[AdminOperateLog]
        public ActionResult Delete( string ProductID, string GROUP_INDEX )
        {
			var model = new PROD_GROUP_ITEMModel { 
				ProductID = ProductID,
				GROUP_INDEX = GROUP_INDEX
			};
			this.UpdateBaseData<PROD_GROUP_ITEMModel>(model);
			OperationResult result = PROD_GROUP_ITEMService.Delete(ProductID, GROUP_INDEX );
            return Json(result);
        }

        [HttpPost]
        public ActionResult SingleFileUpload(HttpPostedFileBase file)
        {
            int err_code = 0;
            string message = "File upload failed";
            string fileName = string.Empty;
            string fileUrl = string.Empty;
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    //Server Side file is null add in error
                    message = "Please Upload a file";
                }
                else if (file.ContentLength > 0)
                {
                    int MaxUploadContentLength = 1024 * 1024 * 4; // Maximum uploaded file size must be 4 MB
                    string[] UploadedFileExtensions = new string[] { ".gif", ".jpg", ".png", };

                    if (!UploadedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        //File extension is not gif, jpg and png
                        //ModelState.AddModelError("File", "Please select file of type only: " + string.Join(", ", UploadedFileExtensions));
                        message = "Please select file of type only: " + string.Join(", ", UploadedFileExtensions);
                    }

                    else if (file.ContentLength > MaxUploadContentLength)
                    {
                        //File size is cross maximum File size limit 4 MB
                        //ModelState.AddModelError("File", "Your file is too large, maximum allowed file size is: " + MaxUploadContentLength + " MB");
                        message = "Your file is too large, maximum allowed file size is: " + MaxUploadContentLength + " MB";
                    }
                    else
                    {
                        //Save file in your desired location
                        fileName = System.IO.Path.GetFileName(file.FileName);
                        string filePath = Util.UploadFilesRoot;
                        Quick.Framework.Common.FileHelper.DirFile.CreateDirectory(filePath);
                        var path = System.IO.Path.Combine(filePath, fileName);
                        file.SaveAs(path);
                        ModelState.Clear();
                        message = "File uploaded successfully";
                        err_code = 1;
                        fileUrl = System.IO.Path.Combine(Util.UploadFilesRootURL, fileName);
                    }
                }
            }
            return Json(new { err_code = err_code, message = message, fileName = fileName , fileUrl= fileUrl }, "text/html");
            //return View("Index");
        }
    }
}
