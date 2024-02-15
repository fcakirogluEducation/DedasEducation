using DedasApp.API.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Services.Products.Dtos;

namespace DedasApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : CustomBaseController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return CreateResult(productService.GetAll());
    }


    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        return CreateResult(productService.Get(id));
    }


    [HttpPost]
    public IActionResult CreateProduct(ProductCreateRequestDto request)
    {
        return CreateResult(productService.Save(request));
    }

    [HttpPut]
    public IActionResult UpdateProduct(ProductUpdateRequestDto product)
    {
        return CreateResult(productService.Update(product));
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteProduct(int id)
    {
        return CreateResult(productService.Delete(id));
    }
}