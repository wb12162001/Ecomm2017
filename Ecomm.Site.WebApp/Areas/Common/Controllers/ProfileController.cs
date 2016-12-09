using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Quick.Framework.Tool;
using Ecomm.Site.WebApp.Extension.Filters;
using Quick.Site.Common.Models;
using Ecomm.Site.WebApp.Common;
using Ecomm.Site.Models.AdminCommon;
using Ecomm.Site.Models.Authen.User;
using Quick.Framework.Common.ToolsHelper;
using Ecomm.Domain.Models.Authen;
using Quick.Framework.Common.SecurityHelper;
using Ecomm.Core.Service.Authen;

namespace Ecomm.Site.WebApp.Areas.Common.Controllers
{	
	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
    [AdminPermission(PermissionCustomMode.Ignore)]
	public class ProfileController : AdminController
    {
        //
        // GET: /Common/Profile/
        #region 属性
        [Import]
		public IUserService UserService { get; set; }
        #endregion

        [AdminLayout]
        public ActionResult Index()
        {
			var entity = this.GetCurrentUser();
			var model = new ProfileModel { 
				Id = entity.Id,
				LoginName = entity.LoginName,
				Email = entity.Email,
				FullName = entity.FullName,
				Phone = entity.Phone,
				LoginCount = entity.LoginCount,
				LastLoginTime = entity.LastLoginTime,
				RegisterTime = entity.RegisterTime
			};
			return View(model);
        }

		[AdminLayout]
		public ActionResult ChangePwd()
		{
			var entity = this.GetCurrentUser();
			var model = new ChangePwdModel { 
				Id = entity.Id,
				LoginName = entity.LoginName,
				Email = entity.Email
			};
			return View(model);
		}

		[HttpPost]
		public ActionResult ChangePwd(ChangePwdModel model)
		{
			if (ModelState.IsValid)
			{
				OperationResult result = UserService.Update(model);
				if (result.ResultType == OperationResultType.Success)
				{
					return Json(result);
				}
				else
				{
					return PartialView(model);
				}
			}
			else
			{
				return PartialView(model);
			}
		}

		public ActionResult CheckPwd(string oldLoginPwd)
		{
			bool result = true;
			var user = SessionHelper.GetSession("CurrentUser") as User;
			if (DESProvider.DecryptString(user.LoginPwd) != oldLoginPwd)
			{
				result = false;
			}
			return Json(result, JsonRequestBehavior.AllowGet);
		}
	}
}