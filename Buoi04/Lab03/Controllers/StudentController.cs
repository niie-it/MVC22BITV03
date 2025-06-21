using Lab03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Lab03.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        string jsonFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "student.json");
        string textFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "student.txt");
        public IActionResult Manage(Student model, string SaveType)
        {
            if (SaveType == "Lưu JSON")
            {
                var jsonStr = JsonSerializer.Serialize(model);
                System.IO.File.WriteAllText(jsonFile, jsonStr);
            }
            else if (SaveType == "Lưu TXT")
            {

            }
            return View("Index", model);
        }
    }
}
