using Emlak_Dapper_UI.Dtos.UrunDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Emlak_Dapper_UI.ViewComponents.AnaSayfa
{
    public class _DefaultHomePageProducList : ViewComponent
    {
        //consume işlemi için 
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultHomePageProducList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44378/api/Urunler/UrunListeVeKategori");
         
            if (responseMessage.IsSuccessStatusCode)
                //eğer işlem başarılıysa 200 ile 299 arasında
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();//gelen mesajları string olarak oku
                var values = JsonConvert.DeserializeObject<List<UrunDepoDtos>>(jsonData);
                return View (values);

            }
            return View();
        }
    }
}
