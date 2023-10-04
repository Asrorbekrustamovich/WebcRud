using Microsoft.AspNetCore.Mvc;

namespace WebCRUD.APi.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
