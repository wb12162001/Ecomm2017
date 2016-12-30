using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Quick.Framework.Tool;
using Ecomm.Core.Service.Authen;
using Ecomm.Site.Models.Authen.Admin_user;
using Quick.Framework.Common.SecurityHelper;

namespace Ecomm.Site.WebApp.Areas.Common.Controllers
{
	[Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LoginController : Controller
	{
		//
		// GET: /Common/Login/

		#region 属性
		[Import]
        public IAdmin_userService UserService { get; set; }

        [Import]
        public Ecomm.Core.Service.Product.IPROD_MASTERService ProductService { get; set; }

        #endregion

        public ActionResult Index()
        {
            //TODO:TEST
            //var user = UserService.Users.FirstOrDefault();
            //var entiry = ProductService.PROD_MASTERList.Count();

            var model = new LoginModel();
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(LoginModel model)
        {
            OperationResult result = new OperationResult(OperationResultType.Warning, "用户名或密码错误");
            var user = UserService.Admin_userList.FirstOrDefault(t => t.Userid == model.LoginName);
            if (user != null)
            {
				if (user.Passid == model.LoginPwd)
				{
					//更新User
					user.Lastdate = DateTime.Now;
					UserService.Update(user);

					result = new OperationResult(OperationResultType.Success, "登录成功");
					Session["CurrentUser"] = user;

					Session.Timeout = 20;
				}          
            }
            return Json(result);           
        }

        public ActionResult SignOut()
        {
            Session["CurrentUser"] = null;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ForgetPwd()
        {
            return PartialView();
        }
	}
}