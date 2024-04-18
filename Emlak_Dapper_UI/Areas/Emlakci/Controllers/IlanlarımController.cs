using Emlak_Dapper_UI.Dtos.UrunDtos;
using Emlak_Dapper_UI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Emlak_Dapper_UI.Areas.Emlakci.Controllers
{
    [Area("Emlakci")]
    public class IlanlarımController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IGirisServis _girisServis;


        public IlanlarımController(IHttpClientFactory httpClientFactory, IGirisServis girisServis)
        {
            _httpClientFactory = httpClientFactory;
            _girisServis = girisServis;
        }

        public async Task<IActionResult> Index()
        {
            var id = _girisServis.GetKullaniciID;
            //istemci consume işlemi için 
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44378/api/Urunler/IlanListesiPersonel?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            //eğer işlem başarılıysa 200 ile 299 arasında
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//gelen içeriği string olarak oku
                var values = JsonConvert.DeserializeObject<List<KategorilerleIlanListPersonelDto>>(jsonData);
                //Listeleme işlemi için Deserialize kulllanılır
                //Json değeri okuyup metin formatına dönüştürme işlemim jsondan gelen datayı UrunDepoDtos ile eşleştir

                return View(values);

            }
            return View();
        }
    }
}