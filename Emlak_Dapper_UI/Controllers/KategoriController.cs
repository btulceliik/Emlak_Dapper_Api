
using Emlak_Dapper_UI.Dtos.KategoriDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Emlak_Dapper_UI.Controllers
{
    public class KategoriController : Controller
    {
        //consume işlemi için 
        private readonly IHttpClientFactory _httpClientFactory;

        public KategoriController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            //istemci consume işlemi için 
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44378/api/Kategoriler");

            if (responseMessage.IsSuccessStatusCode)
            //eğer işlem başarılıysa 200 ile 299 arasında
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//gelen içeriği string olarak oku
                var values = JsonConvert.DeserializeObject<List<KategoriSonucDto>>(jsonData);
                //Listeleme işlemi için Deserialize kulllanılır
                //Json değeri okuyup metin formatına dönüştürme işlemim jsondan gelen datayı UrunDepoDtos ile eşleştir

                return View(values);

            }
            return View();
        }
        [HttpGet]
        public IActionResult KategoriOlustur()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KategoriOlustur(KategoriOlusturDto kategoriOlusturDto)
        {
            // HTTP isteklerini yapmak için bir HTTP istemcisi oluştur
            var client = _httpClientFactory.CreateClient();

            // DTO (Data Transfer Object) içeriğini JSON formatına dönüştür
            var jsonData = JsonConvert.SerializeObject(kategoriOlusturDto);

            // JSON verisini içeren StringContent oluştur, kodlama olarak UTF-8 ve medya tipi olarak application/json kullan
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Belirtilen URL'ye POST isteği yap ve yanıtı al
            var responseMessage = await client.PostAsync("https://localhost:44378/api/Kategoriler", stringContent);

            // Yanıt başarılıysa
            if (responseMessage.IsSuccessStatusCode)
            {
                // Index adlı eyleme yönlendir
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> KategoriSil(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.DeleteAsync($"https://localhost:44378/api/Kategoriler/{id}");
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> KategoriGuncelle(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44378/api/Kategoriler/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
             var jsonData=await responseMessage.Content.ReadAsStringAsync();
            var values= JsonConvert.DeserializeObject<KategoriGuncelleDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> KategoriGuncelle(KategoriGuncelleDto kategoriGuncelleDto)
        {
			var client = _httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(kategoriGuncelleDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:44378/api/Kategoriler", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

	}

	}
    
	

