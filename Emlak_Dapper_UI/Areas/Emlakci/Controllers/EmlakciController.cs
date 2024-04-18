using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_UI.Areas.Emlakci.Controllers
{
    [Area ("Emlakci")]
    public class EmlakciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
