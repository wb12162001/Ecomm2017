using System.Web.Mvc;

namespace Ecomm.Site.WebApp.Areas.SysConfig
{
	public class SysConfigAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
				return "SysConfig";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
				"SysConfig_default",
				"SysConfig/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
				new string[] { "Ecomm.Site.WebApp.Areas.SysConfig.Controllers" }
            );
        }
    }
}