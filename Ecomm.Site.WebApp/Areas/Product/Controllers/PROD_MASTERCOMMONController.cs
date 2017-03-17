﻿//------------------------------------------------------------------------------
// <copyright file="PROD_MASTERCOMMONController.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Site.WebApp.Areas
//		生成时间：2017/2/6 10:57:52
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
using Ecomm.Site.Models.Product.PROD_MASTERCOMMON;
using Quick.Framework.Common.ToolsHelper;
using Ecomm.Domain.Models.Product;
using Quick.Framework.Common.SecurityHelper;
using Ecomm.Core.Service.Product;

namespace Ecomm.Site.WebApp.Areas.Product.Controllers
{
	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class PROD_MASTERCOMMONController : AdminController
	{
		//
		// GET: /Authen/User/

		#region 属性
		[Import]
		public IPROD_MASTERCOMMONService PROD_MASTERCOMMONService { get; set; }
		#endregion	

		[AdminLayout]
        public ActionResult Index()
        {
            base.SetDisplayBtn();
            base.SetCreateBtn();
            base.SetEditBtn();
            base.SetDeleteBtn();
            
            var model = new PROD_MASTERCOMMONModel();
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
			int total = PROD_MASTERCOMMONService.PROD_MASTERCOMMONList.Count(expr);
			
			var filterResult = PROD_MASTERCOMMONService.PROD_MASTERCOMMONList.Where(expr).Select(t => new PROD_MASTERCOMMONModel
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
											 }
										  ).OrderBy(sortName, sortDirection).Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

            int sortId = param.iDisplayStart + 1;

            var result = from c in filterResult
                         select new[]
                             {
                                 sortId++.ToString(), 
                                 c.ID,
                                 c.ProductNo,
                                 c.CommTitle,
                                 c.CommSummary,
                                 c.CommContent,
                                 c.Creator,
                                 c.CreateDate.ToString(),
                                 c.Modifier,
                                 c.ModiDate.ToString(),
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
		private Expression<Func<PROD_MASTERCOMMON, Boolean>> BuildSearchCriteria()
		{
			DynamicLambda<PROD_MASTERCOMMON> bulider = new DynamicLambda<PROD_MASTERCOMMON>();
			Expression<Func<PROD_MASTERCOMMON, Boolean>> expr = null;
            /*
            if (!string.IsNullOrEmpty(Request["ProductName"]))
            {
                var data = Request["ProductName"].Trim();
                Expression<Func<PROD_MASTERCOMMON, Boolean>> tmp = t => t.ProductName.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["Description"]))
            {
                var data = Request["Description"].Trim();
                Expression<Func<PROD_MASTERCOMMON, Boolean>> tmp = t => t.Description.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (Request["Enabled"] == "0" || Request["Enabled"] == "1")
            {
                var data = Request["Enabled"] == "1" ? 1 : 0;
                Expression<Func<PROD_MASTERCOMMON, Boolean>> tmp = t => t.Status == data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }

            if (!string.IsNullOrEmpty(Request["StartTime"]))
            {
                var data = Convert.ToDateTime(Request["StartTime"].Trim());
                Expression<Func<PROD_MASTERCOMMON, Boolean>> tmp = t => t.LeadTime >= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["EndTime"]))
            {
                var data = Convert.ToDateTime(Request["EndTime"].Trim()).AddDays(1);
                Expression<Func<PROD_MASTERCOMMON, Boolean>> tmp = t => t.LeadTime <= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            */
            Expression<Func<PROD_MASTERCOMMON, Boolean>> tmpSolid = t => 1 == 1;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);
			return expr;
		}

		#endregion

        public ActionResult Create()
        {
            var model = new PROD_MASTERCOMMONModel();
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Create(PROD_MASTERCOMMONModel model)
        {
            if (ModelState.IsValid)
            {
				this.CreateBaseData<PROD_MASTERCOMMONModel>(model);
                OperationResult result = PROD_MASTERCOMMONService.Insert(model);
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
            var model = new UpdatePROD_MASTERCOMMONModel();
            var entity = PROD_MASTERCOMMONService.PROD_MASTERCOMMONList.FirstOrDefault(t => t.ID == ID);
            if (null != entity)
            { 
                model = new UpdatePROD_MASTERCOMMONModel 
                {     
                ID = entity.ID,ProductNo = entity.ProductNo,CommTitle = entity.CommTitle,CommSummary = entity.CommSummary,CommContent = entity.CommContent,Creator = entity.Creator,CreateDate = entity.CreateDate,Modifier = entity.Modifier,ModiDate = entity.ModiDate,Status = entity.Status,Item01 = entity.Item01,Item02 = entity.Item02,Item03 = entity.Item03,Item04 = entity.Item04,Item05 = entity.Item05
                };                
            }
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Edit(UpdatePROD_MASTERCOMMONModel model)
        {
            if (ModelState.IsValid)
            {
				this.UpdateBaseData<UpdatePROD_MASTERCOMMONModel>(model);
                OperationResult result = PROD_MASTERCOMMONService.Update(model);
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
            var model = new PROD_MASTERCOMMONModel();
            var entity = PROD_MASTERCOMMONService.PROD_MASTERCOMMONList.FirstOrDefault(t => t.ID == ID);
            if (null != entity)
            { 
                model = new PROD_MASTERCOMMONModel 
                {      
                ID = entity.ID,ProductNo = entity.ProductNo,CommTitle = entity.CommTitle,CommSummary = entity.CommSummary,CommContent = entity.CommContent,Creator = entity.Creator,CreateDate = entity.CreateDate,Modifier = entity.Modifier,ModiDate = entity.ModiDate,Status = entity.Status,Item01 = entity.Item01,Item02 = entity.Item02,Item03 = entity.Item03,Item04 = entity.Item04,Item05 = entity.Item05
                };                
            }
            return View(model);
        }

		[AdminOperateLog]
        public ActionResult Delete(string  ID)
        {
            //记录假删除
            /*
			var model = new PROD_MASTERCOMMONModel { 
                ID = ID
			};
			this.UpdateBaseData<PROD_MASTERCOMMONModel>(model);
            */
			OperationResult result = PROD_MASTERCOMMONService.Delete(ID);
            return Json(result);
        }
	}
}
