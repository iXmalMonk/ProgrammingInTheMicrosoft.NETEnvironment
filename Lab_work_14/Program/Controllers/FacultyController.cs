using Microsoft.AspNetCore.Mvc;

namespace Program.Controllers
{
    public class FacultyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
