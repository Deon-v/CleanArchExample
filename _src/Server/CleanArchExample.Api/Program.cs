using CleanArchExample.Api.Services;
using CleanArchExample.Application;
using CleanArchExample.Application.Common.Interfaces;
using CleanArchExample.Infrastructure;
using CleanArchExample.Infrastructure.Persistence;
using FastEndpoints;
using Microsoft.AspNetCore.ResponseCompression;

namespace CleanArchExample.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
            // Add services to the container.

            builder.Services.AddFastEndpoints();
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();

                // Initialise and seed database
                using (var scope = app.Services.CreateScope())
                {
                    var initialiser = scope.ServiceProvider.GetRequiredService<DataContextInitialiser>();
                    await initialiser.InitialiseAsync();
                    await initialiser.SeedAsync();
                }
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseFastEndpoints();
            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}