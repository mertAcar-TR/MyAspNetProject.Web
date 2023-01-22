using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MyAspNetProject.Web.ViewModels
{
	public class ProductViewModel
	{
        public int Id { get; set; }

        //[Remote("HasProduct","Products")]
        [Required(ErrorMessage ="İsim alanı boş olamaz.")]
        [StringLength(20,MinimumLength =1,ErrorMessage ="Ürün adı 20 karakterden büyük olamaz.")]
        public string? Name { get; set; }

        //[RegularExpression(@"^[0-9]+(\.[0-9]{1,2})",ErrorMessage ="Fiyat,noktadan sonra en fazla 2 basamak içermelidir.")]
        [Required(ErrorMessage = "Fiyat alanı boş olamaz.")]
        [Range(1,1000,ErrorMessage ="Fiyat 1 ile 1000 arasında olmalı.")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Stock alanı boş olamaz.")]
        [Range(1,200,ErrorMessage ="Stok değerleri 1 ile 200 arasında olmalı.")]
        public int? Stock { get; set; }

        [Required(ErrorMessage = "Açıklama alanı boş olamaz.")]
        [StringLength(50,MinimumLength =10,ErrorMessage ="Açıklama 10 ile 50 karakter arası olmalı.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Renk seçiniz.")]
        public string? Color { get; set; }

        public DateTime? PublishDate { get; set; }

        public bool IsPublish { get; set; }

        [Required(ErrorMessage = "Yayınlanma süresi seçiniz.")]
        public int? Expire { get; set; }

        [ValidateNever]
        public IFormFile? Image { get; set; }

        [ValidateNever]
        public string? ImagePath { get; set; }

        [Required(ErrorMessage = "Kategori seçiniz.")]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        //[EmailAddress(ErrorMessage ="Mail formatında giriniz.")]
        //public string Email { get; set; }
    }
}

