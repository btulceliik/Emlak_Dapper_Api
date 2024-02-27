using Emlak_Dapper_Api.Depo.UrunDeposu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunlerController : ControllerBase
    {
        private readonly IUrunDepo _urunDepo;

        public UrunlerController(IUrunDepo urunDepo)
        {
            _urunDepo = urunDepo;
        }

        [HttpGet]
        public async Task<IActionResult> UrunListe()
        {
            var values = await _urunDepo.GetAllUrunAsync();
            return Ok(values);

        }

        [HttpGet("UrunListeVeKategori")]
        public async Task<IActionResult> UrunListeVeKategori()
        {
            var values = await _urunDepo.GetAllUrunVeKategoriAsync();
            return Ok(values);

        }

    }
}
