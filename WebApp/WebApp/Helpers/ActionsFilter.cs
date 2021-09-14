using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace WebApp.Helpers
{
    public class ActionsFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("bar"); 
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("foo");
        }
    }
}