using Emlak_Dapper_Api.Depo.KategoriDeposu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Emlak_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorilerController : ControllerBase
    {
        private readonly IKategoriDepo _kategoriDepo;
        public KategorilerController(IKategoriDepo kategoriDepo)
        {
            _kategoriDepo = kategoriDepo;
        }

        [HttpGet]
        public async Task<IActionResult> KategoriListe()
        {
            var values = await _kategoriDepo.GetAllKategoriAsync();
            return Ok(values);
        }

    }
}
