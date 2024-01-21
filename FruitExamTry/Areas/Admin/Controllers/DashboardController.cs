using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FruitExamTry.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController:Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }


    }
}
