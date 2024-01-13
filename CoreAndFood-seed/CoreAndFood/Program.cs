using CoreAndFood.Entities;
using CoreAndFood.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;



namespace CoreAndFood
{
    public class Program
	{
		public static void Main(string[] args)
		{
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Context>();          

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie
                (x =>
                {
                    x.LoginPath = "/Login/Index";
                }
                );

            // T�m sayfalara girmek i�in login zorunlulu�unu getirdi. K�saca [Authorize] komutunu yazm�� oldu.
            // [AllowAnonymous] yazd���m�z Viewler i�in Login yapmam�za gerek kalmad�.  [AllowAnonymous] d���ndakiler i�in giri� yapmak zorunlu
            builder.Services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Default}/{action=Index}/{id?}");


            SeedData.EnsurePopulated(app);
            app.Run();

        }
    }
}
