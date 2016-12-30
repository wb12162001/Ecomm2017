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
    }
}
