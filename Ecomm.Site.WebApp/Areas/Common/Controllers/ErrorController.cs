using Quick.Site.Common.Models;
using Ecomm.Site.WebApp.Common;
using Ecomm.Site.WebApp.Extension.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecomm.Site.WebApp.Areas.Common.Controllers
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
	[AdminPermission(PermissionCustomMode.Ignore)]
	public class ErrorController : AdminController
    {
        //
		// GET: /Common/Error/

		public ActionResult Page400()
		{
			return View("400");
		}

		public ActionResult Page404()
        {
            return View("404");
        }

		public ActionResult Page500()
		{
			return View("500");
		}

	}
}