using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEShop01.Entities;
using MyEShop01.Models;

namespace MyEShop01.Controllers
{
	public class AjaxController : Controller
	{
		private readonly MyEshopContext _context;

		public AjaxController(MyEshopContext context)
		{
			_context = context;
		}

		[HttpGet]
		[Authorize]
		public IActionResult Search()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Search(string keyword)
		{
			var dsHangHoa = _context.HangHoas.Where(p => p.TenHh.Contains(keyword));

			var data = dsHangHoa.Select(hh => new KetQuaTimKiemVM
			{
				MaHh = hh.Id,
				TenHh = hh.TenHh,
				Hinh = hh.Hinh,
				DonGia = hh.DonGia.Value,
				NgaySX = hh.NgaySx,
				Loai = hh.MaLoaiNavigation.TenLoai
			}).ToList();
			return PartialView("TimKiemPartial", data);
		}


		[Authorize(Roles ="Sales")]
		public IActionResult TimKiem()
		{
			return View();
		}

		[HttpPost]
		public IActionResult TimKiem(string? name, double? fromPrice, double? toPrice)
		{
			var dsHangHoa = _context.HangHoas.Include(hh => hh.MaLoaiNavigation).AsQueryable();
			if (name != null)
			{
				dsHangHoa = dsHangHoa.Where(hh => hh.TenHh.Contains(name));
			}
			if (fromPrice != null)
			{
				dsHangHoa = dsHangHoa.Where(hh => hh.DonGia.Value >= fromPrice);
			}
			if (toPrice != null)
			{
				dsHangHoa = dsHangHoa.Where(hh => hh.DonGia.Value <= toPrice);
			}
			var data = dsHangHoa.Select(hh => new KetQuaTimKiemVM
			{
				MaHh = hh.Id,
				TenHh = hh.TenHh,
				Hinh = hh.Hinh,
				DonGia = hh.DonGia.Value,
				NgaySX = hh.NgaySx,
				Loai = hh.MaLoaiNavigation.TenLoai
			}).ToList();
			return Json(data);
		}

	}
}
