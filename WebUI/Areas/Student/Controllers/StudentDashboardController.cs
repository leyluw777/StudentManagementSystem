using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    public class StudentDashboardController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
