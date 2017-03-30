using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Ecomm.Domain.Data.Initialize;
using Ecomm.Site.WebApp.Extension.ViewEngine;
using Ecomm.Site.WebApp.Extension.ModelBinder;
using System.Web.Http;
using Elmah;

namespace Ecomm.Site.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //自定义View
            ViewEngines.Engines.Clear();
            ExtendedRazorViewEngine engine = new ExtendedRazorViewEngine();
            engine.AddPartialViewLocationFormat("~/Areas/Common/Views/Shared/{0}.cshtml");
            engine.AddPartialViewLocationFormat("~/Areas/Common/Views/Shared/{0}.vbhtml");
            ViewEngines.Engines.Add(engine);

            //Model去除前后空格
            ModelBinders.Binders.DefaultBinder = new TrimModelBinder();

            //设置MEF依赖注入容器
            MefConfig.RegisterMef();

            //初始化DB
            DatabaseInitializer.Initialize(); //在项目第一运行就需要初始数，到后面数据有的就不需要了
        }

        // ELMAH Filtering
        protected void ErrorLog_Filtering(object sender, ExceptionFilterEventArgs e)
        {
            FilterError404(e);
        }

        protected void ErrorMail_Filtering(object sender, ExceptionFilterEventArgs e)
        {
            FilterError404(e);
        }

        // Dismiss 404 errors for ELMAH
        private void FilterError404(ExceptionFilterEventArgs e)
        {
            if (e.Exception.GetBaseException() is HttpException)
            {
                HttpException ex = (HttpException)e.Exception.GetBaseException();
                if (ex.GetHttpCode() == 404)
                    e.Dismiss();
            }
        }

        //处理filter遗漏的错误
        protected void Application_Error(object sender, EventArgs e)
        {
            var httpContext = ((MvcApplication)sender).Context;

            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var currentController = "";
            var currentAction = "";
            if (currentRouteData != null)
            {
                if (currentRouteData.Values["controller"] != null &&
                    !string.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                {
                    currentController = currentRouteData.Values["controller"].ToString();
                }

                if (currentRouteData.Values["action"] != null &&
                    !string.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                {
                    currentAction = currentRouteData.Values["action"].ToString();
                }
            }

            var ex = Server.GetLastError();
            var controller = new Ecomm.Site.WebApp.Controllers.ErrorController();
            var routeData = new RouteData();
            var action = "Index";
            if (ex is HttpException)
            {
                var httpEx = ex as HttpException;
                switch (httpEx.GetHttpCode())
                {
                    case 404:
                        action = "PageNotFound";
                        break;
                    default:
                        action = "Index";
                        break;
                }
            }

            httpContext.ClearError();
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
            httpContext.Response.TrySkipIisCustomErrors = true;
            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = action;

            controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
            ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
        }
    }
}
