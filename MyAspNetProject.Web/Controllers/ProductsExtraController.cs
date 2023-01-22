//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.FileProviders;
//using MyAspNetProject.Web.Models;

//// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace MyAspNetProject.Web.Controllers
//{
//    public class ProductsExtraController : Controller
//    {
//        private AppDbContext _context;
//        private readonly IMapper _mapper;
//        private readonly IFileProvider _fileProvider;


//        private readonly ProductRepository _productRepository;
//        public ProductsController(AppDbContext context, IMapper mapper, IFileProvider fileProvider)
//        {
//            _productRepository = new ProductRepository();
//            _context = context;
//            _mapper = mapper;
//            _fileProvider = fileProvider;
//        }

//        // GET: /<controller>/
//        public IActionResult Index()
//        {
//            return View();
//        }
//        [HttpPost]
//        public IActionResult AddWithTwoMethods(string Name, decimal Price, int Stock, string Color)
//        {
//            //1.yöntem

//            //var name = HttpContext.Request.Form["Name"].ToString();
//            //var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
//            //var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
//            //var color = HttpContext.Request.Form["Color"].ToString();
//            Product newProduct = new Product()
//            {
//                Name = Name,
//                Price = Price,
//                Color = Color,
//                Stock = Stock
//            };
//            _context.Products.Add(newProduct);
//            _context.SaveChanges();
//            return RedirectToAction("Index");
//        }
//        [HttpGet]
//        public IActionResult SaveProduct(Product newProduct)
//        {
//            _context.Products.Add(newProduct);
//            _context.SaveChanges();
//            return View();
//        }
//    }
//}

