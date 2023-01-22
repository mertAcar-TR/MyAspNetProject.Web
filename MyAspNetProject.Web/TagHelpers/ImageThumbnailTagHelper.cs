using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyAspNetProject.Web.TagHelpers
{
    [HtmlTargetElement("thumbnail")]
	public class ImageThumbnailTagHelper:TagHelper
	{
        public string ImageSrc { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
                 //attribute
            //<img src=""/>
            output.TagName = "img";
            string fileName = ImageSrc.Split(".")[0];
            string fileExtension = Path.GetExtension(ImageSrc); // .jpg veya .png,noktasıyla beraber verir.
            output.Attributes.SetAttribute("src",$"{fileName}-100x100{fileExtension}");
        }
    }
}

