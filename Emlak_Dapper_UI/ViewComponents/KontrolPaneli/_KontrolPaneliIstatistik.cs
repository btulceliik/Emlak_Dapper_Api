using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Emlak_Dapper_UI.ViewComponents.KontrolPaneli
{
    public class _KontrolPaneliIstatistik : ViewComponent

    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _KontrolPaneliIstatistik(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Toplam İlan Sayısı
            #region İstatistik1
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44378/api/Istatistik/UrunSayısı");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.UrunSayısı = jsonData1;
            #endregion

            //En Başarılı Personel
            #region İstatistik2
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44378/api/Istatistik/MaxPersonelIsimSayısı");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.MaxPersonelIsimSayısı = jsonData2;
            #endregion

            //Kaç Farklı Şehirden İlan Var
            #region İstatistik3
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44378/api/Istatistik/FarklıSehirSayısı");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.FarklıSehirSayısı = jsonData3;
            #endregion

            //Ortalama Kira
            #region İstatistik4
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44378/api/Istatistik/OrtalamaKiralıkUrunFiyat");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.OrtalamaKiraFiyatı = jsonData4;
            #endregion


            return View();
        }
    }
}

