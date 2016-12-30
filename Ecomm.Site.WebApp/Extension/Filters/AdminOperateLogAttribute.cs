using Quick.Framework.Common.ToolsHelper;
using Ecomm.Core.Service.Authen;
using Ecomm.Domain.Models.Authen;
using Ecomm.Site.Models.AdminCommon;
using Ecomm.Site.Models.SysConfig.OperateLog;
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
	/// 记录动作Log
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class AdminOperateLogAttribute : ActionFilterAttribute 
    {


		public AdminOperateLogAttribute()
		{
			var container = HttpContext.Current.Application["Container"] as CompositionContainer;

		}


		public override void OnResultExecuted(ResultExecutedContext filterContext)
		{
		}
    }
}