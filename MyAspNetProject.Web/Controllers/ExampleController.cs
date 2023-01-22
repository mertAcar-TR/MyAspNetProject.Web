using Microsoft.AspNetCore.Mvc;
using MyAspNetProject.Web.Filters;

namespace MyAspNetProject.Web.Controllers
{
    [CustomResultFilter("x.version", "1.0")]
    [Route("[controller]/[action]")]
    public class ExampleController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NoLayout()
        {
            return View();
        }
    }
}
