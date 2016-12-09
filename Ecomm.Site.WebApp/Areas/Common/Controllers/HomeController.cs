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
    public class HomeController : AdminController
    {
        //
        // GET: /Common/Home/

		[AdminLayout]
        public ActionResult Index()
        {
            return View();
        }
	}
}