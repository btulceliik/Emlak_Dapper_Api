using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_UI.ViewComponents.Layout
{
    public class _BaslangicGorunumu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
