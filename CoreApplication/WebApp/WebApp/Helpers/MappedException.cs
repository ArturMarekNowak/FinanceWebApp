using System;
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
                Title = "Not Found",
                Detail = Message
            };
        }
    }

    public sealed class BadRequestException : MappedException
    {
        public BadRequestException(string? message) : base(message)
        {
        }

        public override ProblemDetails ToProblemDetails(HttpContext context)
        {
            return new()
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Bad Request",
                Detail = Message
            };
        }
    }
}