using Emlak_Dapper_Api.Depo.AnaSayfaHizmetDeposu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnaSayfaHizmetlerController : ControllerBase
    {
        private readonly IAnaSayfaHizmetDepo _hizmetdepo;

        public AnaSayfaHizmetlerController(IAnaSayfaHizmetDepo hizmetdepo)
        {
            _hizmetdepo = hizmetdepo;
        }

        [HttpGet]
        public async Task<IActionResult> AnaSayfaHizmetListe()
        {
            var values = await _hizmetdepo.GetAllAnaSayfaHizmetAsync();
            return Ok(values);
        }
    }
}
