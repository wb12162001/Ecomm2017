using Elmah;
using System.Web.Mvc;

namespace Ecomm.Site.WebApp.Extension.Filter
{
    public class ElmahErrorAttribute : IExceptionFilter
	{
        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled)
                ErrorSignal.FromCurrentContext().Raise(context.Exception); // 使用ELMAH记录全局异常
        }
	}
}