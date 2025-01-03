using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using RestApiStockify.Business;
using RestApiStockify.Business.Implementations;
using RestApiStockify.Model.Context;
using RestApiStockify.Repository.Generic;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var appName = "REST API's RESTful Stockify";
var appVersion = "v1";
var appDescription = $"REST API RESTful developed for project Stockify";

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

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
    c.CustomSchemaIds(type => type.FullName);
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

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

// Dependency Injection
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IProductBusiness, ProductBusinessImplementation>();
builder.Services.AddScoped<ICategoryBusiness, CategoryBusinessImplementation>();
builder.Services.AddScoped<IAddressBusiness, AddressBusinessImplementation>();
builder.Services.AddScoped<IDepositBusiness, DepositBusinessImplementation>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

app.UseCors();

app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI(c => {
    c.SwaggerEndpoint(
        "/swagger/v1/swagger.json",
        $"{appName} - {appVersion}"
    );
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "UploadDir")),
    RequestPath = "/api/file/v1"
});

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);

app.MapControllers();

app.Run();
