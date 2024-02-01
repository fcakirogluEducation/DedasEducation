﻿namespace DedasApp.API.Models.ProductModels
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
    }
}