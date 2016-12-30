using Quick.Framework.Common.ToolsHelper;
using Quick.Site.Common.Models;
using Ecomm.Domain.Models.Authen;
using Ecomm.Site.Models.AdminCommon;
using Ecomm.Site.WebApp.Extension.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Ecomm.Site.WebApp.Common
{
	[AdminPermission(PermissionCustomMode.Enforce)]
    public class AdminController : Controller
    {
		public AdminController()
		{
            //TODO: Test
            //var userRole = new List<UserRole> { new UserRole { Id = 1, UserId = 1, RoleId = 1 } };
            //var user = new User { Id = 1, LoginName = "admin", LoginPwd = "8wdJLK8mokI=", UserRole = userRole };
            //SessionHelper.SetSession("CurrentUser", user);
            
        }

       

        protected void SetCreateBtn()
        {
            var btnButton = new ButtonModel
            {
                Icon = "icon-plus",
                Text = "Create"
            };
            ViewBag.Create = btnButton;
        }

        protected void SetEditBtn()
        {
            var btnButton = new ButtonModel
            {
                Icon = "icon-pencil",
                Text = "Edit"
            };
            ViewBag.Edit = btnButton;
        }

        protected void SetDeleteBtn()
        {
            var btnButton = new ButtonModel
            {
                Icon = "icon-remove",
                Text = "Delete"
            };
            ViewBag.Delete = btnButton;
        }
        protected void SetDisplayBtn()
        {
            var btnButton = new ButtonModel
            {
                Icon = "icon-zoom-in",
                Text = "View"
            };
            ViewBag.Display = btnButton;
        }


        protected Admin_user GetCurrentUser()
		{
			var user = SessionHelper.GetSession("CurrentUser") as Admin_user;
			return user;
		}

		protected void CreateBaseData<T>(T model) where T : EntityCommon
		{
			var user = SessionHelper.GetSession("CurrentUser") as Admin_user;
			if (user != null)
			{
				//model.CreateId = user.Id;
				//model.CreateBy = user.Cretuser;
				//model.CreateTime = DateTime.Now;
				//model.ModifyId = user.Id;
				//model.ModifyBy = user.Modiuser;
				//model.ModifyTime = DateTime.Now;
			}
		}

		protected void UpdateBaseData<T>(T model) where T : EntityCommon
		{
			var user = SessionHelper.GetSession("CurrentUser") as Admin_user;
			if (user != null)
			{
				//model.ModifyId = user.Id;
				//model.ModifyBy = user.Userid;
				//model.ModifyTime = DateTime.Now;
			}
		}
	}
}