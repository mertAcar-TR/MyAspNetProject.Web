using System;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MyAspNetProject.Web.Models;

namespace MyAspNetProject.Web.TagHelpers
{
	public class ProductShowTagHelper:TagHelper
	{
		public Product Product { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.SetHtmlContent(@$"
            <div>
                <ul class='list-group'>
                    <li class='list-group-item'>{Product.Id}</li>
                    <li class='list-group-item'>{Product.Name}</li>
                    <li class='list-group-item'>{Product.Price}</li>
                    <li class='list-group-item'>{Product.Stock}</li>
                </ul>

             </div>");
        }
    }
}

