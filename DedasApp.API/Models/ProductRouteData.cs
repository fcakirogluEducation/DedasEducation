using Microsoft.AspNetCore.Mvc;

namespace DedasApp.API.Models
{
    public class ProductRouteData
    {
        [FromQuery] public int Id { get; set; } // value
        [FromQuery] public string Name { get; set; } = default!; //reference

        [FromQuery] public decimal Price { get; set; } // value
        //Reference Types=> class,interface,event,delegate/array/string
    }
}