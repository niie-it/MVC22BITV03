using Lab03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Lab03.Controllers
{
	public class ProductController : Controller
	{
		string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Products.json");
		public List<Product> GetProducts()
		{			
			var jsonStr = System.IO.File.ReadAllText(path);
			return JsonSerializer.Deserialize<List<Product>>(jsonStr);
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Product model, IFormFile Image)
		{
			if (Image != null)
			{
				model.Image = MyTool.MoveUploadedFile(Image, "Products");
			}
			var products = GetProducts();
			var existedProduct = products.SingleOrDefault(p => p.Id == model.Id);
			if (existedProduct != null)
			{
				TempData["Message"] = "Product này đã có";
				return View(model);
			}
			else
			{
				products.Add(model);
				System.IO.File.WriteAllText(path, JsonSerializer.Serialize(model));
				return RedirectToAction("Index");
			}
		}

		public IActionResult Index()
		{
			return View(GetProducts());
		}
	}
}
