using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Exceptions
{
    public abstract class MappedException : Exception
    {
        protected MappedException(string? message) : base(message)
        {

        }
        
        public virtual ProblemDetails ToProblemDetails(HttpContext context)
        {
            return new()
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "foo",
                Title = "Internal Server Error",
                Detail = Message
            };
        }
    }

    public sealed class NotFoundException : MappedException
    {
        public NotFoundException(string? message) : base(message)
        {

        }
        
        public override ProblemDetails ToProblemDetails(HttpContext context)
        {
            return new()
            {
                Status = StatusCodes.Status404NotFound,
                Type = "foo",
                Title = "Not Found",
                Detail = Message
            };
        }
    }

    public sealed class BadRequestException : MappedException
    {
        public BadRequestException(string? message) : base(message) { }
        
        public override ProblemDetails ToProblemDetails(HttpContext context)
        {
            return new()
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "foo",
                Title = "Bad Request",
                Detail = Message
            };
        }
    }
}