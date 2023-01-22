using System;
using Microsoft.AspNetCore.Mvc;
using MyAspNetProject.Web.Models;
using MyAspNetProject.Web.ViewModels;

namespace MyAspNetProject.Web.Views.Shared.ViewComponents
{
    //[ViewComponent(Name ="p1")]
	public class ProductListViewComponent:ViewComponent
	{
		private readonly AppDbContext _context;

        public ProductListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync( int type=1)
        {
            var viewModels = _context.Products.Select(x => new ProductListComponentViewModel
            {
                Name=x.Name,
                Description=x.Description
            }).ToList();

            if (type==1)
            {
                return View("Default",viewModels);
            }
            else
            {
                return View("Type2", viewModels);
            }
        }
    }
}

