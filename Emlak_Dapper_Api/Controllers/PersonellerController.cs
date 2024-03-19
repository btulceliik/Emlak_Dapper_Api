using Emlak_Dapper_Api.Depo.KategoriDeposu;
using Emlak_Dapper_Api.Depo.PersonelDeposu;
using Emlak_Dapper_Api.Dtos.PersonelDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonellerController : ControllerBase
	{
		private readonly IPersonelDepo _personelDepo; // KategoriDepo bağımlılığı
		public PersonellerController(IPersonelDepo personelDepo)
		{
			_personelDepo = personelDepo; // Dependency Injection ile gelen kategori depo atanır
		}

		// Tüm kategorileri getiren endpoint
		[HttpGet]
		public async Task<IActionResult> PersonelListe()
		{
			var values = await _personelDepo.GetAllPersonelAsync(); // Tüm kategorileri depodan al
			return Ok(values); // Başarılı yanıt ve kategorileri içeren bir liste döndür
		}

		// Yeni bir peronel ekleyen endpoint
		[HttpPost]
		public async Task<IActionResult> PersonelOlustur(PersonelOlusturDto personelOlusturDto)
		{
			_personelDepo.PersonelOlustur(personelOlusturDto); // Yeni personel oluştur
			return Ok("Personel başarılı bir şekilde eklendi. "); // Başarılı yanıt döndür
		}

		// Belirli bir personeli silen endpoint
		[HttpDelete("{id}")]
		public async Task<IActionResult> PersonelSil(int id)
		{
			_personelDepo.PersonelSil(id); // Belirli bir personeli sil
			return Ok("Personel başarılı bir şekilde silindi. "); // Başarılı yanıt döndür
		}

		// Belirli bir personeli güncelleyen endpoint
		[HttpPut]
		public async Task<IActionResult> PersonelGuncelle(PersonelGuncelleDto personelGuncelleDto)
		{
			_personelDepo.PersonelGuncelle(personelGuncelleDto); // Belirli bir personeli güncelle
			return Ok("Personel başarıyla günellendi. "); // Başarılı yanıt döndür
		}

		// Belirli bir personeli idsine göre getiren endpoint
		[HttpGet("{id}")]
		public async Task<IActionResult> PersonelGetir(int id)
		{
			var value = await _personelDepo.PersonelGetir(id); // Belirli bir personeli depodan al
			return Ok(value); // Başarılı yanıt ve kategori bilgilerini içeren bir nesne döndür
		}







	}
}
