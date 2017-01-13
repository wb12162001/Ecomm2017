using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecomm.Core.Service.MyOffice;
using Ecomm.Domain.Models.EpSnell;
using Ecomm.Site.Models.MyOffice.SALES_EBASKET;
using System.ComponentModel.Composition.Hosting;
using System.Text;
using Quick.Framework.Common.ToolsHelper;

namespace Ecomm.Site.WebApp.Extension.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class MyofficeLayoutAttribute : ActionFilterAttribute
    {
        public MyofficeLayoutAttribute()
        {

        }

        
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            
        }
    }
}