using Microsoft.AspNetCore.Mvc;

namespace Emlak_Projesi_UI.ViewComponents.HomePage
{
    public class _DefaultHomePageProductList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
