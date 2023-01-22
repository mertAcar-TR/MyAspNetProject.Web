using System;
namespace MyAspNetProject.Web.ViewModels
{
	public class ProductListPartialViewModel
	{
		
		public List<ProductPartialViewModel> Products { get; set; }

		//Buraya belki ileride başka şeyler geçmek isteyebilirsin.(userId vs.)
		//O yüzden alıcağımız bir listeyi bir sınıf ile wrap'ladık.

	}
    public class ProductPartialViewModel
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
	}
}

