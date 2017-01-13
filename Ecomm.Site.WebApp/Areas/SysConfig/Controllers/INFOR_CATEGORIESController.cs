//------------------------------------------------------------------------------
// <copyright file="INFOR_CATEGORIESController.cs">
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
using Ecomm.Site.Models.SysConfig.INFOR_CATEGORIES;
using Quick.Framework.Common.ToolsHelper;
using Ecomm.Domain.Models.SysConfig;
using Quick.Framework.Common.SecurityHelper;
using Ecomm.Core.Service.SysConfig;

namespace Ecomm.Site.WebApp.Areas.SysConfig.Controllers
{
	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class INFOR_CATEGORIESController : AdminController
	{
		//
		// GET: /Authen/User/

		#region 属性
		[Import]
		public IINFOR_CATEGORIESService INFOR_CATEGORIESService { get; set; }
		#endregion	

		[AdminLayout]
        public ActionResult Index()
        {
            base.SetDisplayBtn();
            base.SetCreateBtn();
            base.SetEditBtn();
            base.SetDeleteBtn();
            
            var model = new INFOR_CATEGORIESModel();
            return View(model);
        }

		[AdminPermission(PermissionCustomMode.Ignore)]
        public ActionResult List(DataTableParameter param)
        {
			string columns = Request["sColumns"];
			string sortCol = Request["iSortCol_0"];
			string sortDir = Request["sSortDir_0"];

            int sortId = param.iDisplayStart + 1;
            
            List<INFOR_CATEGORIESModel> list = GetInforCategoryNode("");
            int total = list.Count;            
            var result = from c in list.Skip(param.iDisplayStart).Take(param.iDisplayLength)
                         select new[]
                             {
                                 sortId++.ToString(), 
                                 c.InforCategoryName,
                                 c.DisplayOrder.ToString(),
                                 c.ParentName,
                                 c.Clevel.ToString(),
                                 CommonHelper.GetEnableStatusString(c.Status),
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
        public List<INFOR_CATEGORIESModel> GetInforCategoryNode(string id)
        {
            List<INFOR_CATEGORIESModel> cmbTreeList = new List<INFOR_CATEGORIESModel>();
            var ext = BuildSearchCriteria(id);
            var parentList = INFOR_CATEGORIESService.INFOR_CATEGORIESList.Where(ext).OrderBy(t => t.DisplayOrder).Select(t => new INFOR_CATEGORIESModel
            {
                ID = t.ID,
                InforCategoryName = t.InforCategoryName,
                DisplayOrder = t.DisplayOrder,
                ParentName = t.ParentCategory.InforCategoryName,
                Clevel = t.Clevel,
                Status = t.Status,
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
                    List<INFOR_CATEGORIESModel> tempList = GetInforCategoryNode(item.ID);
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
        private Expression<Func<INFOR_CATEGORIES, Boolean>> BuildSearchCriteria(string id)
		{
			DynamicLambda<INFOR_CATEGORIES> bulider = new DynamicLambda<INFOR_CATEGORIES>();
			Expression<Func<INFOR_CATEGORIES, Boolean>> expr = null;
            
            if (!string.IsNullOrEmpty(Request["InforCategoryName"]))
            {
                var data = Request["InforCategoryName"].Trim();
                Expression<Func<INFOR_CATEGORIES, Boolean>> tmp = t => t.InforCategoryName.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (Request["Enabled"] == "0" || Request["Enabled"] == "1")
            {
                var data = Request["Enabled"] == "1" ? 1 : 0;
                Expression<Func<INFOR_CATEGORIES, Boolean>> tmp = t => t.Status == data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            Expression<Func<INFOR_CATEGORIES, Boolean>> tmpSolid = t => t.ParentID == id;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);
			return expr;
		}

        #endregion

        private void InitParentCate(INFOR_CATEGORIESModel model)
        {

            var parentModuleData = INFOR_CATEGORIESService.INFOR_CATEGORIESList.Where(t => t.ParentID == "")
                .Select(t => new INFOR_CATEGORIESModel
                {
                    ID = t.ID,
                    InforCategoryName = t.InforCategoryName
                });
            foreach (var item in parentModuleData)
            {
                model.ParentCategies.Add(new SelectListItem { Text = item.InforCategoryName, Value = item.ID });
                var childs = INFOR_CATEGORIESService.INFOR_CATEGORIESList.Where(t => t.ParentID == item.ID);
                if (childs.Count() > 0)
                {
                    foreach (var citem in childs)
                    {
                        model.ParentCategies.Add(new SelectListItem { Text = "|-- " + citem.InforCategoryName, Value = citem.ID });
                    }
                }
            }

        }

        public ActionResult Create()
        {
            var model = new INFOR_CATEGORIESModel();
            InitParentCate(model);
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Create(INFOR_CATEGORIESModel model)
        {
            if (ModelState.IsValid)
            {
                //this.CreateBaseData<INFOR_CATEGORIESModel>(model);
                model.ID= CombHelper.NewComb().ToString("N");
                OperationResult result = INFOR_CATEGORIESService.Insert(model);
                if (result.ResultType == OperationResultType.Success)
                {
                    return Json(result);
                }
                else
                {
                    InitParentCate(model);
                    return PartialView(model);
                }
            }
            else
            {
                InitParentCate(model);
                return PartialView(model);
            }          
        }

        public ActionResult Edit(string  ID)
        {
            var model = new INFOR_CATEGORIESModel();
            var entity = INFOR_CATEGORIESService.INFOR_CATEGORIESList.FirstOrDefault(t => t.ID == ID);
            if (null != entity)
            { 
                model = new INFOR_CATEGORIESModel
                {
                    ID = entity.ID,
                    InforCategoryName = entity.InforCategoryName,
                    DisplayOrder = entity.DisplayOrder,
                    ParentID = entity.ParentID,
                    ParentName = entity.ParentCategory != null ? entity.ParentCategory.InforCategoryName : "",
                    Clevel = entity.Clevel,
                    Status = entity.Status,
                    Item01 = entity.Item01,
                    Item02 = entity.Item02,
                    Item03 = entity.Item03,
                    Item04 = entity.Item04,
                    Item05 = entity.Item05,
                };
                InitParentCate(model);
            }
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Edit(INFOR_CATEGORIESModel model)
        {
            if (ModelState.IsValid)
            {
				//this.UpdateBaseData<UpdateINFOR_CATEGORIESModel>(model);
                OperationResult result = INFOR_CATEGORIESService.Update(model);
                if (result.ResultType == OperationResultType.Success)
                {
                    return Json(result);
                }
                else
                {
                    InitParentCate(model);
                    return PartialView(model);
                }
            }
            else
            {
                InitParentCate(model);
                return PartialView(model);
            }   
        }
        [AdminLayout]
        public ActionResult Display(string  ID)
        {
            var model = new INFOR_CATEGORIESModel();
            var entity = INFOR_CATEGORIESService.INFOR_CATEGORIESList.FirstOrDefault(t => t.ID == ID);
            if (null != entity)
            { 
                model = new INFOR_CATEGORIESModel
                {
                    ID = entity.ID,
                    InforCategoryName = entity.InforCategoryName,
                    DisplayOrder = entity.DisplayOrder,
                    ParentName = entity.ParentCategory != null ? entity.ParentCategory.InforCategoryName : "",
                    Clevel = entity.Clevel,
                    Status = entity.Status,
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
        public ActionResult Delete(string  ID)
        {
            //记录假删除
            /*
			var model = new INFOR_CATEGORIESModel { 
                ID = ID
			};
			this.UpdateBaseData<INFOR_CATEGORIESModel>(model);
            */
			OperationResult result = INFOR_CATEGORIESService.Delete(ID);
            return Json(result);
        }
	}
}
