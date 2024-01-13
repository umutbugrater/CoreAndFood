using CoreAndFood.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreAndFood.Controllers
{
    // package managere yükleecke Install-Package Microsoft.AspNetCore.Authentication.Cookies
    public class LoginController : Controller
	{
		Context c = new Context();

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Index(Admin p)
		{
			var datavalue = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
			if (datavalue != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, p.UserName)
				};
				var useridentiy = new ClaimsIdentity(claims, "Login");
				ClaimsPrincipal principal = new ClaimsPrincipal(useridentiy);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Category");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> LogOut()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index","Login");
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult SıgnUp()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> SıgnUp(Admin p)
		{
			if (ModelState.IsValid)
			{
				c.Admins.Add(p);
				c.SaveChanges();
				return RedirectToAction("Index", "Default");
			}
			return View();
		}
	}
}
