using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_UI.ViewComponents.AnaSayfa
{
    public class _DefaultBrandCompanentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
