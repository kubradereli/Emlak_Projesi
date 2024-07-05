using Microsoft.AspNetCore.Mvc;

namespace Emlak_Projesi_UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutSpinnerComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
