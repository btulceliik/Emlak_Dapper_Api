using Emlak_Dapper_UI.Dtos.IletisimDtos;
using Emlak_Dapper_UI.Dtos.YapılacaklarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Emlak_Dapper_UI.ViewComponents.KontrolPaneli
{
    public class _KontrolPaneliYapılacaklar:ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public _KontrolPaneliYapılacaklar(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44378/api/Yapılacaklar");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<YapılacaklarSonucDto>>(jsonData);
                return View(values);

            }
            return View();
        }

    }
}
