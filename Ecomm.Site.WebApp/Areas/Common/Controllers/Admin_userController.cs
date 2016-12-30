//------------------------------------------------------------------------------
// <copyright file="Admin_userController.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Site.WebApp.Areas
//		生成时间：2016/12/23 14:34:48
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
using Ecomm.Site.Models.Authen.Admin_user;
using Quick.Framework.Common.ToolsHelper;
using Ecomm.Domain.Models.Authen;
using Quick.Framework.Common.SecurityHelper;
using Ecomm.Core.Service.Authen;

namespace Ecomm.Site.WebApp.Areas.Authen.Controllers
{
	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class Admin_userController : AdminController
	{
		//
		// GET: /Authen/User/

		#region 属性
		[Import]
		public IAdmin_userService Admin_userService { get; set; }
		#endregion	

		[AdminLayout]
        public ActionResult Index()
        {
            var model = new Admin_userModel();
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
			

			int total = Admin_userService.Admin_userList.Count();
			//构建查询表达式
			var expr = BuildSearchCriteria();
			var filterResult = Admin_userService.Admin_userList.Where(expr).Select(t => new Admin_userModel
											 {
                                                 Id = t.Id,
                                                 Name = t.Name,
                                                 Userid = t.Userid,
                                                 Passid = t.Passid,
                                                 Usertype = t.Usertype,
                                                 Fname = t.Fname,
                                                 Lname = t.Lname,
                                                 Mname = t.Mname,
                                                 Gender = t.Gender,
                                                 Title = t.Title,
                                                 Email = t.Email,
                                                 Description = t.Description,
                                                 Status = t.Status,
                                                 Sessionid = t.Sessionid,
                                                 Ip = t.Ip,
                                                 Lastdate = t.Lastdate,
                                                 Cretuser = t.Cretuser,
                                                 Cretdate = t.Cretdate,
                                                 Modidate = t.Modidate,
                                                 Modiuser = t.Modiuser,
                                                 Row_id = t.Row_id,
                                                 Phoneid = t.Phoneid,
                                                 Temp01 = t.Temp01,
											 }
										  ).OrderBy(sortName, sortDirection).Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

            int sortId = param.iDisplayStart + 1;

            var result = from c in filterResult
                         select new[]
                             {
                                 sortId++.ToString(), 
                                 c.Id,
                                 c.Name,
                                 c.Userid,
                                 c.Passid,
                                 
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
		private Expression<Func<Admin_user, Boolean>> BuildSearchCriteria()
		{
			DynamicLambda<Admin_user> bulider = new DynamicLambda<Admin_user>();
			Expression<Func<Admin_user, Boolean>> expr = null;
			if (!string.IsNullOrEmpty(Request["Id"]))
			{
				var data = Request["Id"].Trim();
				Expression<Func<Admin_user, Boolean>> tmp = t => t.Id.Contains(data);
				expr = bulider.BuildQueryAnd(expr, tmp);
			}
			if (!string.IsNullOrEmpty(Request["Name"]))
			{
				var data = Request["Name"].Trim();
				Expression<Func<Admin_user, Boolean>> tmp = t => t.Name.Contains(data);
				expr = bulider.BuildQueryAnd(expr, tmp);
			}
			if (!string.IsNullOrEmpty(Request["Userid"]))
			{
				var data = Request["Userid"].Trim();
				Expression<Func<Admin_user, Boolean>> tmp = t => t.Userid.Contains(data);
				expr = bulider.BuildQueryAnd(expr, tmp);
			}
			if (!string.IsNullOrEmpty(Request["Passid"]))
			{
				var data = Request["Passid"].Trim();
				Expression<Func<Admin_user, Boolean>> tmp = t => t.Passid.Contains(data);
				expr = bulider.BuildQueryAnd(expr, tmp);
			}
			if (!string.IsNullOrEmpty(Request["Usertype"]))
			{
				var data = Request["Usertype"].Trim();
				Expression<Func<Admin_user, Boolean>> tmp = t => t.Usertype.Contains(data);
				expr = bulider.BuildQueryAnd(expr, tmp);
			}
			if (!string.IsNullOrEmpty(Request["Fname"]))
			{
				var data = Request["Fname"].Trim();
				Expression<Func<Admin_user, Boolean>> tmp = t => t.Fname.Contains(data);
				expr = bulider.BuildQueryAnd(expr, tmp);
			}
			if (!string.IsNullOrEmpty(Request["Lname"]))
			{
				var data = Request["Lname"].Trim();
				Expression<Func<Admin_user, Boolean>> tmp = t => t.Lname.Contains(data);
				expr = bulider.BuildQueryAnd(expr, tmp);
			}
			if (!string.IsNullOrEmpty(Request["Mname"]))
			{
				var data = Request["Mname"].Trim();
				Expression<Func<Admin_user, Boolean>> tmp = t => t.Mname.Contains(data);
				expr = bulider.BuildQueryAnd(expr, tmp);
			}
			
			return expr;
		}

		#endregion

        public ActionResult Create()
        {
            var model = new Admin_userModel();
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Create(Admin_userModel model)
        {
            if (ModelState.IsValid)
            {
				this.CreateBaseData<Admin_userModel>(model);
                OperationResult result = Admin_userService.Insert(model);
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

        public ActionResult Edit( string Id )
        {
            var model = new UpdateAdmin_userModel();
            var entity = Admin_userService.Admin_userList.FirstOrDefault(t => t.Id == Id );
            if (null != entity)
            { 
                model = new UpdateAdmin_userModel 
                { 
                    Id = entity.Id,
                    Name = entity.Name,
                    Userid = entity.Userid,
                    Passid = entity.Passid,
                    Usertype = entity.Usertype,
                    Fname = entity.Fname,
                    Lname = entity.Lname,
                    Mname = entity.Mname,
                    Gender = entity.Gender,
                    Title = entity.Title,
                    Email = entity.Email,
                    Description = entity.Description,
                    Status = entity.Status,
                    Sessionid = entity.Sessionid,
                    Ip = entity.Ip,
                    Lastdate = entity.Lastdate,
                    Cretuser = entity.Cretuser,
                    Cretdate = entity.Cretdate,
                    Modidate = entity.Modidate,
                    Modiuser = entity.Modiuser,
                    Row_id = entity.Row_id,
                    Phoneid = entity.Phoneid,
                    Temp01 = entity.Temp01,
                };                
            }
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Edit(UpdateAdmin_userModel model)
        {
            if (ModelState.IsValid)
            {
				this.UpdateBaseData<UpdateAdmin_userModel>(model);
                OperationResult result = Admin_userService.Update(model);
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

		[AdminOperateLog]
        public ActionResult Delete( string Id )
        {
			var model = new Admin_userModel { 
				Id = Id
			};
			this.UpdateBaseData<Admin_userModel>(model);
			OperationResult result = Admin_userService.Delete(model.Id);
            return Json(result);
        }
	}
}
