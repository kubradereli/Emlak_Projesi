using Microsoft.AspNetCore.Mvc;

namespace Emlak_Projesi_UI.ViewComponents.Layout
{
    public class _HeaderViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
