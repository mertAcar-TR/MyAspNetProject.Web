using System;
using AutoMapper;
using MyAspNetCoreApp.Web.ViewModels;
using MyAspNetProject.Web.Models;
using MyAspNetProject.Web.ViewModels;

namespace MyAspNetProject.Web.Mapping
{
	public class ViewModelMapping:Profile
	{
		public ViewModelMapping()
		{
			CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Visitor, ProductUpdateViewModel>().ReverseMap();
            CreateMap<Visitor, VisitorViewModel>().ReverseMap();

        }
	}
}

