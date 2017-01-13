//------------------------------------------------------------------------------
// <copyright file="SYS_DICTIONARY_DATAController.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Site.WebApp.Areas
//		生成时间：2017/1/5 15:15:55
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
using Ecomm.Site.Models.SysConfig.SYS_DICTIONARY_DATA;
using Quick.Framework.Common.ToolsHelper;
using Ecomm.Domain.Models.SysConfig;
using Quick.Framework.Common.SecurityHelper;
using Ecomm.Core.Service.SysConfig;

namespace Ecomm.Site.WebApp.Areas.SysConfig.Controllers
{
	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class SYS_DICTIONARY_DATAController : AdminController
	{
		//
		// GET: /Authen/User/

		#region 属性
		[Import]
		public ISYS_DICTIONARY_DATAService SYS_DICTIONARY_DATAService { get; set; }
		#endregion	

		[AdminLayout]
        public ActionResult Index()
        {
            base.SetDisplayBtn();
            base.SetCreateBtn();
            base.SetEditBtn();
            base.SetDeleteBtn();
            
            var model = new SYS_DICTIONARY_DATAModel();
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
				default: sortName = sortColumns[2]; break;
			}
            //构建查询表达式
			var expr = BuildSearchCriteria();
			int total = SYS_DICTIONARY_DATAService.SYS_DICTIONARY_DATAList.Count(expr);
			
			var filterResult = SYS_DICTIONARY_DATAService.SYS_DICTIONARY_DATAList.Where(expr).Select(t => new SYS_DICTIONARY_DATAModel
											 {
                                                 ID = t.ID,
                                                 DictionaryValue = t.DictionaryValue,
                                                 DictDataName = t.DictDataName,
                                                 DictDataValue = t.DictDataValue,
                                                 DictDataType = t.DictDataType,
                                                 IsFixed = t.IsFixed,
                                                 IsCancel = t.IsCancel,
                                                 DictParentID = t.DictParentID,
                                                 CreateDate = t.CreateDate,
                                                 ModiDate = t.ModiDate,
                                                 Remark = t.Remark,
                                                 DisplayOrder = t.DisplayOrder,
											 }
										  ).OrderBy(sortName, sortDirection).Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

            int sortId = param.iDisplayStart + 1;

            var result = from c in filterResult
                         select new[]
                             {
                                 sortId++.ToString(), 
                                 c.ID,
                                 c.DictionaryValue.ToString(),
                                 c.DictDataName,
                                 c.DictDataValue,
                                 c.DictDataType,
                                 c.IsFixed.ToString(),
                                 c.IsCancel.ToString(),
                                 c.DictParentID,
                                 c.DisplayOrder.ToString(),
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
		private Expression<Func<SYS_DICTIONARY_DATA, Boolean>> BuildSearchCriteria()
		{
			DynamicLambda<SYS_DICTIONARY_DATA> bulider = new DynamicLambda<SYS_DICTIONARY_DATA>();
			Expression<Func<SYS_DICTIONARY_DATA, Boolean>> expr = null;
            /*
            if (!string.IsNullOrEmpty(Request["ProductName"]))
            {
                var data = Request["ProductName"].Trim();
                Expression<Func<SYS_DICTIONARY_DATA, Boolean>> tmp = t => t.ProductName.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["Description"]))
            {
                var data = Request["Description"].Trim();
                Expression<Func<SYS_DICTIONARY_DATA, Boolean>> tmp = t => t.Description.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (Request["Enabled"] == "0" || Request["Enabled"] == "1")
            {
                var data = Request["Enabled"] == "1" ? 1 : 0;
                Expression<Func<SYS_DICTIONARY_DATA, Boolean>> tmp = t => t.Status == data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }

            if (!string.IsNullOrEmpty(Request["StartTime"]))
            {
                var data = Convert.ToDateTime(Request["StartTime"].Trim());
                Expression<Func<SYS_DICTIONARY_DATA, Boolean>> tmp = t => t.LeadTime >= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["EndTime"]))
            {
                var data = Convert.ToDateTime(Request["EndTime"].Trim()).AddDays(1);
                Expression<Func<SYS_DICTIONARY_DATA, Boolean>> tmp = t => t.LeadTime <= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            */
            Expression<Func<SYS_DICTIONARY_DATA, Boolean>> tmpSolid = t => 1 == 1;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);
			return expr;
		}

		#endregion

        public ActionResult Create()
        {
            var model = new SYS_DICTIONARY_DATAModel();
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Create(SYS_DICTIONARY_DATAModel model)
        {
            if (ModelState.IsValid)
            {
				this.CreateBaseData<SYS_DICTIONARY_DATAModel>(model);
                OperationResult result = SYS_DICTIONARY_DATAService.Insert(model);
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
            var model = new UpdateSYS_DICTIONARY_DATAModel();
            var entity = SYS_DICTIONARY_DATAService.SYS_DICTIONARY_DATAList.FirstOrDefault(t => t.ID == ID);
            if (null != entity)
            { 
                model = new UpdateSYS_DICTIONARY_DATAModel 
                {     
                ID = entity.ID
                };                
            }
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Edit(UpdateSYS_DICTIONARY_DATAModel model)
        {
            if (ModelState.IsValid)
            {
				this.UpdateBaseData<UpdateSYS_DICTIONARY_DATAModel>(model);
                OperationResult result = SYS_DICTIONARY_DATAService.Update(model);
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
            var model = new SYS_DICTIONARY_DATAModel();
            var entity = SYS_DICTIONARY_DATAService.SYS_DICTIONARY_DATAList.FirstOrDefault(t => t.ID == ID);
            if (null != entity)
            { 
                model = new SYS_DICTIONARY_DATAModel 
                {      
                ID = entity.ID
                };                
            }
            return View(model);
        }

		[AdminOperateLog]
        public ActionResult Delete(string  ID)
        {
            //记录假删除
            /*
			var model = new SYS_DICTIONARY_DATAModel { 
                ID = ID
			};
			this.UpdateBaseData<SYS_DICTIONARY_DATAModel>(model);
            */
			OperationResult result = SYS_DICTIONARY_DATAService.Delete(ID);
            return Json(result);
        }
	}
}
