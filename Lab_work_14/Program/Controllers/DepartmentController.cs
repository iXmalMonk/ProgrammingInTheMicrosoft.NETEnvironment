using Microsoft.AspNetCore.Mvc;

namespace Program.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
