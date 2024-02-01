﻿using DedasApp.API.Models.ProductModels;
using DedasApp.API.Models.Repositories;
using DedasApp.API.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DedasApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        // MEMORY LEAK
        // CRUD operation
        // Create, Read, Update, Delete


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.Get(id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }


        [HttpPost]
        public IActionResult CreateProduct(ProductCreateRequestDto request)
        {
            return Created(string.Empty, _productService.Save(request));
        }

        [HttpPut]
        public IActionResult UpdateProduct(ProductUpdateRequestDto product)
        {
            _productService.Update(product);
            return NoContent();
        }

        //Route constraint
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.Delete(id);
            return NoContent();
        }
    }
}