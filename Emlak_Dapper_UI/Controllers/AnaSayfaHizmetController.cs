using Emlak_Dapper_UI.Dtos.AnaSayfaHizmetDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Emlak_Dapper_UI.Controllers
{
    public class AnaSayfaHizmetController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AnaSayfaHizmetController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44378/api/AnaSayfaHizmetler");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AnaSayfaHizmetSonucDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AnaSayfaHizmetOlustur()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AnaSayfaHizmetOlustur(AnaSayfaHizmetOlusturDto hizmetOlusturDto)
        {
          
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(hizmetOlusturDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44378/api/AnaSayfaHizmetler", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> AnaSayfaHizmetSil(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.DeleteAsync($"https://localhost:44378/api/AnaSayfaHizmetler/{id}");
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AnaSayfaHizmetGuncelle(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44378/api/AnaSayfaHizmetler/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<AnaSayfaHizmetGuncelleDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AnaSayfaHizmetGuncelle(AnaSayfaHizmetGuncelleDto hizmetGuncelleDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(hizmetGuncelleDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44378/api/AnaSayfaHizmetler/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

