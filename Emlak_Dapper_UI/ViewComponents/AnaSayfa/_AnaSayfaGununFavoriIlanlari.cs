using Emlak_Dapper_UI.Dtos.UrunDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Emlak_Dapper_UI.ViewComponents.AnaSayfa
{
    public class _AnaSayfaGununFavoriIlanlari : ViewComponent
    {
        //consume işlemi için 
        private readonly IHttpClientFactory _httpClientFactory;

        public _AnaSayfaGununFavoriIlanlari(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            //istemci consume işlemi için örnek
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44378/api/Urunler/UrunListeVeKategori");
            //responceMessage adlı bir değişken tanımlandı ve adrese istek atıldı
         
            if (responseMessage.IsSuccessStatusCode)
                //eğer işlem başarılıysa 200 ile 299 arasında işlem başarılıysa;
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();//gelen json formatlı içeriği string olarak oku
                var values = JsonConvert.DeserializeObject<List<UrunSonucDto>>(jsonData);
                //Json değeri okuyup metin formatına dönüştürme işlemim jsondan gelen datayı UrunDepoDtos ile eşleştir

                return View (values);

            }
            return View();
        }
    }
}
