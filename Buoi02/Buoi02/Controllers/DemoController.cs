using Microsoft.AspNetCore.Mvc;

namespace Buoi02.Controllers
{
    public class DemoController : Controller
    {
        // host/Demo/ActionTest
        public string ActionTest()
        {
            return "Hello world!";
        }

        public IActionResult ActionIndex()
        {
            ViewBag.MyData = "Gửi từ Action ActionIndex";
            ViewData["message"] = "Welcome from ActionIdx";
            return View("MyView");
        }

        public IActionResult MyView()
        {
            ViewBag.MyData = "Gửi từ Action MyView";
            ViewData["message"] = "Welcome from MyView";
            return View();
        }


        // host/Demo/AAA
        public IActionResult AAA()
        {
            return Content("OK");
        }

        // host/Demo/BBB
        public int BBB()
        {
            return new Random().Next();
        }
    }
}
