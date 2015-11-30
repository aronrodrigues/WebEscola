using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEscola.Controllers;

namespace WebEscola.Filters
{
    public class LogFilter : ActionFilterAttribute, IActionFilter
    {
        public const String FILE_NAME = ".\\webescola.log";
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            log(context, "Início");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            log(context, "Fim");
        }

        private void log(ControllerContext context, String message)
        {
            LogController.log(String.Format("{0} {1}{2} ({3}) {4}", 
                DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:ffff"),
                context.HttpContext.Request.HttpMethod,
                context.HttpContext.Request.Url,
                context.HttpContext.GetHashCode(),
                message));
        }
    }
}