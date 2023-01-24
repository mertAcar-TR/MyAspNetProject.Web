using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAspNetProject.Web.Controllers
{
    public class CookieController : Controller
    {
        // GET: /<controller>/
        public IActionResult CookieCreate()
        {
            HttpContext.Response.Cookies.Append("background-color","red",new CookieOptions() { Expires=DateTime.Now.AddDays(2)});
            return View();
        }
        public IActionResult CookieRead()
        {
            var bgColor = HttpContext.Request.Cookies["background-color"];
            ViewBag.bgColor = bgColor;

            return View();
        }
    }
}

