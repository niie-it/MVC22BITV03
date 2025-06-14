using Buoi02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi02.Controllers
{
	public class BookController : Controller
	{
		static List<Book> books = new List<Book>()
		{
			new Book{BookId=1, Title = "Thiết kế Web", Price = 99000, Author = "HIENLTH", IsExpire = false},
			new Book{BookId=2, Title = "Lập trình ASP.NET Core", Price = 159000, Author = "HIENLTH", IsExpire = false},
		};

		public IActionResult Index()
		{
			return View(books);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Book book)
		{
			//validation data
			books.Add(book);

			return RedirectToAction("Index");
		}
	}
}
