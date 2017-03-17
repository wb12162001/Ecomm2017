//------------------------------------------------------------------------------
// <copyright file="PROD_RELATED_PROPERTYController.cs">
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
using Ecomm.Site.Models.Product.PROD_RELATED_PROPERTY;
using Quick.Framework.Common.ToolsHelper;
using Ecomm.Domain.Models.Product;
using Quick.Framework.Common.SecurityHelper;
using Ecomm.Core.Service.Product;

namespace Ecomm.Site.WebApp.Areas.Product.Controllers
{
	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class PROD_RELATED_PROPERTYController : AdminController
	{
		//
		// GET: /Authen/User/

		#region 属性
		[Import]
		public IPROD_RELATED_PROPERTYService PROD_RELATED_PROPERTYService { get; set; }
		#endregion	

		[AdminLayout]
        public ActionResult Index()
        {
            base.SetDisplayBtn();
            base.SetCreateBtn();
            base.SetEditBtn();
            base.SetDeleteBtn();
            
            var model = new PROD_RELATED_PROPERTYModel();
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
			int total = PROD_RELATED_PROPERTYService.PROD_RELATED_PROPERTYList.Count(expr);
			
			var filterResult = PROD_RELATED_PROPERTYService.PROD_RELATED_PROPERTYList.Where(expr).Select(t => new PROD_RELATED_PROPERTYModel
											 {
                                                 ProductNo = t.ProductNo,
                                                 PropertyID = t.PropertyID,
                                                 CLevel = t.CLevel,
											 }
										  ).OrderBy(sortName, sortDirection).Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

            int sortId = param.iDisplayStart + 1;

            var result = from c in filterResult
                         select new[]
                             {
                                 sortId++.ToString(), 
                                 c.ProductNo,
                                 c.PropertyID,
                                 c.CLevel.ToString(),
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
		private Expression<Func<PROD_RELATED_PROPERTY, Boolean>> BuildSearchCriteria()
		{
			DynamicLambda<PROD_RELATED_PROPERTY> bulider = new DynamicLambda<PROD_RELATED_PROPERTY>();
			Expression<Func<PROD_RELATED_PROPERTY, Boolean>> expr = null;
            /*
            if (!string.IsNullOrEmpty(Request["ProductName"]))
            {
                var data = Request["ProductName"].Trim();
                Expression<Func<PROD_RELATED_PROPERTY, Boolean>> tmp = t => t.ProductName.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["Description"]))
            {
                var data = Request["Description"].Trim();
                Expression<Func<PROD_RELATED_PROPERTY, Boolean>> tmp = t => t.Description.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (Request["Enabled"] == "0" || Request["Enabled"] == "1")
            {
                var data = Request["Enabled"] == "1" ? 1 : 0;
                Expression<Func<PROD_RELATED_PROPERTY, Boolean>> tmp = t => t.Status == data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }

            if (!string.IsNullOrEmpty(Request["StartTime"]))
            {
                var data = Convert.ToDateTime(Request["StartTime"].Trim());
                Expression<Func<PROD_RELATED_PROPERTY, Boolean>> tmp = t => t.LeadTime >= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["EndTime"]))
            {
                var data = Convert.ToDateTime(Request["EndTime"].Trim()).AddDays(1);
                Expression<Func<PROD_RELATED_PROPERTY, Boolean>> tmp = t => t.LeadTime <= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            */
            Expression<Func<PROD_RELATED_PROPERTY, Boolean>> tmpSolid = t => 1 == 1;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);
			return expr;
		}

		#endregion

        public ActionResult Create()
        {
            var model = new PROD_RELATED_PROPERTYModel();
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Create(PROD_RELATED_PROPERTYModel model)
        {
            if (ModelState.IsValid)
            {
				this.CreateBaseData<PROD_RELATED_PROPERTYModel>(model);
                OperationResult result = PROD_RELATED_PROPERTYService.Insert(model);
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

        public ActionResult Edit(string  ProductNo,string  PropertyID)
        {
            var model = new UpdatePROD_RELATED_PROPERTYModel();
            var entity = PROD_RELATED_PROPERTYService.PROD_RELATED_PROPERTYList.FirstOrDefault(t => t.ProductNo == ProductNo && t.PropertyID == PropertyID);
            if (null != entity)
            { 
                model = new UpdatePROD_RELATED_PROPERTYModel 
                {     
                ProductNo = entity.ProductNo,PropertyID = entity.PropertyID,CLevel = entity.CLevel
                };                
            }
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Edit(UpdatePROD_RELATED_PROPERTYModel model)
        {
            if (ModelState.IsValid)
            {
				this.UpdateBaseData<UpdatePROD_RELATED_PROPERTYModel>(model);
                OperationResult result = PROD_RELATED_PROPERTYService.Update(model);
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
        public ActionResult Display(string  ProductNo,string  PropertyID)
        {
            var model = new PROD_RELATED_PROPERTYModel();
            var entity = PROD_RELATED_PROPERTYService.PROD_RELATED_PROPERTYList.FirstOrDefault(t => t.ProductNo == ProductNo && t.PropertyID == PropertyID);
            if (null != entity)
            { 
                model = new PROD_RELATED_PROPERTYModel 
                {      
                ProductNo = entity.ProductNo,PropertyID = entity.PropertyID,CLevel = entity.CLevel
                };                
            }
            return View(model);
        }

		[AdminOperateLog]
        public ActionResult Delete(string  ProductNo,string  PropertyID)
        {
            //记录假删除
            /*
			var model = new PROD_RELATED_PROPERTYModel { 
                ProductNo = ProductNo,PropertyID = PropertyID
			};
			this.UpdateBaseData<PROD_RELATED_PROPERTYModel>(model);
            */
			OperationResult result = PROD_RELATED_PROPERTYService.Delete(ProductNo,PropertyID);
            return Json(result);
        }
	}
}
