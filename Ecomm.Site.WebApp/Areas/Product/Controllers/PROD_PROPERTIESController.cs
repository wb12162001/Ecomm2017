//------------------------------------------------------------------------------
// <copyright file="PROD_PROPERTIESController.cs">
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
using Ecomm.Site.Models.Product.PROD_PROPERTIES;
using Quick.Framework.Common.ToolsHelper;
using Ecomm.Domain.Models.Product;
using Quick.Framework.Common.SecurityHelper;
using Ecomm.Core.Service.Product;

namespace Ecomm.Site.WebApp.Areas.Product.Controllers
{
	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class PROD_PROPERTIESController : AdminController
	{
		//
		// GET: /Authen/User/

		#region 属性
		[Import]
		public IPROD_PROPERTIESService PROD_PROPERTIESService { get; set; }
		#endregion	

		[AdminLayout]
        public ActionResult Index()
        {
            base.SetDisplayBtn();
            base.SetCreateBtn();
            base.SetEditBtn();
            base.SetDeleteBtn();
            
            var model = new PROD_PROPERTIESModel();
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
			int total = PROD_PROPERTIESService.PROD_PROPERTIESList.Count(expr);
			
			var filterResult = PROD_PROPERTIESService.PROD_PROPERTIESList.Where(expr).Select(t => new PROD_PROPERTIESModel
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
											 }
										  ).OrderBy(sortName, sortDirection).Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

            int sortId = param.iDisplayStart + 1;

            var result = from c in filterResult
                         select new[]
                             {
                                 sortId++.ToString(), 
                                 c.ID,
                                 c.ProductNo,
                                 c.PropertyID,
                                 c.PropertyValue,
                                 c.PLevel.ToString(),
                                 c.ParentID,
                                 c.RelationCode,
                                 c.RowID.ToString(),
                                 c.RealProductNo,
                                 c.DisplayOrder.ToString(),
                                 c.Remark,
                                 c.Status.ToString(),
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
		private Expression<Func<PROD_PROPERTIES, Boolean>> BuildSearchCriteria()
		{
			DynamicLambda<PROD_PROPERTIES> bulider = new DynamicLambda<PROD_PROPERTIES>();
			Expression<Func<PROD_PROPERTIES, Boolean>> expr = null;
            /*
            if (!string.IsNullOrEmpty(Request["ProductName"]))
            {
                var data = Request["ProductName"].Trim();
                Expression<Func<PROD_PROPERTIES, Boolean>> tmp = t => t.ProductName.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["Description"]))
            {
                var data = Request["Description"].Trim();
                Expression<Func<PROD_PROPERTIES, Boolean>> tmp = t => t.Description.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (Request["Enabled"] == "0" || Request["Enabled"] == "1")
            {
                var data = Request["Enabled"] == "1" ? 1 : 0;
                Expression<Func<PROD_PROPERTIES, Boolean>> tmp = t => t.Status == data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }

            if (!string.IsNullOrEmpty(Request["StartTime"]))
            {
                var data = Convert.ToDateTime(Request["StartTime"].Trim());
                Expression<Func<PROD_PROPERTIES, Boolean>> tmp = t => t.LeadTime >= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["EndTime"]))
            {
                var data = Convert.ToDateTime(Request["EndTime"].Trim()).AddDays(1);
                Expression<Func<PROD_PROPERTIES, Boolean>> tmp = t => t.LeadTime <= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            */
            Expression<Func<PROD_PROPERTIES, Boolean>> tmpSolid = t => 1 == 1;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);
			return expr;
		}

		#endregion

        public ActionResult Create()
        {
            var model = new PROD_PROPERTIESModel();
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Create(PROD_PROPERTIESModel model)
        {
            if (ModelState.IsValid)
            {
				this.CreateBaseData<PROD_PROPERTIESModel>(model);
                OperationResult result = PROD_PROPERTIESService.Insert(model);
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
            var model = new UpdatePROD_PROPERTIESModel();
            var entity = PROD_PROPERTIESService.PROD_PROPERTIESList.FirstOrDefault(t => t.ID == ID);
            if (null != entity)
            { 
                model = new UpdatePROD_PROPERTIESModel 
                {     
                ID = entity.ID,ProductNo = entity.ProductNo,PropertyID = entity.PropertyID,PropertyValue = entity.PropertyValue,PLevel = entity.PLevel,ParentID = entity.ParentID,RelationCode = entity.RelationCode,RowID = entity.RowID,RealProductNo = entity.RealProductNo,DisplayOrder = entity.DisplayOrder,Remark = entity.Remark,Status = entity.Status
                };                
            }
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Edit(UpdatePROD_PROPERTIESModel model)
        {
            if (ModelState.IsValid)
            {
				this.UpdateBaseData<UpdatePROD_PROPERTIESModel>(model);
                OperationResult result = PROD_PROPERTIESService.Update(model);
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
            var model = new PROD_PROPERTIESModel();
            var entity = PROD_PROPERTIESService.PROD_PROPERTIESList.FirstOrDefault(t => t.ID == ID);
            if (null != entity)
            { 
                model = new PROD_PROPERTIESModel 
                {      
                ID = entity.ID,ProductNo = entity.ProductNo,PropertyID = entity.PropertyID,PropertyValue = entity.PropertyValue,PLevel = entity.PLevel,ParentID = entity.ParentID,RelationCode = entity.RelationCode,RowID = entity.RowID,RealProductNo = entity.RealProductNo,DisplayOrder = entity.DisplayOrder,Remark = entity.Remark,Status = entity.Status
                };                
            }
            return View(model);
        }

		[AdminOperateLog]
        public ActionResult Delete(string  ID)
        {
            //记录假删除
            /*
			var model = new PROD_PROPERTIESModel { 
                ID = ID
			};
			this.UpdateBaseData<PROD_PROPERTIESModel>(model);
            */
			OperationResult result = PROD_PROPERTIESService.Delete(ID);
            return Json(result);
        }
	}
}
