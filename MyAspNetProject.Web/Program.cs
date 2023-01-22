using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using MyAspNetProject.Web.Filters;
using MyAspNetProject.Web.Helpers;
using MyAspNetProject.Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(options =>
{

    options.UseNpgsql(builder.Configuration.GetConnectionString("SqlCon"));

});

builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));


//builder.Services.AddSingleton<IHelper, Helper>();
//builder.Services.AddScoped<IHelper, Helper>();
builder.Services.AddTransient<IHelper, Helper>(sp =>
{
  return  new Helper(true);
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<NotFoundFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//blog/abc => blog controller > article action methodu çalışsın
//blog/ddd => blog controller > article action methodu çalışsın
//app.MapControllerRoute(
//    name: "blogs",
//    pattern: "blog/{*article}",
//    defaults: new {controller="blog",action="article"});

//app.MapControllerRoute(
//    name: "blogs",
//    pattern: "{controller=Blog}/{action=Article}/{name}/{id}");

//app.MapControllerRoute(
//    name: "pages",
//    pattern: "{controller}/{action}/{page}/{pageSize}");

//app.MapControllerRoute(
//    name: "productgetbyid",
//    pattern: "{controller}/{action}/{productId}");



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
