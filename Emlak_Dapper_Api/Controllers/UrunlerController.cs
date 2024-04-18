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

        [HttpGet("UrunGununFirsati/{id}")]
        public async Task<IActionResult> UrunGununFirsati(int id)
        {
            _urunDepo.UrunGununFirsati(id);
            return Ok("İlan Günün Fırsatları Arasına Eklendi");
        }

        [HttpGet("UrunGununFirsatiDegil/{id}")]
        public async Task<IActionResult> UrunGununFirsatiDegil(int id)
        {
            _urunDepo.UrunGununFirsatiDegil(id);
            return Ok("İlan Günün Fırsatları Arasından Çıkarıldı");
        }

        [HttpGet("Son5UrunListe")]
        public async Task<IActionResult> Son5UrunListe()
        {
           var values= await _urunDepo.GetAllSon5UrunAsync();
            return Ok(values);
        }
        [HttpGet("IlanListesiPersonel")]
        public async Task<IActionResult> IlanListesiPersonel(int id)
        {
             var values=await _urunDepo.GetAllKategorilerleIlanListPersonelAsync(id);
            return Ok(values);
        }

    }

    }


