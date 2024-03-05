using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_UI.ViewComponents.AnaSayfa
{
    public class _DefaultFooterComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
