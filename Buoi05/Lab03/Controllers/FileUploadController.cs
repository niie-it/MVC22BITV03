using Microsoft.AspNetCore.Mvc;

namespace Lab03.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UploadFile(IFormFile MyFile)
        {
            if (MyFile == null)
            {
                TempData["Message"] = "Chưa có file upload";
            }
            else
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", MyFile.FileName);
                using(var file = new FileStream(fullPath, FileMode.Create))
                {
                    MyFile.CopyTo(file);
                }
                TempData["Message"] = "Upload file thành công";
            }
            return RedirectToAction("Index");
        }
    }
}
