using Emlak_Dapper_UI.Dtos.BizKimizHizmetDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Emlak_Dapper_UI.Controllers
{
	public class BizKimizHizmetController : Controller
	{
		 //consume işlemi için 
		private readonly IHttpClientFactory _httpClientFactory;

		public BizKimizHizmetController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			//istemci consume işlemi için 
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44378/api/BizKimizHizmetler");

			if (responseMessage.IsSuccessStatusCode)
			//eğer işlem başarılıysa 200 ile 299 arasında
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();//gelen içeriği string olarak oku
				var values = JsonConvert.DeserializeObject<List<BizKimizHizmetSonucDto>>(jsonData);
				//Listeleme işlemi için Deserialize kulllanılır
				//Json değeri okuyup metin formatına dönüştürme işlemim jsondan gelen datayı UrunDepoDtos ile eşleştir

				return View(values);

			}
			return View();
		}
		[HttpGet]
		public IActionResult HizmetOlustur()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> HizmetOlustur(BizKimizHizmetOlusturDto hizmetOlusturDto)
		{
			// HTTP isteklerini yapmak için bir HTTP istemcisi oluştur
			var client = _httpClientFactory.CreateClient();

			// DTO (Data Transfer Object) içeriğini JSON formatına dönüştür
			var jsonData = JsonConvert.SerializeObject(hizmetOlusturDto);

			// JSON verisini içeren StringContent oluştur, kodlama olarak UTF-8 ve medya tipi olarak application/json kullan
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			// Belirtilen URL'ye POST isteği yap ve yanıtı al
			var responseMessage = await client.PostAsync("https://localhost:44378/api/BizKimizHizmetler", stringContent);

			// Yanıt başarılıysa
			if (responseMessage.IsSuccessStatusCode)
			{
				// Index adlı eyleme yönlendir
				return RedirectToAction("Index");
			}

			return View();
		}
		public async Task<IActionResult> HizmetSil(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var reponseMessage = await client.DeleteAsync($"https://localhost:44378/api/BizKimizHizmetler/{id}");
			if (reponseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> HizmetGuncelle(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44378/api/BizKimizHizmetler/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<BizKimizHizmetGuncelleDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> HizmetGuncelle(BizKimizHizmetGuncelleDto hizmetGuncelleDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(hizmetGuncelleDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:44378/api/BizKimizHizmetler", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
