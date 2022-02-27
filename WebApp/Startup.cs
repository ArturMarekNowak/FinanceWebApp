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
using WebApp.Models;
using WebApp.Services;
using WebApp.Services.Interfaces;

namespace WebApp
{
    public sealed class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
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

            services.AddDbContext<FinanceWebAppDatabaseContext>();
            services.AddScoped<ICurrenciesService, CurrenciesService>();
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

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IWebHostEnvironment env,
            FinanceWebAppDatabaseContext context)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error-local-development");
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseProblemDetails();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment()) spa.UseReactDevelopmentServer("start");
            });

            loggerFactory.AddFile("Logs/logs.txt");
            SharedLogger.Logger = loggerFactory.CreateLogger("Shared");
        }

        public IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Currency>("Companies");
            builder.EntitySet<Price>("Prices");
            return builder.GetEdmModel();
        }
    }
}