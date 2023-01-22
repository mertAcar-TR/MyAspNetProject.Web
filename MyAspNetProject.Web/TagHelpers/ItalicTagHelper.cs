using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyAspNetProject.Web.TagHelpers
{
	public class ItalicTagHelper:TagHelper
	{
		public ItalicTagHelper()
		{
		}
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
			//<i></i>
			//PreContent ilk tag'a karşılık gelir. 

			output.PreContent.SetHtmlContent("<i>");
			output.PostContent.SetHtmlContent("</i>");
        }
    }
}

