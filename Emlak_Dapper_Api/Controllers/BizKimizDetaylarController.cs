using Emlak_Dapper_Api.Depo.BizKimizDeposu;
using Emlak_Dapper_Api.Dtos.BizKimizDetayDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BizKimizDetaylarController : ControllerBase
    {
        private readonly IBizKimizDetayDepo _bizKimizDetayDepo;

        public BizKimizDetaylarController(IBizKimizDetayDepo bizKimizDetayDepo)
        {
            _bizKimizDetayDepo = bizKimizDetayDepo;
        }
        // Tüm detayları getiren endpoint
        [HttpGet]
        public async Task<IActionResult> BizKimizDetayListe()
        {
            var values = await _bizKimizDetayDepo.GetAllBizKimizDetayAsync(); // Tüm detayları depodan al
            return Ok(values); // Başarılı yanıt ve detayları içeren bir liste döndür
        }

        // Yeni bir bizkimizdetay oluşturan endpoint
        [HttpPost]
        public async Task<IActionResult> BizKimizDetayOlustur(BizKimizDetayOlusturDto bizKimizDetayOlusturDto)
        {
            _bizKimizDetayDepo.BizKimizDetayOlustur(bizKimizDetayOlusturDto); // Yeni detay oluştur
            return Ok("Hakkımızda kısmı başarılı bir şekilde eklendi. "); // Başarılı yanıt döndür
        }

        // Belirli bir detayı silen endpoint
        [HttpDelete("{id}")]
        public async Task<IActionResult> BizKimizDetaySil(int id)
        {
            _bizKimizDetayDepo.BizKimizDetaySil(id); // Belirli bir detayı sil
            return Ok("Hakkımızda kısmı başarılı bir şekilde silindi. "); // Başarılı yanıt döndür
        }

        // Belirli bir detayı güncelleyen endpoint
        [HttpPut]
        public async Task<IActionResult> BizKimizDetay(BizKimizDetayGuncelleDto bizKimizDetayGuncelleDto)
        {
            _bizKimizDetayDepo.BizKimizDetayGuncelle(bizKimizDetayGuncelleDto); // Belirli bir detayı güncelle
            return Ok("Hakkımızda kısmı başarıyla günellendi. "); // Başarılı yanıt döndür
        }

        // Belirli bir kategoriyi idsine göre getiren endpoint
        [HttpGet("{id}")]
        public async Task<IActionResult> BizKimizDetayGetir(int id)
        {
            var value = await _bizKimizDetayDepo.BizKimizDetayGetir(id); // Belirli bir detayı depodan al
            return Ok(value); // Başarılı yanıt ve detay bilgilerini içeren bir nesne döndür
        }
    }
}
