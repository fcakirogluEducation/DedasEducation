using DedasApp.API.Consts;
using DedasApp.API.Models.Repositories;
using System;
using DedasApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DedasApp.API.Filters
{
    public class NotFoundFilterAttribute(
        [FromKeyedServices(RepositoryConst.InMemory)]
        IProductRepository productRepository) : ActionFilterAttribute
    {
        #region Constructor
        //private readonly IProductRepository _productRepository;

        //public NotFoundFilterAttribute([FromKeyedServices(RepositoryConst.InMemory)] IProductRepository productRepository)
        //{


        //    //Doğru
        //    //nameof(KeyedRepositoryName.InMemory)
        //    //Yanlış
        //    //KeyedRepositoryName.InMemory.ToString()
        //    _productRepository = productRepository;
        //} 
        #endregion

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var firstArg = context.ActionArguments.FirstOrDefault();


            // code smell
            // key - value
            // id = 10

            // Fast fail
            //Guard clauses


            if (firstArg.Value is null || firstArg.Key is null) return;


            if (!firstArg.Key.Equals("id", StringComparison.CurrentCultureIgnoreCase)) return;


            if (!int.TryParse(firstArg.Value.ToString(), out int id)) return;


            var hasProduct = productRepository.GetById(id);


            if (hasProduct is not null) return;


            var response = new Response<string>() { Errors = ["Ürün bulunamadı"] };

            context.Result = new NotFoundObjectResult(response);


            base.OnActionExecuting(context);
        }
    }
}