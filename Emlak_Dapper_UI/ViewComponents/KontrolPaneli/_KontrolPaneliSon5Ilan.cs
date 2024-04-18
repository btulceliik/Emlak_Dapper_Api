using Emlak_Dapper_UI.Dtos.UrunDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Emlak_Dapper_UI.ViewComponents.KontrolPaneli
{
    public class _KontrolPaneliSon5Ilan : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _KontrolPaneliSon5Ilan(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44378/api/Urunler/Son5UrunListe");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Son5UrunVeKategoriSonucDto>>(jsonData);
                return View(values);

            }
            return View();
        }
    }
    
    }

