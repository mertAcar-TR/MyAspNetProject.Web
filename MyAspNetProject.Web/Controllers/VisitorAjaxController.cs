using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAspNetProject.Web.Models;
using MyAspNetProject.Web.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAspNetProject.Web.Controllers
{
    public class VisitorAjaxController : Controller
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public VisitorAjaxController(IMapper mapper,AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveVisitorComment(VisitorViewModel visitorViewModel)
        {
                var visitor = _mapper.Map<Visitor>(visitorViewModel);
                _context.Visitors.Add(visitor);
                _context.SaveChanges();
               
                return Json(new {IsSuccess="true"});   
        }

        [HttpGet]
        public IActionResult VisitorCommentList()
        {
            var visitors = _context.Visitors.ToList();
            var visitorViewModels = _mapper.Map<List<VisitorViewModel>>(visitors);


            return Json(visitorViewModels);
        }
    }
}

