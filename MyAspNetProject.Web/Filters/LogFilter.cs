using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyAspNetProject.Web.Filters
{
	public class LogFilter:ActionFilterAttribute
	{
		public LogFilter()
		{
		}
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("Action Method çalışmadan önce.");
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Action Method çalışdıktan sonra.");
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Debug.WriteLine("Action Method'da sonuç üretilmeden önce.");
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Debug.WriteLine("Action Method'da sonuç üretildikten sonra.");
        }
    }
}

