using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace WebApp.Helpers
{
    public class ActionsFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            var inputParameters = string.Join(", ", context.ActionArguments.Values);

            Console.WriteLine(actionName + " being executed");
            Console.WriteLine("Input parameters: " + inputParameters);
            
            SharedLogger.Logger.LogInformation(actionName + " being executed");
            SharedLogger.Logger.LogInformation("Input parameters: " + inputParameters);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            var result = context.Result;
            
            Console.WriteLine(actionName + " executed");
            Console.WriteLine("Result: " + result);
            
            SharedLogger.Logger.LogInformation(actionName + " being executed");
            SharedLogger.Logger.LogInformation("Result: " + result);
        }
    }
}