using Quick.Site.Common.Models;
using Ecomm.Site.WebApp.Common;
using Ecomm.Site.WebApp.Extension.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecomm.Site.Models.Authen.Admin_user;

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
            var model = new HomeModel();
            model.DueDate = DateTime.Now.ToShortDateString();
            return View(model);
        }
	}
}