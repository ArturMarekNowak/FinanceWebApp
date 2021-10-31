using System;
using System.IO;
using System.Reflection;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using WebApp.Exceptions;
using WebApp.Helpers;
using WebApp.Services;

namespace WebApp
{
    public sealed class Startup
    {
        private readonly IWebHostEnvironment _env;
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddOData(options =>
            {
                options.Select().Filter().Expand().Filter().OrderBy().Count().SetMaxTop(100);
                options.AddRouteComponents("api", GetEdmModel());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApp", Version = "v1"});
                c.OperationFilter<OdataFilteringOptions>();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });

            services.AddDbContext<AppDatabaseContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IPriceService, PriceService>();
            services.AddHostedService<ConsumeParsingService>();
            services.AddScoped<IParsingService, ParsingService>();


            services.AddProblemDetails(options =>
            {
                options.Map(new Func<HttpContext, MappedException, ProblemDetails>(MapException));
            });
        }

        private static ProblemDetails MapException(HttpContext context, MappedException exception)
        {
            return exception.ToProblemDetails(context);
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, AppDatabaseContext context)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            if (_env.IsDevelopment())
            {
                app.UseExceptionHandler("/error-local-development");
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseProblemDetails();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (_env.IsDevelopment()) spa.UseReactDevelopmentServer("start");
            });

            loggerFactory.AddFile("Logs/logs.txt");
            SharedLogger.Logger = loggerFactory.CreateLogger("Shared");

            context.Database.Migrate();
        }

        public IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<User>("Users");
            builder.EntitySet<Company>("Companies");
            builder.EntitySet<Price>("Prices");
            return builder.GetEdmModel();
        }
    }
}