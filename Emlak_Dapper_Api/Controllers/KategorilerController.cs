using Emlak_Dapper_Api.Depo.KategoriDeposu;
using Emlak_Dapper_Api.Dtos.KategoriDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Emlak_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorilerController : ControllerBase
    {
        private readonly IKategoriDepo _kategoriDepo; // KategoriDepo bağımlılığı
        public KategorilerController(IKategoriDepo kategoriDepo)
        {
            _kategoriDepo = kategoriDepo; // Dependency Injection ile gelen kategori depo atanır
        }

        // Tüm kategorileri getiren endpoint
        [HttpGet]
        public async Task<IActionResult> KategoriListe()
        {
            var values = await _kategoriDepo.GetAllKategoriAsync(); // Tüm kategorileri depodan al
            return Ok(values); // Başarılı yanıt ve kategorileri içeren bir liste döndür
        }

        // Yeni bir kategori oluşturan endpoint
        [HttpPost]
        public async Task<IActionResult> KategoriOlustur(KategoriOlusturDto kategoriOlusturDto)
        {
            _kategoriDepo.KategoriOlustur(kategoriOlusturDto); // Yeni kategori oluştur
            return Ok("Kategori başarılı bir şekilde eklendi. "); // Başarılı yanıt döndür
        }

        // Belirli bir kategoriyi silen endpoint
        [HttpDelete]
        public async Task<IActionResult> KategoriSil(int id)
        {
            _kategoriDepo.KategoriSil(id); // Belirli bir kategoriyi sil
            return Ok("Kategori başarılı bir şekilde silindi. "); // Başarılı yanıt döndür
        }

        // Belirli bir kategoriyi güncelleyen endpoint
        [HttpPut]
        public async Task<IActionResult> KategoriGuncelle(KategoriGuncelleDto kategoriGuncelleDto)
        {
            _kategoriDepo.KategoriGuncelle(kategoriGuncelleDto); // Belirli bir kategoriyi güncelle
            return Ok("Kategori başarıyla günellendi. "); // Başarılı yanıt döndür
        }

        // Belirli bir kategoriyi idsine göre getiren endpoint
        [HttpGet("{id}")]
        public async Task<IActionResult> KategoriGetir(int id)
        {
            var value = await _kategoriDepo.KategoriGetir(id); // Belirli bir kategoriyi depodan al
            return Ok(value); // Başarılı yanıt ve kategori bilgilerini içeren bir nesne döndür
        }
    }
}

