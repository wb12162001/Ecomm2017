using Ecomm.Core.Service.SysConfig;
using Ecomm.Site.Models.SysConfig.INFOR_MASTER;
using Ecomm.Site.WebApp.Extension.Filters;
using Quick.Site.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Ecomm.Site.WebApp.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [MyofficePermission(PermissionCustomMode.Ignore)]
    public class InforController : Ecomm.Site.WebApp.Common.BaseController
    {
        [Import]
        public IINFOR_MASTERService INFOR_MASTERService { get; set; }

        // GET: Infor
        public ActionResult AboutUs(string CategoryID)
        {
            if (!string.IsNullOrEmpty(CategoryID))
            {
                ViewBag.InformationModel = INFOR_MASTERService.INFOR_MASTERList.FirstOrDefault(t => t.ID == CategoryID);
            }
            else
            {
                ViewBag.InformationModel = null;
            }
            
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Information");
            }
            ViewBag.Categories = BindCategories();
            return View();
        }
        private IEnumerable<INFOR_CATE_Model> BindCategories()
        {
            var rows = INFOR_MASTERService.QueryEntities(0, "f0.[InforCategoryName]='about us'  and a.[Status]=0 ", " a.DisplayOrder ");
            var categories = from category in rows
                             select new INFOR_CATE_Model
                             {
                                 ID = category.ID,
                                 InforSubject = category.InforSubject,
                                 ActiveLink = category.ActiveLink,
                                 Target = category.Target
                             };
            return categories;
        }

        public ActionResult ContactUs()
        {
            return View();
        }
    }
}