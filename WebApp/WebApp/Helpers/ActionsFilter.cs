using System;
using Microsoft.AspNetCore.Mvc.Filters;

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