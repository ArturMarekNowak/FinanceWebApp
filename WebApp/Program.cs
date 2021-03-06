using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using WebApp;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, new LoggerFactory(), app.Environment, new FinanceWebAppDatabaseContext());

app.Run();