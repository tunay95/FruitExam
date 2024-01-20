using Microsoft.AspNetCore.Mvc;

namespace FruitExamTry.Areas.Admin.Controllers
{
    public class FruitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
