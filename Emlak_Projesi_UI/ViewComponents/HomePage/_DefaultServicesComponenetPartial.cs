using Microsoft.AspNetCore.Mvc;

namespace Emlak_Projesi_UI.ViewComponents.HomePage
{
    public class _DefaultServicesComponenetPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
