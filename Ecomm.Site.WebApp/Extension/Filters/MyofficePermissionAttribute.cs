using Quick.Site.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Ecomm.Domain.Models.EpSnell;


namespace Ecomm.Site.WebApp.Extension.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class MyofficePermissionAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        private PermissionCustomMode CustomMode;
        public MyofficePermissionAttribute(PermissionCustomMode mode)
        {
            CustomMode = mode;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //权限拦截是否忽略
            if (CustomMode == PermissionCustomMode.Ignore)
            {
                return;
            }

            var user = filterContext.HttpContext.Session["CurrentSnellUser"] as Rela_contact;
            if (user == null)
            {
                //跳转到登录页面
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }

            //base.OnAuthorization(filterContext);
        }
    }
}