using Emlak_Dapper_Api.Depo.HizmetDeposu;
using Emlak_Dapper_Api.Dtos.BizKimizHizmetDtos;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BizKimizHizmetlerController : ControllerBase
    {
        private readonly IBizKimizHizmetDepo _hizmetDepo;

        public BizKimizHizmetlerController(IBizKimizHizmetDepo hizmetDepo)
        {
            _hizmetDepo = hizmetDepo;
        }
        [HttpGet] 
        public async Task<IActionResult> GetHizmetListe()
        {
            var value= await _hizmetDepo.GetAllHizmetAsync();
            return Ok(value);
        }

		// Yeni bir kategori oluşturan endpoint
		[HttpPost]
		public async Task<IActionResult> HizmetOlustur(BizKimizHizmetOlusturDto hizmetOlusturDto)
		{
			 _hizmetDepo.HizmetOlustur(hizmetOlusturDto); // Yeni kategori oluştur
			return Ok("Biz Kimiz Hizmet kısmı başarılı bir şekilde eklendi. "); // Başarılı yanıt döndür
		}

		// Belirli bir kategoriyi silen endpoint
		[HttpDelete("{id}")]
		public async Task<IActionResult> HizmetSil(int id)
		{
			_hizmetDepo.HizmetSil(id); // Belirli bir kategoriyi sil
			return Ok("Biz Kimiz Hizmet kısmı başarılı bir şekilde silindi. "); // Başarılı yanıt döndür
		}

		// Belirli bir kategoriyi güncelleyen endpoint
		[HttpPut]
		public async Task<IActionResult> HizmetGuncelle(BizKimizHizmetGuncelleDto hizmetGuncelleDto)
		{
			_hizmetDepo.HizmetGuncelle(hizmetGuncelleDto); // Belirli bir kategoriyi güncelle
			return Ok("Biz Kimiz Hizmet kısmı başarıyla günellendi. "); // Başarılı yanıt döndür
		}

		// Belirli bir kategoriyi idsine göre getiren endpoint
		[HttpGet("{id}")]
		public async Task<IActionResult> HizmetGetir(int id)
		{
			var value = await _hizmetDepo.HizmetGetir(id); // Belirli bir kategoriyi depodan al
			return Ok(value); // Başarılı yanıt ve kategori bilgilerini içeren bir nesne döndür
		}
	}
}

