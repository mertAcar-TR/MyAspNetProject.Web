using Microsoft.AspNetCore.Mvc;

namespace MyAspNetProject.Web.Controllers
{
    public class Product2
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public int Price { get; set; }
    }
    public class MerhabaController : Controller
    {
        public IActionResult Index()
        {
            
            ViewBag.name = "Mert";
            ViewData["age"] = 31;
            ViewData["names"] = new List<string>() { "mert", "yigit" };
            ViewBag.persons = new {Id=1,Name="Mert",Age=21 };
            TempData["mesaj"] = "Temp Data ile Taşıma Yaptık";

            return View();
        }
        public IActionResult IndexWithViewModel()
        {
            var productList = new List<Product2>(){
                //tipi belli olduğu için new Product() yazmaya gerek yok
                new(){Id=1,Price=23,ProductName="Chai"},
                new(){Id=2,Price=32,ProductName="Computer"}
            };
            return View(productList);
        }
        public IActionResult Index3()
        {
           
            return View();
        }
        public IActionResult Index2()
        {
            return RedirectToAction("Index", "Merhaba");
            //return View();
        }
        public IActionResult IndexParameter(int id)
        {
            return RedirectToAction("JsonResultParameter", "Merhaba", new {id=id});
            //return View();
        }
        public IActionResult JsonResultParameter(int id)
        {
            return Json(new { Id =id});
        }
        public IActionResult ContentResult()
        {
            return Content("Merhaba Dünyalı");
        }
        public IActionResult JsonResult()
        {
            return Json(new {Id=1,Name="Kalem",Price=31});
        }
        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }
    }
}
