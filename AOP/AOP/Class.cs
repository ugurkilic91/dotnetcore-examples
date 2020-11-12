using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

public class MySampleActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        context.Result = new ContentResult()
        {
            Content = "Resource unavailable - header not set."
        };
        if (!context.ModelState.IsValid)
        {
            context.Result = new BadRequestObjectResult(
                                                context.ModelState);
        }
        context.Result = new BadRequestObjectResult(
                                             context.ModelState);
        if (context.HttpContext.TraceIdentifier==null)
        {
            context.HttpContext.Response.Redirect("http://www.google.com");
        }
        //context.Result = new BadRequestObjectResult (context.HttpContext.);
        //context.Result = new 
        // Do something before the action executes.

        //MyDebug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Do something after the action executes.
        //MyDebug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
    }
}