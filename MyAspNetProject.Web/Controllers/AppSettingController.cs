using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAspNetProject.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class AppSettingController : Controller
    {
        private readonly IConfiguration _configuration;

        public AppSettingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.baseUrl = _configuration["baseUrl"];
            ViewBag.smsKey =  _configuration["Keys:Sms"];
            ViewBag.emailKey = _configuration.GetSection("Keys")["Email"];

            return View();
        }
    }
}

