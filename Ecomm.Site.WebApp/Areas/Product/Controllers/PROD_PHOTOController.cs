//------------------------------------------------------------------------------
// <copyright file="PROD_PHOTOController.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Site.WebApp.Areas
//		生成时间：2017/2/6 12:08:37
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
using Ecomm.Site.Models.Product.PROD_PHOTO;
using Quick.Framework.Common.ToolsHelper;
using Ecomm.Domain.Models.Product;
using Quick.Framework.Common.SecurityHelper;
using Ecomm.Core.Service.Product;

namespace Ecomm.Site.WebApp.Areas.Product.Controllers
{
	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class PROD_PHOTOController : AdminController
	{
		//
		// GET: /Authen/User/

		#region 属性
		[Import]
		public IPROD_PHOTOService PROD_PHOTOService { get; set; }
		#endregion	

		[AdminLayout]
        public ActionResult Index()
        {
            base.SetDisplayBtn();
            base.SetCreateBtn();
            base.SetEditBtn();
            base.SetDeleteBtn();
            
            var model = new PROD_PHOTOModel();
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
			int total = PROD_PHOTOService.PROD_PHOTOList.Count(expr);
			
			var filterResult = PROD_PHOTOService.PROD_PHOTOList.Where(expr).Select(t => new PROD_PHOTOModel
											 {
                                                 ID = t.ID,
                                                 PhotoTitle = t.PhotoTitle,
                                                 FilePath = t.FilePath,
                                                 IsDefault = t.IsDefault,
                                                 PhotoType = t.PhotoType,
                                                 EntityID = t.EntityID,
                                                 SmallPic = t.SmallPic,
                                                 BigPic = t.BigPic,
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
											 }
										  ).OrderBy(sortName, sortDirection).Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

            int sortId = param.iDisplayStart + 1;

            var result = from c in filterResult
                         select new[]
                             {
                                 sortId++.ToString(), 
                                 c.ID,
                                 c.PhotoTitle,
                                 c.FilePath,
                                 c.IsDefault.ToString(),
                                 c.PhotoType.ToString(),
                                 c.EntityID,
                                 c.SmallPic,
                                 c.BigPic,
                                 c.MiddlePic,
                                 c.CreateDate.ToString(),
                                 c.ModiDate.ToString(),
                                 c.Creator,
                                 c.Modifier,
                                 c.DisplayOrder.ToString(),
                                 c.Status.ToString(),
                                 c.Item01,
                                 c.Item02,
                                 c.Item03,
                                 c.Item04,
                                 c.Item05,
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
		private Expression<Func<PROD_PHOTO, Boolean>> BuildSearchCriteria()
		{
			DynamicLambda<PROD_PHOTO> bulider = new DynamicLambda<PROD_PHOTO>();
			Expression<Func<PROD_PHOTO, Boolean>> expr = null;
            /*
            if (!string.IsNullOrEmpty(Request["ProductName"]))
            {
                var data = Request["ProductName"].Trim();
                Expression<Func<PROD_PHOTO, Boolean>> tmp = t => t.ProductName.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["Description"]))
            {
                var data = Request["Description"].Trim();
                Expression<Func<PROD_PHOTO, Boolean>> tmp = t => t.Description.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (Request["Enabled"] == "0" || Request["Enabled"] == "1")
            {
                var data = Request["Enabled"] == "1" ? 1 : 0;
                Expression<Func<PROD_PHOTO, Boolean>> tmp = t => t.Status == data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }

            if (!string.IsNullOrEmpty(Request["StartTime"]))
            {
                var data = Convert.ToDateTime(Request["StartTime"].Trim());
                Expression<Func<PROD_PHOTO, Boolean>> tmp = t => t.LeadTime >= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["EndTime"]))
            {
                var data = Convert.ToDateTime(Request["EndTime"].Trim()).AddDays(1);
                Expression<Func<PROD_PHOTO, Boolean>> tmp = t => t.LeadTime <= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            */
            Expression<Func<PROD_PHOTO, Boolean>> tmpSolid = t => 1 == 1;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);
			return expr;
		}

		#endregion

        public ActionResult Create()
        {
            var model = new PROD_PHOTOModel();
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Create(PROD_PHOTOModel model)
        {
            if (ModelState.IsValid)
            {
				this.CreateBaseData<PROD_PHOTOModel>(model);
                OperationResult result = PROD_PHOTOService.Insert(model);
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

        public ActionResult Edit(string  ID)
        {
            var model = new UpdatePROD_PHOTOModel();
            var entity = PROD_PHOTOService.PROD_PHOTOList.FirstOrDefault(t => t.ID == ID);
            if (null != entity)
            { 
                model = new UpdatePROD_PHOTOModel 
                {     
                ID = entity.ID,PhotoTitle = entity.PhotoTitle,FilePath = entity.FilePath,IsDefault = entity.IsDefault,PhotoType = entity.PhotoType,EntityID = entity.EntityID,SmallPic = entity.SmallPic,BigPic = entity.BigPic,MiddlePic = entity.MiddlePic,CreateDate = entity.CreateDate,ModiDate = entity.ModiDate,Creator = entity.Creator,Modifier = entity.Modifier,DisplayOrder = entity.DisplayOrder,Status = entity.Status,Item01 = entity.Item01,Item02 = entity.Item02,Item03 = entity.Item03,Item04 = entity.Item04,Item05 = entity.Item05
                };                
            }
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Edit(UpdatePROD_PHOTOModel model)
        {
            if (ModelState.IsValid)
            {
				this.UpdateBaseData<UpdatePROD_PHOTOModel>(model);
                OperationResult result = PROD_PHOTOService.Update(model);
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
        public ActionResult Display(string  ID)
        {
            var model = new PROD_PHOTOModel();
            var entity = PROD_PHOTOService.PROD_PHOTOList.FirstOrDefault(t => t.ID == ID);
            if (null != entity)
            { 
                model = new PROD_PHOTOModel 
                {      
                ID = entity.ID,PhotoTitle = entity.PhotoTitle,FilePath = entity.FilePath,IsDefault = entity.IsDefault,PhotoType = entity.PhotoType,EntityID = entity.EntityID,SmallPic = entity.SmallPic,BigPic = entity.BigPic,MiddlePic = entity.MiddlePic,CreateDate = entity.CreateDate,ModiDate = entity.ModiDate,Creator = entity.Creator,Modifier = entity.Modifier,DisplayOrder = entity.DisplayOrder,Status = entity.Status,Item01 = entity.Item01,Item02 = entity.Item02,Item03 = entity.Item03,Item04 = entity.Item04,Item05 = entity.Item05
                };                
            }
            return View(model);
        }

		[AdminOperateLog]
        public ActionResult Delete(string  ID)
        {
            //记录假删除
            /*
			var model = new PROD_PHOTOModel { 
                ID = ID
			};
			this.UpdateBaseData<PROD_PHOTOModel>(model);
            */
			OperationResult result = PROD_PHOTOService.Delete(ID);
            return Json(result);
        }
	}
}
