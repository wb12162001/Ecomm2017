using Quick.Site.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;


namespace Ecomm.Site.WebApp.Extension.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class MyofficePermissionAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        private PermissionCustomMode CustomMode;
        public MyofficePermissionAttribute(PermissionCustomMode mode)
        {

        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //权限拦截是否忽略
            if (CustomMode == PermissionCustomMode.Ignore)
            {
                return;
            }

            base.OnAuthorization(filterContext);
        }
    }
}