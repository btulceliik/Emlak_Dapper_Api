using Emlak_Dapper_UI.Dtos.PersonelDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Emlak_Dapper_UI.Controllers
{
    public class PersonelController : Controller
    {
        //consume işlemi için 
        private readonly IHttpClientFactory _httpClientFactory;

        public PersonelController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            //istemci consume işlemi için 
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44378/api/Personeller");

            if (responseMessage.IsSuccessStatusCode)
            //eğer işlem başarılıysa 200 ile 299 arasında
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//gelen içeriği string olarak oku
                var values = JsonConvert.DeserializeObject<List<PersonelSonucDto>>(jsonData);
                //Listeleme işlemi için Deserialize kulllanılır
                //Json değeri okuyup metin formatına dönüştürme işlemim jsondan gelen datayı UrunDepoDtos ile eşleştir

                return View(values);

            }
            return View();
        }
        [HttpGet]
        public IActionResult PersonelOlustur()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PersonelOlustur(PersonelOlusturDto personelOlusturDto)
        {
            // HTTP isteklerini yapmak için bir HTTP istemcisi oluştur
            var client = _httpClientFactory.CreateClient();

            // DTO (Data Transfer Object) içeriğini JSON formatına dönüştür
            var jsonData = JsonConvert.SerializeObject(personelOlusturDto);

            // JSON verisini içeren StringContent oluştur, kodlama olarak UTF-8 ve medya tipi olarak application/json kullan
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Belirtilen URL'ye POST isteği yap ve yanıtı al
            var responseMessage = await client.PostAsync("https://localhost:44378/api/Personeller", stringContent);

            // Yanıt başarılıysa
            if (responseMessage.IsSuccessStatusCode)
            {
                // Index adlı eyleme yönlendir
                return RedirectToAction("Index");
            }

            return View();
        }
		public async Task<IActionResult> PersonelSil(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var reponseMessage = await client.DeleteAsync($"https://localhost:44378/api/Personeller/{id}");
			if (reponseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> PersonelGuncelle(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44378/api/Personeller/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<PersonelGuncelleDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> PersonelGuncelle(PersonelGuncelleDto personelGuncelleDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(personelGuncelleDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:44378/api/Personeller", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
