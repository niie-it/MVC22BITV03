using Lab07.Data;
using Lab07.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

		#region Create_Product
		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "NameVn");
			ViewBag.Suppliers = new SelectList(_context.Suppliers.ToList(), "Id", "Name");
			return View();
		}

		[HttpPost]
		public IActionResult Create(Product model, IFormFile Image)
		{
			if (Image != null)
			{
				model.Image = MyTool.UploadImageToFolder(Image, "Products");
			}
			try
			{
				_context.Add(model);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "NameVn", model.CategoryId);
				ViewBag.Suppliers = new SelectList(_context.Suppliers.ToList(), "Id", "Name", model.SupplierId);
				return View(model);
			}
		}
		#endregion
	}
}
