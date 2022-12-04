using System.Reflection;
using Demo.Controllers.Implement;
using Demo.Repository.Implement;
using Demo.Repository.Interface;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "Demo",
        TermsOfService = new Uri("https://www.youtube.com/watch?v=dQw4w9WgXcQ"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://www.youtube.com/watch?v=dQw4w9WgXcQ")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://www.youtube.com/watch?v=dQw4w9WgXcQ")
        }
    });
    
    // 依賴註釋來描述，不依賴 Xml 文件
    options.EnableAnnotations();
    
    options.DocInclusionPredicate((_,apiDescription) => string.IsNullOrWhiteSpace(apiDescription.GroupName).Equals(false));
    options.SwaggerGeneratorOptions.TagsSelector = apiDescription => new[]
    {
        apiDescription.GroupName
    };
});

builder.Services.AddDependencyInjection();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger().UseSwaggerUI(options =>
{
    // options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    
    options.SwaggerEndpoint($"v1/swagger.json","watch API 檔案");
    
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();