using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.EmployeeManager.Data;

namespace WiredBrainCoffee.EmployeeManager
{
    public class Program
    {
        public static async void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddDbContext<EmployeeManagerDbContext>(
                opt => opt.UseSqlServer(
                    builder.Configuration.GetConnectionString("EmployeeManagerDb")));

            var app = builder.Build();

            await EnsureDatabaseIsMigrated(app.Services);

            async Task EnsureDatabaseIsMigrated(IServiceProvider services)
            {

            }

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