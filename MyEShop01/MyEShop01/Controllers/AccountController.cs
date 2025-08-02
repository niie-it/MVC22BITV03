using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyEShop01.Entities;
using MyEShop01.Models;
using System.Security.Claims;

namespace MyEShop01.Controllers
{
	public class AccountController : Controller
	{
		private readonly MyEshopContext _context;

		public AccountController(MyEshopContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginVM model)
		{
			var khachHang = _context.KhachHangs.SingleOrDefault(p => p.TenDangNhap == model.UserName && p.MatKhau == model.Password);
			if (khachHang != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, khachHang.HoTen),
					new Claim(ClaimTypes.Email, khachHang.Email),
					new Claim("UserId", khachHang.Id.ToString()),
					new Claim(ClaimTypes.Role, "Admin")
				};

				var identity = new ClaimsIdentity(claims, "MyCookieAuth");
				var principal = new ClaimsPrincipal(identity);
				await HttpContext.SignInAsync("MyCookieAuth", principal);
				return RedirectToAction("Index", "Home");
			}

			ViewBag.Error = "Sai thông tin đăng nhập!";
			return View();
		}

		public async Task<IActionResult> Logout()

		{

			await HttpContext.SignOutAsync("MyCookieAuth");

			return RedirectToAction("Login");

		}

		public IActionResult AccessDenied()
		{
			return View("AccessDenied");
		}
	}
}
