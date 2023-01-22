using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyAspNetProject.Web.Filters
{
	//public class CacheResourceFilter:Attribute,IResourceFilter
	//{
 //       private static IActionResult _cache;
	//	public CacheResourceFilter()
	//	{
	//	}

 //       public void OnResourceExecuted(ResourceExecutedContext context) //Response gelince
 //       {
 //           _cache = context.Result;
 //       }

 //       public void OnResourceExecuting(ResourceExecutingContext context) //Request gelince
 //       {
 //           if (_cache!=null)
 //           {
 //               context.Result = _cache;
 //           }
 //       }
 //   }
}

