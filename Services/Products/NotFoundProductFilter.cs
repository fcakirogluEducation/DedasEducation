using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Consts;
using Repositories.Products;

namespace DedasApp.API.Models.Products;

public class NotFoundFilterAttribute(
    [FromKeyedServices(RepositoryConst.InMemory)]
    IProductRepository productRepository) : ActionFilterAttribute
{
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


        if (!int.TryParse(firstArg.Value.ToString(), out var id)) return;


        var hasProduct = productRepository.GetById(id);


        if (hasProduct is not null) return;


        context.Result =
            new NotFoundObjectResult(Response<string>.Fail("ürün bulunamadı", HttpStatusCode.NotFound));


        base.OnActionExecuting(context);
    }

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
}