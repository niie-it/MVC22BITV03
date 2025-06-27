using Lab03.Models;
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
                using (var file = new FileStream(fullPath, FileMode.Create))
                {
                    MyFile.CopyTo(file);
                }
                TempData["Message"] = "Upload file thành công";
            }
            return RedirectToAction("Index");
        }

        public IActionResult UploadFiles(List<IFormFile> MyFiles)
        {
            if (MyFiles == null || MyFiles.Count == 0)
            {
                TempData["Message"] = "Chưa có file upload";
            }
            else
            {
                var folderStore = Path.Combine(Directory.GetCurrentDirectory(), "UploadFiles");
                if (!Directory.Exists(folderStore))
                {
                    Directory.CreateDirectory(folderStore);
                }
                foreach (var MyFile in MyFiles)
                {
                    MyTool.MoveUploadedFile(MyFile, "UploadFiles");
                }
                TempData["Message"] = "Upload file thành công";
            }
            return RedirectToAction("Index");
        }
    }
}
