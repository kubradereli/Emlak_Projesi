using Microsoft.AspNetCore.Mvc;

namespace Emlak_Projesi_UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
