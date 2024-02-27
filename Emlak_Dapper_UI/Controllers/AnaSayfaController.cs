using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_UI.Controllers
{
    public class AnaSayfaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
