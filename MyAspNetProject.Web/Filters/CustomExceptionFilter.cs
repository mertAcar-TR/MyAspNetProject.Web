using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyAspNetProject.Web.Models;

namespace MyAspNetProject.Web.Filters
{
	public class CustomExceptionFilter:ExceptionFilterAttribute
	{
		public CustomExceptionFilter()
		{
		}
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;//Hatayı biz ele alıcaz dedik.

            var error = context.Exception.Message;

            context.Result= new RedirectToActionResult("Error", "Home", new ErrorViewModel()

            {
                Errors = new List<string>()
                    {
                        $"{error}"
                    }
            }

                    );
        }
    }
}

