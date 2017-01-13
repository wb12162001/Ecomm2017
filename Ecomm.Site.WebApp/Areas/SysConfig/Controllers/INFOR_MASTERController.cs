//------------------------------------------------------------------------------
// <copyright file="INFOR_MASTERController.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Site.WebApp.Areas
//		生成时间：2017/1/5 15:15:54
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
using Ecomm.Site.Models.SysConfig.INFOR_MASTER;
using Quick.Framework.Common.ToolsHelper;
using Ecomm.Domain.Models.SysConfig;
using Quick.Framework.Common.SecurityHelper;
using Ecomm.Core.Service.SysConfig;

namespace Ecomm.Site.WebApp.Areas.SysConfig.Controllers
{
	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class INFOR_MASTERController : AdminController
	{
		//
		// GET: /Authen/User/

		#region 属性
		[Import]
		public IINFOR_MASTERService INFOR_MASTERService { get; set; }

        [Import]
        public IINFOR_CATEGORIESService INFOR_CATEGORIESSService { get; set; }
        #endregion

        [AdminLayout]
        public ActionResult Index()
        {
            base.SetDisplayBtn();
            base.SetCreateBtn();
            base.SetEditBtn();
            base.SetDeleteBtn();
            
            var model = new INFOR_MASTERModel();
            InitCategoupForSearchModel(model.SearchModel);
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
			int total = INFOR_MASTERService.INFOR_MASTERList.Count(expr);
			
			var filterResult = INFOR_MASTERService.INFOR_MASTERList.Where(expr).Select(t => new INFOR_MASTERModel
											 {
                                                 ID = t.ID,
                                                 InforSubject = t.InforSubject,
                                                 InforCategoryID = t.InforCategoryID,
                                                 Introduction = t.Introduction,
                                                 Author = t.Author,
                                                 ViewTimes = t.ViewTimes,
                                                 Description = t.Description,
                                                 Creator = t.Creator,
                                                 CreateDate = t.CreateDate,
                                                 Modifier = t.Modifier,
                                                 ModiDate = t.ModiDate,
                                                 DisplayOrder = t.DisplayOrder,
                                                 Status = t.Status,
                                                 Item01 = t.Item01,
                                                 Item02 = t.Item02,
                                                 Item03 = t.Item03,
                                                 Item04 = t.Item04,
                                                 Item05 = t.Item05,
                                                 IsOuterLink = t.IsOuterLink,
                                                 ActiveLink = t.ActiveLink,
                                                 Target = t.Target,
                                                 LinkTitle = t.LinkTitle,
                                                 LinkText = t.LinkText,
                                                 LinkStyle = t.LinkStyle,
                                                 ParentID = t.ParentID,
                                                 InforCategoryName = t.InforCategory!=null ? t.InforCategory.InforCategoryName:""
											 }
										  ).OrderBy(t=>t.DisplayOrder).Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

            int sortId = param.iDisplayStart + 1;

            var result = from c in filterResult
                         select new[]
                             {
                                 sortId++.ToString(), 

                                 c.InforSubject,
                                 c.InforCategoryName,

                                 c.DisplayOrder.ToString(),
                                 CommonHelper.GetEnableStatusString(c.Status),

                                 c.IsOuterLink.ToString(),
                                 c.ActiveLink,
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

		#region 构建查询表达式
		/// <summary>
		/// 构建查询表达式
		/// </summary>
		/// <returns></returns>
		private Expression<Func<INFOR_MASTER, Boolean>> BuildSearchCriteria()
		{
			DynamicLambda<INFOR_MASTER> bulider = new DynamicLambda<INFOR_MASTER>();
			Expression<Func<INFOR_MASTER, Boolean>> expr = null;
            
            if (!string.IsNullOrEmpty(Request["Subject"]))
            {
                var data = Request["Subject"].Trim();
                Expression<Func<INFOR_MASTER, Boolean>> tmp = t => t.InforSubject.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["InforCategoryID"]))
            {
                var data = Request["InforCategoryID"].Trim();
                Expression<Func<INFOR_MASTER, Boolean>> tmp = t => t.InforCategoryID.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (Request["Enabled"] == "0" || Request["Enabled"] == "1")
            {
                var data = Request["Enabled"] == "1" ? 1 : 0;
                Expression<Func<INFOR_MASTER, Boolean>> tmp = t => t.Status == data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            Expression<Func<INFOR_MASTER, Boolean>> tmpSolid = t => 1 == 1;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);
			return expr;
		}

		#endregion

        public ActionResult Create()
        {
            var model = new INFOR_MASTERModel();
            InitCategoup(model);
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Create(INFOR_MASTERModel model)
        {
            if (ModelState.IsValid)
            {
                //this.CreateBaseData<INFOR_MASTERModel>(model);
                model.ID = CombHelper.NewComb().ToString("N");
                model.CreateDate = DateTime.Now;
                model.Creator = base.GetCurrentUser().Userid;
                OperationResult result = INFOR_MASTERService.Insert(model);
                if (result.ResultType == OperationResultType.Success)
                {
                    return Json(result);
                }
                else
                {
                    InitCategoup(model);
                    return PartialView(model);
                }
            }
            else
            {
                InitCategoup(model);
                return PartialView(model);
            }          
        }

        private void InitCategoup(INFOR_MASTERModel model)
        {
            var parentModuleData = INFOR_CATEGORIESSService.INFOR_CATEGORIESList.Where(t => t.ParentID == "")
                .Select(t => new INFOR_MASTERModel
                {
                    ID = t.ID,
                    InforCategoryName = t.InforCategoryName
                });
            foreach (var item in parentModuleData)
            {
                model.Categrouies.Add(new SelectListItem { Text = item.InforCategoryName, Value = item.ID });
                var childs = INFOR_CATEGORIESSService.INFOR_CATEGORIESList.Where(t => t.ParentID == item.ID);
                if (childs.Count() > 0)
                {
                    foreach (var citem in childs)
                    {
                        model.Categrouies.Add(new SelectListItem { Text = "|-- " + citem.InforCategoryName, Value = citem.ID });
                    }
                }
            }
        }

        private void InitCategoupForSearchModel(SearchModel model)
        {
            var parentModuleData = INFOR_CATEGORIESSService.INFOR_CATEGORIESList.Where(t => t.ParentID == "")
                .Select(t => new INFOR_MASTERModel
                {
                    ID = t.ID,
                    InforCategoryName = t.InforCategoryName
                });
            foreach (var item in parentModuleData)
            {
                model.Categrouies.Add(new SelectListItem { Text = item.InforCategoryName, Value = item.ID });
                var childs = INFOR_CATEGORIESSService.INFOR_CATEGORIESList.Where(t => t.ParentID == item.ID);
                if (childs.Count() > 0)
                {
                    foreach (var citem in childs)
                    {
                        model.Categrouies.Add(new SelectListItem { Text = "|-- " + citem.InforCategoryName, Value = citem.ID });
                    }
                }
            }
        }

        public ActionResult Edit(string  ID)
        {
            var model = new INFOR_MASTERModel();
            var entity = INFOR_MASTERService.INFOR_MASTERList.FirstOrDefault(t => t.ID == ID);
            if (null != entity)
            { 
                model = new INFOR_MASTERModel 
                {
                    ID = entity.ID,
                    InforSubject = entity.InforSubject,
                    InforCategoryID = entity.InforCategoryID,
                    Introduction = entity.Introduction,
                    Author = entity.Author,
                    ViewTimes = entity.ViewTimes,
                    Description = entity.Description,
                    Creator = entity.Creator,
                    CreateDate = entity.CreateDate,
                    Modifier = entity.Modifier,
                    ModiDate = entity.ModiDate,
                    DisplayOrder = entity.DisplayOrder,
                    Status = entity.Status,
                    Item01 = entity.Item01,
                    Item02 = entity.Item02,
                    Item03 = entity.Item03,
                    Item04 = entity.Item04,
                    Item05 = entity.Item05,
                    IsOuterLink = entity.IsOuterLink,
                    ActiveLink = entity.ActiveLink,
                    Target = entity.Target,
                    LinkTitle = entity.LinkTitle,
                    LinkText = entity.LinkText,
                    LinkStyle = entity.LinkStyle,
                    ParentID = entity.ParentID,
                    InforCategoryName = entity.InforCategory != null ? entity.InforCategory.InforCategoryName : ""
                };
                InitCategoup(model);
            }
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Edit(INFOR_MASTERModel model)
        {
            if (ModelState.IsValid)
            {
                //this.UpdateBaseData<UpdateINFOR_MASTERModel>(model);
                model.ModiDate = DateTime.Now;
                model.Modifier = base.GetCurrentUser().Userid;
                OperationResult result = INFOR_MASTERService.Update(model);
                if (result.ResultType == OperationResultType.Success)
                {
                    return Json(result);
                }
                else
                {
                    InitCategoup(model);
                    return PartialView(model);
                }
            }
            else
            {
                InitCategoup(model);
                return PartialView(model);
            }   
        }
        [AdminLayout]
        public ActionResult Display(string  ID)
        {
            var model = new INFOR_MASTERModel();
            var entity = INFOR_MASTERService.INFOR_MASTERList.FirstOrDefault(t => t.ID == ID);
            if (null != entity)
            { 
                model = new INFOR_MASTERModel 
                {
                    ID = entity.ID,
                    InforSubject = entity.InforSubject,
                    InforCategoryID = entity.InforCategoryID,
                    Introduction = entity.Introduction,
                    Author = entity.Author,
                    ViewTimes = entity.ViewTimes,
                    Description = entity.Description,
                    Creator = entity.Creator,
                    CreateDate = entity.CreateDate,
                    Modifier = entity.Modifier,
                    ModiDate = entity.ModiDate,
                    DisplayOrder = entity.DisplayOrder,
                    Status = entity.Status,
                    Item01 = entity.Item01,
                    Item02 = entity.Item02,
                    Item03 = entity.Item03,
                    Item04 = entity.Item04,
                    Item05 = entity.Item05,
                    IsOuterLink = entity.IsOuterLink,
                    ActiveLink = entity.ActiveLink,
                    Target = entity.Target,
                    LinkTitle = entity.LinkTitle,
                    LinkText = entity.LinkText,
                    LinkStyle = entity.LinkStyle,
                    ParentID = entity.ParentID,
                    InforCategoryName = entity.InforCategory != null ? entity.InforCategory.InforCategoryName : ""
                };                
            }
            return View(model);
        }

		[AdminOperateLog]
        public ActionResult Delete(string  ID)
        {
            //记录假删除
            /*
			var model = new INFOR_MASTERModel { 
                ID = ID
			};
			this.UpdateBaseData<INFOR_MASTERModel>(model);
            */
			OperationResult result = INFOR_MASTERService.Delete(ID);
            return Json(result);
        }
	}
}
