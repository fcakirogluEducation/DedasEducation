using System.ComponentModel.DataAnnotations;

namespace DedasApp.API.Models.ProductModels
{
    public class ProductCreateRequestDto
    {
        public string? Name { get; set; }

        public decimal? Price { get; set; }
    }

    #region Validation Annotations

    //public class ProductCreateRequestDto
    //{
    //    //Validation Data Annotations
    //    [StringLength(10, ErrorMessage = "isim alanı en fazla 10 karakter olmalıdır.")]
    //    [Required(ErrorMessage = "isim alanı boş olamaz.")]
    //    public string? Name { get; set; }

    //    [Range(10, 1000, ErrorMessage = "fiyatın değeri 10 ile 1000 arasında olmalıdır.")]
    //    [Required(ErrorMessage = "fiyat alanı boş olamaz.")]
    //    public decimal? Price { get; set; }

    //    //[Url(ErrorMessage = "resim url formatı hatalı.")]
    //    //[Required(ErrorMessage = "resim alanı boş olamaz.")]
    //    //public string PictureUrl { get; set; }


    //    //[RegularExpression("")]
    //    //[Required(ErrorMessage = "telefon numarası alanı boş olamaz.")]
    //    //[Phone(ErrorMessage = "telefon numarası formatı hatalı.")]
    //    //public string? Phone { get; set; }
    //} 

    #endregion
}