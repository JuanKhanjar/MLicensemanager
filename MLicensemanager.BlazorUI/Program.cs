using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MLicensemanager.BlazorUI.Data;
using MLicensemanager.SqlServerPlug.Data;
using MLicensemanager.SqlServerPlug.Repositories;
using MLicensemanager.UseCases.CustomersUC;
using MLicensemanager.UseCases.CustomersUC.CustomerUCIntefaces;
using MLicensemanager.UseCases.GroupsUC;
using MLicensemanager.UseCases.GroupsUC.GroupUCIntefaces;
using MLicensemanager.UseCases.PluginsInterfaces;
using MLicensemanager.UseCases.ProductsUC;
using MLicensemanager.UseCases.ProductsUC.PorductsUCInterfaces;

namespace MLicensemanager.BlazorUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddDbContextFactory<LMSDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
            builder.Services.AddTransient<IGetCustomerByIdAsyncUC, GetCustomerByIdAsyncUC>();

            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            builder.Services.AddTransient<IGetGroupWithProductsByCustomerIdAndGroupIdUC, GetGroupWithProductsByCustomerIdAndGroupIdUC>();

            builder.Services.AddScoped<IProductRepositoy, ProductRepositoy>();
            builder.Services.AddTransient<IGetAllProductFromDbAsyncUC, GetAllProductFromDbAsyncUC>();
            builder.Services.AddTransient<IGetProductsNotInListAsyncUC, GetProductsNotInListAsyncUC>();
            builder.Services.AddTransient<IGetProductsForCustomerAndGroupAsyncUC, GetProductsForCustomerAndGroupAsyncUC>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}