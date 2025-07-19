using Lab07.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab07.Controllers
{
	public class ProductsController : Controller
	{
		private readonly MvcNiieLabContext _context;

		public ProductsController(MvcNiieLabContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var data = _context.Products
				.Include(p => p.Supplier)
				.Include(p => p.Category);
			return View(data.ToList());
		}
	}
}
