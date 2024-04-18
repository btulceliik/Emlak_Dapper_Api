using Emlak_Dapper_Api.Depo.AnaSayfaHizmetDeposu;
using Emlak_Dapper_Api.Dtos.AnaSayfaHizmetDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnaSayfaHizmetlerController : ControllerBase
    {
        private readonly IAnaSayfaHizmetDepo _hizmetDepo;

        public AnaSayfaHizmetlerController(IAnaSayfaHizmetDepo hizmetDepo)
        {
            _hizmetDepo = hizmetDepo;
        }

        [HttpGet]
        public async Task<IActionResult> AnaSayfaHizmetListe()
        {
            var values = await _hizmetDepo.GetAllAnaSayfaHizmetAsync();
            return Ok(values);
        }

        // Yeni bir kategori oluşturan endpoint
        [HttpPost]
        public async Task<IActionResult> AnaSayfaHizmetOlustur(AnaSayfaHizmetOlusturDto hizmetOlusturDto)
        {
            _hizmetDepo.AnaSayfaHizmetOlustur(hizmetOlusturDto); // Yeni kategori oluştur
            return Ok("Hizmet kısmı başarılı bir şekilde eklendi. "); // Başarılı yanıt döndür
        }

        // Belirli bir kategoriyi silen endpoint
        [HttpDelete("{id}")]
        public async Task<IActionResult> AnaSayfaHizmetSil(int id)
        {
            _hizmetDepo.AnaSayfaHizmetSil(id); // Belirli bir kategoriyi sil
            return Ok(" Hizmet kısmı başarılı bir şekilde silindi. "); // Başarılı yanıt döndür
        }

        // Belirli bir kategoriyi güncelleyen endpoint
        [HttpPut]
        public async Task<IActionResult> AnaSayfaHizmetGuncelle(AnaSayfaHizmetGuncelleDto hizmetGuncelleDto)
        {
            _hizmetDepo.AnaSayfaHizmetGuncelle(hizmetGuncelleDto); // Belirli bir kategoriyi güncelle
            return Ok(" Hizmet kısmı başarıyla günellendi. "); // Başarılı yanıt döndür
        }

        // Belirli bir kategoriyi idsine göre getiren endpoint
        [HttpGet("{id}")]
        public async Task<IActionResult> AnaSayfaHizmetGetir(int id)
        {
            var value = await _hizmetDepo.AnaSayfaHizmetGetir(id); // Belirli bir kategoriyi depodan al
            return Ok(value); // Başarılı yanıt ve kategori bilgilerini içeren bir nesne döndür
        }
    }
}
    

