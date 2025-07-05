using DemoArea.Areas.Department.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoArea.Areas.Department.Controllers
{
    [Area("department")]
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            var salesLocation = new List<Location>
            {
                new Location{ID=1, Address="Nguyễn Hữu Thọ",City="Tân Phong" },
                new Location{ID=2, Address="An Dương Vương",City="Chợ Quán" },
                new Location{ID=3, Address="Tạ Quang Bửu",City="Chánh Hưng" },
                new Location{ID=4, Address="Đống Đa",City="Tân Sơn Nhất" }
            };
            return View(salesLocation);
        }
    }
}
