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

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var book = books.SingleOrDefault(p => p.BookId == id);
			if (book == null)
			{
				return NotFound();
			}
			else
			{
				return View(book);
			}
		}

		[HttpPost]
		public IActionResult Edit(Book editModel)
		{
			var book = books.SingleOrDefault(p => p.BookId == editModel.BookId);
			if (book != null)
			{
				book.Title = editModel.Title;
				book.Price = editModel.Price;
				book.Author = editModel.Author;
				book.IsExpire = editModel.IsExpire;
			}
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var book = books.SingleOrDefault(p => p.BookId == id);
			if (book != null)
			{
				books.Remove(book);
				TempData["Message"] = $"Xóa sách {book.Title} thành công";
			}
			else
			{
				TempData["Message"] = $"Không có sách có mã {id} để xóa";
			}
			return RedirectToAction("Index");
		}
	}
}
