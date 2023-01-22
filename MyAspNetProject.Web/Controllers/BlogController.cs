using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAspNetProject.Web.Controllers
{
    public class BlogController : Controller
    {
        // blog/article/makale-ismi/id
        public IActionResult Article(string name,int id)
        {
            //var routes = Request.RouteValues["article"];
            return View();
        }
    }
}

