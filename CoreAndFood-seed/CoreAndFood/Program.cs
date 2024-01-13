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

            // Tüm sayfalara girmek için login zorunluluðunu getirdi. Kýsaca [Authorize] komutunu yazmýþ oldu.
            // [AllowAnonymous] yazdýðýmýz Viewler için Login yapmamýza gerek kalmadý.  [AllowAnonymous] dýþýndakiler için giriþ yapmak zorunlu
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
