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

        [HttpGet("DaireSayısı")]
        public IActionResult DaireSayısı()
        {
            return Ok(_istatistikDepo.DaireSayısı());
        }

        [HttpGet("OrtalamaKiralıkUrunFiyat")]
        public IActionResult OrtalamaKiralıkUrunFiyat()
        {
            return Ok(_istatistikDepo.OrtalamaKiralıkUrunFiyat());
        }

        [HttpGet("OrtalamaSatılıkUrunFiyat")]
        public IActionResult OrtalamaSatılıkUrunFiyat()
        {
            return Ok(_istatistikDepo.OrtalamaSatılıkUrunFiyat());
        }

        [HttpGet("OrtalamaOdaSayısı")]
        public IActionResult OrtalamaOdaSayısı()
        {
            return Ok(_istatistikDepo.OrtalamaOdaSayısı());
        }


        [HttpGet("KategoriSayısı")]
        public IActionResult KategoriSayısı()
        {
            return Ok(_istatistikDepo.KategoriSayısı());
        }

        [HttpGet("MaxKategoriIsimSayısı")]
        public IActionResult MaxKategoriIsimSayısı()
        {
            return Ok(_istatistikDepo.MaxKategoriIsimSayısı());
        }

        [HttpGet("MaxSehirSayısı")]
        public IActionResult MaxSehirSayısı()
        {
            return Ok(_istatistikDepo.MaxSehirSayısı());
        }

        [HttpGet("FarklıSehirSayısı")]
        public IActionResult FarklıSehirSayısı()
        {
            return Ok(_istatistikDepo.FarklıSehirSayısı());
        }
        [HttpGet("MaxPersonelIsimSayısı")]
        public IActionResult MaxPersonelIsimSayısı()
        {
            return Ok(_istatistikDepo.MaxPersonelIsimSayısı());
        }

        [HttpGet("SonEklenenUrun")]
        public IActionResult SonEklenenUrun()
        {
            return Ok(_istatistikDepo.SonEklenenUrun());
        }

        [HttpGet("EnYeniBina")]
        public IActionResult EnYeniBina()
        {
            return Ok(_istatistikDepo.EnYeniBina());
        }

        [HttpGet("EnEskiBina")]
        public IActionResult EnEskiBina()
        {
            return Ok(_istatistikDepo.EnEskiBina());
        }

        [HttpGet("PasifKategoriSayısı")]
        public IActionResult PasifKategoriSayısı()
        {
            return Ok(_istatistikDepo.PasifKategoriSayısı());
        }

        [HttpGet("UrunSayısı")]
        public IActionResult UrunSayısı()
        {
            return Ok(_istatistikDepo.UrunSayısı());
        }

    }
}
