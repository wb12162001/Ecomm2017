using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Quick.Framework.Tool;
using Ecomm.Site.WebApp.Common;
using Ecomm.Site.WebApp.Extension.Filters;
using Quick.Site.Common.Models;

namespace Ecomm.Site.WebApp.Areas.SysConfig.Controllers
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
	[AdminPermission(PermissionCustomMode.Ignore)]
	public class AppendixController : AdminController
    {
        //
		// GET: /SysConfig/Config/

		[AdminLayout]
		public ActionResult Icon()
		{
			return View();
		}
	}
}