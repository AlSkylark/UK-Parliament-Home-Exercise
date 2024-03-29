using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Services.Interfaces;
using UKParliament.CodeTest.Web.Data;

namespace UKParliament.CodeTest.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<PersonManagerContext>(op => op.UseInMemoryDatabase("PersonManager"));

            builder.Services.AddScoped<IPersonService<MP>, MPService>();
            builder.Services.AddScoped<IAffiliationService, AffiliationService>();
            builder.Services.AddScoped<IAddressService, AddressService>();
            //builder.Services.AddScoped<IPersonService<Person>, PersonService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");

            using var scope = ((IApplicationBuilder)app).ApplicationServices.CreateScope();
            DatabaseSeeder.Seed(scope.ServiceProvider.GetService<PersonManagerContext>());

            app.Run();
        }

    }
}