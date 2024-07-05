using Microsoft.AspNetCore.Mvc;

namespace Emlak_Projesi_UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
