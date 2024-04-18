using Emlak_Dapper_UI.Dtos.BizKimizHizmetDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Emlak_Dapper_UI.Controllers
{

	public class BizKimizHizmetController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public BizKimizHizmetController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44378/api/BizKimizHizmetler");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<BizKimizHizmetSonucDto>>(jsonData);
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
			hizmetOlusturDto.HizmetDurum = true;
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(hizmetOlusturDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:44378/api/BizKimizHizmetler", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
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
			var responseMessage = await client.PutAsync("https://localhost:44378/api/BizKimizHizmetler/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
