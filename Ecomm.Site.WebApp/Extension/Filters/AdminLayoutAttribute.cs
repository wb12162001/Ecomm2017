using Quick.Framework.Common.ToolsHelper;
using Ecomm.Core.Service.Authen;
using Ecomm.Domain.Models.Authen;
using Ecomm.Site.Models.AdminCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ecomm.Site.WebApp.Extension.Filters
{
	/// <summary>
	/// 页面布局
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class AdminLayoutAttribute : ActionFilterAttribute 
    {
		public IAdmin_userService UserService { get; set; }

		public AdminLayoutAttribute()
		{
			//TODO: Test
            //var userRole = new List<UserRole> { new UserRole { Id = 1, UserId = 1, RoleId = 1 } };
            //var user = new User { Id = 1, LoginName = "admin", LoginPwd = "8wdJLK8mokI=", UserRole = userRole };
            //SessionHelper.SetSession("CurrentUser", user);
			var user = SessionHelper.GetSession("CurrentUser") as Admin_user;
			if (user != null)
			{
				var container = System.Web.HttpContext.Current.Application["Container"] as CompositionContainer;
				UserService = container.GetExportedValueOrDefault<IAdmin_userService>();
				
			}
		}

		public override void OnResultExecuting(ResultExecutingContext filterContext)
		{
			var user = SessionHelper.GetSession("CurrentUser") as Admin_user;
            if (user != null)
            {
                //顶部菜单
                ((ViewResult)filterContext.Result).ViewBag.LoginName = user.Userid;

                //左侧菜单
                ((ViewResult)filterContext.Result).ViewBag.SidebarMenuModel = InitSidebarMenu(user);

                //面包屑
                ((ViewResult)filterContext.Result).ViewBag.BreadCrumbModel = InitBreadCrumb(filterContext);

                //按钮
                InitButton(user, filterContext);
            }
        }

        private List<SidebarMenuModel> InitSidebarMenu(Admin_user user)
        {
            var model = new List<SidebarMenuModel>();
            /*
            var entity = user.UserRole.Select(t => t.RoleId);
            List<int> RoleIds = entity.ToList();
            //取出所有选中的节点
            var parentModuleIdList = RoleModulePermissionService.RoleModulePermissions.Where(t => RoleIds.Contains(t.RoleId) && t.PermissionId == null && t.IsDeleted == false).Select(t => t.ModuleId).Distinct();
            var childModuleIdList = RoleModulePermissionService.RoleModulePermissions.Where(t => RoleIds.Contains(t.RoleId) && t.PermissionId != null && t.IsDeleted == false).Select(t => t.ModuleId).Distinct();

            foreach (var pmId in parentModuleIdList)
            {
                //取出父菜单
                var parentModule = ModuleService.Modules.FirstOrDefault(t => t.Id == pmId);
                if (parentModule != null)
                {
                    var sideBarMenu = new SidebarMenuModel
                    {
                        Id = parentModule.Id,
                        ParentId = parentModule.ParentId,
                        Name = parentModule.Name,
                        Code = parentModule.Code,
                        Icon = parentModule.Icon,
                        LinkUrl = parentModule.LinkUrl,
                    };

                    //取出子菜单
                    foreach (var cmId in childModuleIdList)
                    {
                        var childModule = ModuleService.Modules.FirstOrDefault(t => t.Id == cmId);
                        if (childModule != null && childModule.ParentId == sideBarMenu.Id)
                        {
                            var childSideBarMenu = new SidebarMenuModel
                            {
                                Id = childModule.Id,
                                ParentId = childModule.ParentId,
                                Name = childModule.Name,
                                Code = childModule.Code,
                                Icon = childModule.Icon,
                                Area = childModule.Area,
                                Controller = childModule.Controller,
                                Action = childModule.Action
                            };
                            sideBarMenu.ChildMenuList.Add(childSideBarMenu);
                        }
                    }

                    //子菜单排序
                    sideBarMenu.ChildMenuList = sideBarMenu.ChildMenuList.OrderBy(t => t.Code).ToList();
                    model.Add(sideBarMenu);
                }
                //父菜单排序
                model = model.OrderBy(t => t.Code).ToList();
            }
            */
            return model;
        }

        private BreadCrumbNavModel InitBreadCrumb(ResultExecutingContext filterContext)
        {
            var area = filterContext.RouteData.DataTokens.ContainsKey("area") ? filterContext.RouteData.DataTokens["area"].ToString().ToLower() : string.Empty;
            var controller = filterContext.RouteData.Values["controller"].ToString().ToLower();
            var action = filterContext.RouteData.Values["action"].ToString().ToLower();

            string linkUrl = string.Format("{0}/{1}/{2}", area, controller, action);

            var model = new BreadCrumbNavModel();

            var indexModel = new BreadCrumbModel
            {
                Name = "Home",
                Icon = "icon-home",
                IsParent = false,
                IsIndex = true
            };

            if (area == "common" && controller == "home" && action == "index")
            {
                model.CurrentName = "Home";
            }

            model.BreadCrumbList.Add(indexModel);

            //Ben 2016-12-27
            SortedList<string, BreadCrumbModelArray<BreadCrumbModel>> ls = InitBreadCrumbArray();
            if (ls.ContainsKey(area)){
                if (ls[area] != null)
                {
                    var parentModel = new BreadCrumbModel
                    {
                        IsParent = true,
                        Name = ls[area].Name,
                        Icon = ls[area].Icon
                    };
                    model.BreadCrumbList.Add(parentModel);

                    var currentModel = ls[area].getItem(controller);
                    if (currentModel != null) {
                        model.BreadCrumbList.Add(currentModel);
                    }
                }
            }
            /*
            var module = ModuleService.Modules.FirstOrDefault(t => t.LinkUrl.ToLower().Contains(linkUrl) && t.IsDeleted == false && t.Enabled == true);

            if (module != null)
            {
                //有父菜单
                if (module.ParentModule != null)
                {
                    var parentModel = new BreadCrumbModel
                    {
                        IsParent = true,
                        Name = module.ParentModule.Name,
                        Icon = module.ParentModule.Icon
                    };
                    model.BreadCrumbList.Add(parentModel);
                }

                var currentModel = new BreadCrumbModel
                {
                    IsParent = false,
                    Name = module.Name,
                    Icon = ""
                };

                model.CurrentName = currentModel.Name;
                model.BreadCrumbList.Add(currentModel);

                ((ViewResult)filterContext.Result).ViewBag.CurrentTitle = module.Name;
            }
            */
            return model;
        }
        /// <summary>
        /// 这里直接在这里定义出菜单导航
        /// </summary>
        /// <returns></returns>
        private SortedList<string, BreadCrumbModelArray<BreadCrumbModel>> InitBreadCrumbArray()
        {
            Quick.Framework.Common.CacheHelper.ApplicationCache cache = new Quick.Framework.Common.CacheHelper.ApplicationCache();
            object list = cache.GetApplicationCache("site_BreadCrumbNav_list");
            if (list != null)
            {
                return (SortedList<string, BreadCrumbModelArray<BreadCrumbModel>>)list;
            }
            else
            {
                SortedList<string, BreadCrumbModelArray<BreadCrumbModel>> array = new SortedList<string, BreadCrumbModelArray<BreadCrumbModel>>();
                BreadCrumbModelArray<BreadCrumbModel> arr_sysconfig = new BreadCrumbModelArray<BreadCrumbModel>();
                arr_sysconfig.Name = "系统应用";
                arr_sysconfig.Icon = "icon-cloud";
                BreadCrumbModel icon = new BreadCrumbModel();
                icon.Name = "图标附录";
                icon.IsIndex = false;
                arr_sysconfig.setItem("appendix", icon);//都是小写

                array.Add("sysconfig", arr_sysconfig); //都是小写

                cache.SetApplicationCache("site_BreadCrumbNav_list", array);

                return array;
            }
        }

        private void InitButton(Admin_user user, ResultExecutingContext filterContext)
        {
            //控制用户具体操作权限: create, edit, delete....
            var btnButton = new ButtonModel
            {
                Icon = "",
                Text = "Button"
            };

            /*
            var roleIds = user.UserRole.Select(t => t.RoleId);
            var controller = filterContext.RouteData.Values["controller"].ToString().ToLower();
            var action = filterContext.RouteData.Values["action"].ToString().ToLower();
            var module = ModuleService.Modules.FirstOrDefault(t => t.Controller.ToLower() == controller);
            if (module != null)
            {
                var permissionIds = RoleModulePermissionService.RoleModulePermissions.Where(t => roleIds.Contains(t.RoleId) && t.ModuleId == module.Id).Select(t => t.PermissionId).Distinct();
                foreach (var permissionId in permissionIds)
                {
                    var entity = PermissionService.Permissions.FirstOrDefault(t => t.Id == permissionId && t.Enabled == true && t.IsDeleted == false);
                    if (entity != null)
                    {
                        var btnButton = new ButtonModel
                        {
                            Icon = entity.Icon,
                            Text = entity.Name
                        };
                        if (entity.Code.ToLower() == "create")
                        {
                            ((ViewResult)filterContext.Result).ViewBag.Create = btnButton;
                        }
                        else if (entity.Code.ToLower() == "edit")
                        {
                            ((ViewResult)filterContext.Result).ViewBag.Edit = btnButton;
                        }
                        else if (entity.Code.ToLower() == "delete")
                        {
                            ((ViewResult)filterContext.Result).ViewBag.Delete = btnButton;
                        }
                        else if (entity.Code.ToLower() == "setbutton")
                        {
                            ((ViewResult)filterContext.Result).ViewBag.SetButton = btnButton;
                        }
                        else if (entity.Code.ToLower() == "setpermission")
                        {
                            ((ViewResult)filterContext.Result).ViewBag.SetPermission = btnButton;
                        }
                        else if (entity.Code.ToLower() == "changepwd")
                        {
                            ((ViewResult)filterContext.Result).ViewBag.ChangePwd = btnButton;
                        }
                        else if (entity.Code.ToLower() == "deleteall")
                        {
                            ((ViewResult)filterContext.Result).ViewBag.DeleteAll = btnButton;
                        }
                    }
                }
            }
            */
        }

    }
}