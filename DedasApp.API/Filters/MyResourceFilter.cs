﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace DedasApp.API.Filters;

public class MyResourceFilter : Attribute, IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        Console.WriteLine("Resource Executing");
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        Console.WriteLine("Resource Executed");
    }
}