using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAspNetProject.Web.Models;
using MyAspNetProject.Web.ViewModels;

namespace MyAspNetProject.Web.Views.Shared.ViewComponents
{
	public class VisitorViewComponent:ViewComponent
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;

        public VisitorViewComponent(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
			var visitors = _context.Visitors.ToList();
			var visitorModels = _mapper.Map<List<VisitorViewModel>>(visitors);
			ViewBag.visitorModels = visitorModels;
			return View();
		}
	}
}

