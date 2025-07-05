using Microsoft.AspNetCore.Mvc;

namespace DemoArea.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class SalesEmployeeController : Controller
    {
        public IActionResult Index(int locationID)
        {
            var employees = new List<Models.Employee>
            {
                new Models.Employee
                {
                    ID = 1, Name = "Robert",
                    Designation="Manager",LocationID=1
                },
                new Models.Employee
                {
                    ID = 2, Name = "Steve",
                    Designation="Developer",  LocationID=1
                },
                new Models.Employee
                {
                    ID = 3, Name = "Rajan",
                    Designation="CEO", LocationID=2
                },
            };
			var empList = employees.Where(item => item.LocationID == locationID).ToList();

			return View(empList);
        }
    }
}
