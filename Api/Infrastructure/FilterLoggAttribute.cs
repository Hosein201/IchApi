using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IchApi.Infrastructure
{
    public class FilterLoggAttribute : ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    base.OnActionExecuting(context);

        //    var dicFroLogg = new Dictionary<string, object>();
        //    dicFroLogg["requestId"] = Guid.NewGuid();
        //    dicFroLogg["controllerName"]= context.ActionDescriptor.RouteValues["controllerName"];
        //    dicFroLogg["actionName"] = context.ActionDescriptor.RouteValues["actionName"];
        //    dicFroLogg["headers"]= context.ActionDescriptor.RouteValues["actionName"];
        //    var headers = context.HttpContext.Request.;
              

        //}

        //public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        //{
        //    context.
        //    return base.OnResultExecutionAsync(context, next);
        //}
    }
}
