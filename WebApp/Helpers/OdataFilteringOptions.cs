using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApp.Helpers
{
    public class OdataFilteringOptions : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.ActionDescriptor is ControllerActionDescriptor descriptor
                && descriptor.ActionName.StartsWith("GetAll"))
            {
                Dictionary<string, string> parameters = new()
                {
                    {"$top", "The max number of records"},
                    {"$skip", "The number of records to skip"},
                    {"$filter", "A function that must evaluate to true for a record to be returned"},
                    {"$select", "Specifies a subset of properties to return"},
                    {"$orderby", "Determines what values are used to order a collection of records"}
                };

                foreach (var pair in parameters)
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = pair.Key,
                        Required = false,
                        Description = pair.Value,
                        In = new ParameterLocation()
                    });
            }
        }
    }
}