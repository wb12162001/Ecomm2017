using System.Web.Mvc;

namespace Ecomm.Site.WebApp.Areas.Authen
{
    public class AuthenAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Authen";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Authen_default",
                "Authen/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "Ecomm.Site.WebApp.Areas.Authen.Controllers"}
            );
        }
    }
}