using Emlak_Dapper_Api.Depo.KategoriDeposu;
using Emlak_Dapper_Api.Dtos.KategoriDto;
using Emlak_Dapper_Api.Dtos.KategoriDtos;
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
        [HttpPost]
        public async Task<IActionResult> KategoriOlustur(KategoriOlusturDto kategoriOlusturDto)
        {
            _kategoriDepo.KategoriOlustur(kategoriOlusturDto);
            return Ok("Kategori başarılı bir şekilde eklendi. ");

        }

        [HttpDelete]
        public async Task<IActionResult> KategoriSil(int id)
        {
            _kategoriDepo.KategoriSil(id);
            return Ok("Kategori başarılı bir şekilde silindi. ");
        }

        [HttpPut]

        public async Task<IActionResult> KategoriGuncelle(KategoriGuncelleDto kategoriGuncelleDto)
        {
            _kategoriDepo.KategoriGuncelle(kategoriGuncelleDto);
            return Ok("Kategori başarıyla günellendi. ");
        }

        }


    }

