using Emlak_Dapper_Api.Depo.PopülerLokasyonDeposu;
using Emlak_Dapper_Api.Dtos.PopülerLokasyonDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PopülerLokasyonlarController : ControllerBase
	{
		private readonly IPopülerLokasyonDepo _popülerLokasyonDepo;

		public PopülerLokasyonlarController(IPopülerLokasyonDepo popülerLokasyonDepo)
		{
			this._popülerLokasyonDepo = popülerLokasyonDepo;
		}

		[HttpGet]
		public async Task<IActionResult> PopülerLokasyonListe()
		{
			var value= await _popülerLokasyonDepo.GetAllPopülerLokasyonAsync();
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> PopülerLokasyonOlustur(PopülerLokasyonOlusturDto popülerLokasyonOlusturDto)
		{
			_popülerLokasyonDepo.PopülerLokasyonOlustur(popülerLokasyonOlusturDto); // Yeni kategori oluştur
			return Ok("Lokasyon başarılı bir şekilde eklendi. "); // Başarılı yanıt döndür
		}

		// Belirli bir kategoriyi silen endpoint
		[HttpDelete("{id}")]
		public async Task<IActionResult> PopülerLokasyonSil(int id)
		{
			_popülerLokasyonDepo.PopülerLokasyonSil(id); // Belirli bir kategoriyi sil
			return Ok("Lokasyon başarılı bir şekilde silindi. "); // Başarılı yanıt döndür
		}

		// Belirli bir kategoriyi güncelleyen endpoint
		[HttpPut]
		public async Task<IActionResult> PopülerLokasyonGuncelle(PopülerLokasyonGuncelleDto popülerLokasyonGuncelleDto)
		{
			_popülerLokasyonDepo.PopülerLokasyonGuncelle(popülerLokasyonGuncelleDto); // Belirli bir kategoriyi güncelle
			return Ok("Lokasyon başarıyla günellendi. "); // Başarılı yanıt döndür
		}

		// Belirli bir kategoriyi idsine göre getiren endpoint
		[HttpGet("{id}")]
		public async Task<IActionResult> PopülerLokasyonGetir(int id)
		{
			var value = await _popülerLokasyonDepo.PopülerLokasyonGetir(id); // Belirli bir kategoriyi depodan al
			return Ok(value); // Başarılı yanıt ve kategori bilgilerini içeren bir nesne döndür
		}
	}
}
