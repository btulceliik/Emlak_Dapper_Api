using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_UI.ViewComponents.Layout
{
    public class _NavbarViewComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
