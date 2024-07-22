using Microsoft.AspNetCore.Mvc;

namespace Emlak_Projesi_UI.Areas.EstateAgent.Controllers
{
    public class DashboardController : Controller
    {
        [Area("EstateAgent")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
