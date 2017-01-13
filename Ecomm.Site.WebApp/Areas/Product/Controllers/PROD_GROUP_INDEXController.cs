//------------------------------------------------------------------------------
// <copyright file="PROD_GROUP_INDEXController.cs">
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
using Ecomm.Site.Models.Product.PROD_GROUP_INDEX;
using Quick.Framework.Common.ToolsHelper;
using Ecomm.Domain.Models.Product;
using Quick.Framework.Common.SecurityHelper;
using Ecomm.Core.Service.Product;

namespace Ecomm.Site.WebApp.Areas.Product.Controllers
{
	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class PROD_GROUP_INDEXController : AdminController
	{
		//
		// GET: /Authen/User/

		#region 属性
		[Import]
		public IPROD_GROUP_INDEXService PROD_GROUP_INDEXService { get; set; }
		#endregion	

		[AdminLayout]
        public ActionResult Index()
        {
            base.SetDisplayBtn();
            base.SetCreateBtn();
            base.SetEditBtn();
            base.SetDeleteBtn();

            var model = new PROD_GROUP_INDEXModel();
            #region 父级列表
            var parentModuleData = PROD_GROUP_INDEXService.PROD_GROUP_INDEXList.Where(t => string.IsNullOrEmpty(t.ParentID) && t.Status == 1)
            .Select(t => new PROD_GROUP_INDEXModel
            {
                ID = t.ID,
                Name = t.Name
            });
            foreach (var item in parentModuleData)
            {
                model.SearchModel.ParentGroupItems.Add(new SelectListItem { Text = item.Name, Value = item.ID });
            }
            #endregion

            return View(model);
        }

        [AdminPermission(PermissionCustomMode.Ignore)]
        public ActionResult List(DataTableParameter param)
        {
            /*
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
            int total = PROD_GROUP_INDEXService.PROD_GROUP_INDEXList.Count(expr);

            var filterResult = PROD_GROUP_INDEXService.PROD_GROUP_INDEXList
                .Where(expr)
                .Select(
                t => new PROD_GROUP_INDEXModel
                {
                    ID = t.ID,
                    Name = t.Name,
                    Description = t.Description,
                    ParentID = t.ParentID,
                    ParentName = t.ParentGroup != null ? t.ParentGroup.Name : "",
                    ColorBg = t.ColorBg,
                    ColorText = t.ColorText,
                    Picture = t.Picture,
                    DisplayOrder = t.DisplayOrder,
                    Creator = t.Creator,
                    Modifier = t.Modifier,
                    CreateDate = t.CreateDate,
                    Modidate = t.Modidate,
                    Status = t.Status == 1 ? true : false,
                    Item01 = t.Item01,
                    Item02 = t.Item02,
                    Item03 = t.Item03,
                    Item04 = t.Item04,
                    Item05 = t.Item05,
                }
                )
                .OrderBy(t => t.ParentID).ThenBy(t => t.DisplayOrder)
                .Skip(param.iDisplayStart)
                .Take(param.iDisplayLength).ToList();
                */
            List<PROD_GROUP_INDEXModel> list = GetProdGroupIndexNode("");
            int total = list.Count;
            int sortId = param.iDisplayStart + 1;
            //这里的次序一定要与index.cshtml,list.cshtml一样;
            var result = from c in list.Skip(param.iDisplayStart).Take(param.iDisplayLength)
                         select new[]
                             {
                                 sortId++.ToString(),
                                 c.Name,
                                 c.Description,
                                 c.ParentName,
                                 c.ColorBg,
                                 c.ColorText,
                                 CommonHelper.GetImageString(c.Picture),
                                 c.DisplayOrder.ToString(),
                                 CommonHelper.GetStatusString(c.Status),
                                 c.ID,
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

        [NonAction]
        public List<PROD_GROUP_INDEXModel> GetProdGroupIndexNode(string id)
        {
            List<PROD_GROUP_INDEXModel> cmbTreeList = new List<PROD_GROUP_INDEXModel>();
            var ext = BuildSearchCriteria(id);
            var parentList = PROD_GROUP_INDEXService.PROD_GROUP_INDEXList.Where(ext).OrderBy(t => t.Name).Select(t => new PROD_GROUP_INDEXModel
            {
                ID = t.ID,
                Name = t.Name,
                Description = t.Description,
                ParentID = t.ParentID,
                ParentName = t.ParentGroup != null ? t.ParentGroup.Name : "",
                ColorBg = t.ColorBg,
                ColorText = t.ColorText,
                Picture = t.Picture,
                DisplayOrder = t.DisplayOrder,
                Creator = t.Creator,
                Modifier = t.Modifier,
                CreateDate = t.CreateDate,
                Modidate = t.Modidate,
                Status = t.Status == 1 ? true : false,
                Item01 = t.Item01,
                Item02 = t.Item02,
                Item03 = t.Item03,
                Item04 = t.Item04,
                Item05 = t.Item05,
            }).ToList();

            if (parentList.Count >= 1)
            {
                foreach (var item in parentList)
                {
                    cmbTreeList.Add(item);
                    List<PROD_GROUP_INDEXModel> tempList = GetProdGroupIndexNode(item.ID);
                    if (tempList.Count >= 1)
                    {
                        cmbTreeList.AddRange(tempList);
                    }

                }
            }
            return cmbTreeList;
        }

        #region 构建查询表达式
        /// <summary>
        /// 构建查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<PROD_GROUP_INDEX, Boolean>> BuildSearchCriteria(string id)
		{
			DynamicLambda<PROD_GROUP_INDEX> bulider = new DynamicLambda<PROD_GROUP_INDEX>();
			Expression<Func<PROD_GROUP_INDEX, Boolean>> expr = null;
            /*
            if (!string.IsNullOrEmpty(Request["Name"]))
            {
                var data = Request["Name"].Trim();
                Expression<Func<PROD_GROUP_INDEX, Boolean>> tmp = t => t.Name.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["ParentID"]))
            {
                var data = Request["ParentID"].Trim();
                Expression<Func<PROD_GROUP_INDEX, Boolean>> tmp = t => t.ParentID.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            //if (!string.IsNullOrEmpty(id))
            //{
            //    Expression<Func<PROD_GROUP_INDEX, Boolean>> tmp = t => t.ParentID == id;
            //    expr = bulider.BuildQueryAnd(expr, tmp);
            //}

            if (Request["Status"] == "0" || Request["Status"] == "1")
            {
                var data = Request["Status"] == "1" ? 1 : 0;
                Expression<Func<PROD_GROUP_INDEX, Boolean>> tmp = t => t.Status == data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }*/
            Expression<Func<PROD_GROUP_INDEX, Boolean>> tmpSolid = t => t.ParentID == id;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);
            return expr;
		}

		#endregion

        public ActionResult Create()
        {
            var model = new PROD_GROUP_INDEXModel();
            InitParentGroup(model);
            return PartialView(model);
        }

        /// <summary>
		/// 父菜单列表
		/// </summary>
		/// <param name="model"></param>
		private void InitParentGroup(PROD_GROUP_INDEXModel model)
        {
            var parentModuleData = PROD_GROUP_INDEXService.PROD_GROUP_INDEXList.Where(t => string.IsNullOrEmpty(t.ParentID) && t.Status == 1)
                .Select(t => new PROD_GROUP_INDEXModel
                {
                    ID = t.ID,
                    Name = t.Name
                });
            foreach (var item in parentModuleData)
            {
                model.ParentGroupItems.Add(new SelectListItem { Text = item.Name, Value = item.ID });
                model.ParentGroupItems.AddRange(GetProdGroup(item.ID,"|--"));
            }
        }
        [NonAction]
        public List<SelectListItem> GetProdGroup(string id,string level)
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

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Create(PROD_GROUP_INDEXModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                HttpPostedFileBase upload = Request.Files["Picture"];
                if (upload != null && upload.ContentLength > 0)
                {
                    string pathForSaving = Server.MapPath("~/Uploads");
                    Quick.Framework.Common.FileHelper.DirFile.CreateDirectory(pathForSaving);
                    try
                    {
                        fileName = Quick.Framework.Common.FileHelper.FileUpload.CreateDateTimeForFileName(upload.FileName);
                        upload.SaveAs(System.IO.Path.Combine(pathForSaving, fileName));
                        model.Picture = fileName;
                        //isUploaded = true;
                        //message = "File uploaded successfully!";
                    }
                    catch (Exception ex)
                    {
                        fileName = string.Empty;
                        //message = string.Format("File upload failed: {0}", ex.Message);
                    }
                }

                model.ID = CombHelper.NewComb().ToString("N");
                model.CreateDate = DateTime.Now;
                model.Creator = base.GetCurrentUser().Userid;
                model.Modidate = DateTime.Now;
                model.Modifier = base.GetCurrentUser().Userid;
                model.Picture = fileName;
                //this.CreateBaseData<PROD_GROUP_INDEXModel>(model);
                OperationResult result = PROD_GROUP_INDEXService.Insert(model);
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

        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AdminPermission(PermissionCustomMode.Ignore)]
        public virtual ActionResult UploadFile()
        {
            HttpPostedFileBase myFile = Request.Files["Picture"];
            bool isUploaded = false;
            string message = "File upload failed";
            string fileName = string.Empty;

            if (myFile != null && myFile.ContentLength != 0)
            {
                string pathForSaving = Server.MapPath("~/Uploads");
                Quick.Framework.Common.FileHelper.DirFile.CreateDirectory(pathForSaving);

                try
                {
                    fileName = Quick.Framework.Common.FileHelper.FileUpload.CreateDateTimeForFileName(myFile.FileName);
                    myFile.SaveAs(System.IO.Path.Combine(pathForSaving, fileName));
                    isUploaded = true;
                    message = "File uploaded successfully!";
                }
                catch (Exception ex)
                {
                    fileName = string.Empty;
                    message = string.Format("File upload failed: {0}", ex.Message);
                }
            }
            return Json(new { isUploaded = isUploaded, message = message, fileName = fileName }, "text/html");
        }

        public ActionResult Edit( string ID )
        {
            var model = new PROD_GROUP_INDEXModel();
            var entity = PROD_GROUP_INDEXService.PROD_GROUP_INDEXList.FirstOrDefault(t => t.ID == ID );
            if (null != entity)
            { 
                model = new PROD_GROUP_INDEXModel 
                { 
                    ID = entity.ID,
                    Name = entity.Name,
                    Description = entity.Description,
                    ParentID = entity.ParentID,
                    ColorBg = entity.ColorBg,
                    ColorText = entity.ColorText,
                    Picture = entity.Picture,
                    DisplayOrder = entity.DisplayOrder,
                    Creator = entity.Creator,
                    Modifier = entity.Modifier,
                    CreateDate = entity.CreateDate,
                    Modidate = entity.Modidate,
                    Status = entity.Status == 1 ? true : false,
                    Item01 = entity.Item01,
                    Item02 = entity.Item02,
                    Item03 = entity.Item03,
                    Item04 = entity.Item04,
                    Item05 = entity.Item05,
                };
                InitParentGroup(model);
            }
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Edit(PROD_GROUP_INDEXModel model)
        {
            if (ModelState.IsValid)
            {
                model.Modidate = DateTime.Now;
                model.Modifier = base.GetCurrentUser().Userid;

                //this.UpdateBaseData<UpdatePROD_GROUP_INDEXModel>(model);
                OperationResult result = PROD_GROUP_INDEXService.Update(model);
                if (result.ResultType == OperationResultType.Success)
                {
                    return Json(result);
                }
                else
                {
                    InitParentGroup(model);
                    return PartialView(model);
                }
            }
            else
            {
                InitParentGroup(model);
                return PartialView(model);
            }   
        }
        [AdminLayout]
        public ActionResult Display( string ID )
        {
            var model = new PROD_GROUP_INDEXModel();
            var entity = PROD_GROUP_INDEXService.PROD_GROUP_INDEXList.FirstOrDefault(t => t.ID == ID );
            if (null != entity)
            {
                model = new PROD_GROUP_INDEXModel
                {
                    ID = entity.ID,
                    Name = entity.Name,
                    Description = entity.Description,
                    ParentID = entity.ParentID,
                    ColorBg = entity.ColorBg,
                    ColorText = entity.ColorText,
                    Picture = entity.Picture,
                    DisplayOrder = entity.DisplayOrder,
                    Creator = entity.Creator,
                    Modifier = entity.Modifier,
                    CreateDate = entity.CreateDate,
                    Modidate = entity.Modidate,
                    Status = entity.Status == 1 ? true : false,
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
        public ActionResult Delete( string ID )
        {
            /*
			var model = new PROD_GROUP_INDEXModel { 
				ID = ID
			};
			this.UpdateBaseData<PROD_GROUP_INDEXModel>(model);
            */
			OperationResult result = PROD_GROUP_INDEXService.Delete(ID);
            return Json(result);
        }
	}
}
