using Emlak_Dapper_Api.Depo.IstatistikDeposu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IstatistikController : ControllerBase
    {
        private readonly IIstatistikDepo  _istatistikDepo;

        public IstatistikController(IIstatistikDepo istatistikDepo)
        {
            _istatistikDepo = istatistikDepo;
        }

        [HttpGet("AktifKategoriSayısı")]
        public IActionResult AktifKategoriSayısı()
        {
            return Ok( _istatistikDepo.AktifKategoriSayısı());
        }

        
        [HttpGet("AktifPersonelSayısı")]
        public IActionResult AktifPersonelSayısı()
        {
            return Ok(_istatistikDepo.AktifPersonelSayısı());
        }
    }
}
