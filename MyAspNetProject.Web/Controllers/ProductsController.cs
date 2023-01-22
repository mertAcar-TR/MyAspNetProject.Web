using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using MyAspNetProject.Web.Filters;
using MyAspNetProject.Web.Helpers;
using MyAspNetProject.Web.Models;
using MyAspNetProject.Web.ViewModels;

namespace MyAspNetProject.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductsController : Controller
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;


        private readonly ProductRepository _productRepository;
        public ProductsController(AppDbContext context, IMapper mapper, IFileProvider fileProvider)
        {
            _productRepository = new ProductRepository();
            _context = context;
            _mapper = mapper;
            _fileProvider = fileProvider;
        }
       
        public IActionResult Index()
        {                                              //Birden fazla tabloyu birleştirmek için include kullandık.
            List<ProductViewModel> products = _context.Products.Include(x => x.Category).Select(x => new ProductViewModel()
            {
                Id=x.Id,
                Name=x.Name,
                Price=x.Price,
                Stock=x.Stock,
                CategoryName=x.Category.Name,
                Color=x.Color,
                Description=x.Description,
                Expire=x.Expire,
                ImagePath=x.ImagePath,
                IsPublish=x.IsPublish,
                PublishDate=x.PublishDate
            }).ToList();

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }
        [Route("[controller]/[action]/{page}/{pageSize}",Name ="productPages")]

        public IActionResult Pages(int page,int pageSize)
        {
            var products = _context.Products.OrderBy(x => x.Id).ToList();
            var takeProducts = products.Skip((page - 1) * (pageSize)).Take(pageSize).ToList();

            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(_mapper.Map<List<ProductViewModel>>(takeProducts));
        }

        //urun'den once "/" kaldırırsan controller geçersiz olur sadece action ve id'yi gösterir.
        [Route("urunler/urun/{id}",Name ="product")]
        //[HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.Find(id);
            return View(_mapper.Map<ProductViewModel>(product));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Remove(int id)
        {
            var deletedEntity = _context.Set<Product>().SingleOrDefault(p => p.Id == id);
            _context.Remove(deletedEntity);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1 Ay",1 },
                 { "3 Ay",3 },
                 { "6 Ay",6 },
                 { "12 Ay",12 }
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {

                new(){ Data="Mavi" ,Value="Mavi" },
                  new(){ Data="Kırmızı" ,Value="Kırmızı" },
                    new(){ Data="Sarı" ,Value="Sarı" }


            }, "Value", "Data");


            var categories = _context.Category.ToList();

            ViewBag.categorySelect = new SelectList(categories, "Id", "Name");

            return View();
        }

        
        [HttpPost]
        public IActionResult Add(ProductViewModel newProduct)
        {
            IActionResult result = null;

            if (ModelState.IsValid)
            {
                try
                {
                    var product = _mapper.Map<Product>(newProduct);
                    if (newProduct.Image != null && newProduct.Image.Length > 0)
                    {
                        var root = _fileProvider.GetDirectoryContents("wwwroot");

                        var images = root.First(x => x.Name == "images");


                        var randomImageName = Guid.NewGuid() + Path.GetExtension(newProduct.Image.FileName);


                        var path = Path.Combine(images.PhysicalPath, randomImageName);


                        using var stream = new FileStream(path, FileMode.Create);


                        newProduct.Image.CopyTo(stream);

                        product.ImagePath = randomImageName;
                    }
                    _context.Products.Add(product);
                    _context.SaveChanges();

                    TempData["status"] = "Ürün başarıyla eklendi.";
                    return RedirectToAction("Index");

                }
                catch (Exception)
                {

                    result = View();
                }
            }
            else
            {
                result = View();
            }

            var categories = _context.Category.ToList();

            ViewBag.categorySelect = new SelectList(categories, "Id", "Name");


            ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1 Ay",1 },
                 { "3 Ay",3 },
                 { "6 Ay",6 },
                 { "12 Ay",12 }
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {

                new(){ Data="Mavi" ,Value="Mavi" },
                  new(){ Data="Kırmızı" ,Value="Kırmızı" },
                    new(){ Data="Sarı" ,Value="Sarı" }


            }, "Value", "Data");

            return result;
        }
        
        [HttpGet]
        public IActionResult Update(int id)
        {

            var product = _context.Products.Find(id);
            var categories = _context.Category.OrderBy(c => c.Id).ToList();
            ViewBag.categorySelect = new SelectList(categories, "Id", "Name",product.CategoryId);

            ViewBag.ExpireValue = product.Expire;
            ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1 Ay",1 },
                 { "3 Ay",3 },
                 { "6 Ay",6 },
                 { "12 Ay",12 }
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {

                new(){ Data="Mavi" ,Value="Mavi" },
                  new(){ Data="Kırmızı" ,Value="Kırmızı" },
                    new(){ Data="Sarı" ,Value="Sarı" }


            }, "Value", "Data", product.Color);

            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel updateProduct)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.ExpireValue = updateProduct.Expire;
                ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1 Ay",1 },
                 { "3 Ay",3 },
                 { "6 Ay",6 },
                 { "12 Ay",12 }
            };

                ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {

                new(){ Data="Mavi" ,Value="Mavi" },
                  new(){ Data="Kırmızı" ,Value="Kırmızı" },
                    new(){ Data="Sarı" ,Value="Sarı" }


            }, "Value", "Data", updateProduct.Color);
                var categories = _context.Category.OrderBy(c => c.Id).ToList();
                ViewBag.categorySelect = new SelectList(categories, "Id", "Name",updateProduct.CategoryId);
                return View();
            }


            if (updateProduct.Image != null && updateProduct.Image.Length > 0)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");

                var images = root.First(x => x.Name == "images");


                var randomImageName = Guid.NewGuid() + Path.GetExtension(updateProduct.Image.FileName);


                var path = Path.Combine(images.PhysicalPath, randomImageName);


                using var stream = new FileStream(path, FileMode.Create);


                updateProduct.Image.CopyTo(stream);

                updateProduct.ImagePath = randomImageName;
            }
            var product = _mapper.Map<Product>(updateProduct);

            _context.Products.Update(product);
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        [AcceptVerbs]
        public IActionResult HasProduct(string name)
        {
            var anyProduct = _context.Products.Any(x => x.Name.ToLower() == name.ToLower());
            if (anyProduct)
            {
                return Json("Aynı adlı ürün bulunmaktadır");
            }
            else
            {
                return Json(true);
            }
        }
    }
}