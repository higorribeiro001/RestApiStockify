using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RestApiStockify.Business;
using RestApiStockify.Business.Implementations;
using RestApiStockify.Model.Context;
using RestApiStockify.Repository.Generic;

var builder = WebApplication.CreateBuilder(args);

var appName = "REST API's RESTful Stockify";
var appVersion = "v1";
var appDescription = $"REST API RESTful developed for project Stockify";

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc(appVersion,
    new OpenApiInfo
    {
        Title = appName,
        Version = appVersion,
        Description = appDescription,
        Contact = new OpenApiContact
        {
            Name = "Higor Ribeiro Araujo",
            Url = new Uri("https://github.com/higorribeiro001/")
        }
    });

    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

builder.Services.AddDbContext<EFDBContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

// Versionamento de API 
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
});

// Dependency Injection
builder.Services.AddScoped<ICategoryBusiness, CategoryBusinessImplementation>();
builder.Services.AddScoped<IAddressBusiness, AddressBusinessImplementation>();
builder.Services.AddScoped<IDepositBusiness, DepositBusinessImplementation>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI(c => {
    c.SwaggerEndpoint(
        "/swagger/v1/swagger.json",
        $"{appName} - {appVersion}"
    );
});

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);

app.MapControllers();

app.Run();
