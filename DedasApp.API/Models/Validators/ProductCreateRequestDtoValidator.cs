using DedasApp.API.Models.ProductModels;
using DedasApp.API.Models.Repositories;
using FluentValidation;

namespace DedasApp.API.Models.Validators
{
    public class ProductCreateRequestDtoValidator : AbstractValidator<ProductCreateRequestDto>
    {
        private readonly IProductRepository _productRepository;


        public ProductCreateRequestDtoValidator([FromKeyedServices("in-memory")] IProductRepository productRepository)
        {
            _productRepository = productRepository;


            //Action<int> method1 = (x) => Console.Write(x);
            //Func<int, int> method2 = (x) => x * 2;
            //Predicate<int> method3= (x) => x > 10;


            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("isim alanı boş olamaz.")
                .NotNull().WithMessage("isim alanı boş olamaz.")
                .MinimumLength(3).WithMessage("isim alanım minimum 3  karakter olmalıdır.")
                .MaximumLength(10).WithMessage("isim alanı maksimum 10 karakter olmalıdır")
                .Must(HasProductName).WithMessage("ürün daha önce kaydedilmiştir.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("isim alanı boş olamaz.")
                .NotNull().WithMessage("isim alanı boş olamaz.")
                .ExclusiveBetween(1, 100).WithMessage("fiyat deperi 1 ile 100 arasında olmalıdır.");
        }

        private bool HasProductName(string name)
        {
            // true=> valid
            //false=> invalid
            var hasProduct = _productRepository.GetByName(name);
            return hasProduct is null;
        }
    }
}