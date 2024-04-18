using Emlak_Dapper_UI.Dtos.YapılacaklarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Emlak_Dapper_UI.Controllers
{
    public class YapılacaklarController : Controller
    {
        //consume işlemi için 
        private readonly IHttpClientFactory _httpClientFactory;

        public YapılacaklarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            //istemci consume işlemi için 
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44378/api/Yapılacaklar");

            if (responseMessage.IsSuccessStatusCode)
            //eğer işlem başarılıysa 200 ile 299 arasında
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//gelen içeriği string olarak oku
                var values = JsonConvert.DeserializeObject<List<YapılacaklarSonucDto>>(jsonData);
                //Listeleme işlemi için Deserialize kulllanılır
                //Json değeri okuyup metin formatına dönüştürme işlemim jsondan gelen datayı UrunDepoDtos ile eşleştir

                return View(values);

            }
            return View();
        }
    }
}