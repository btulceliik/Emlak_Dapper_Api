using Emlak_Dapper_UI.Dtos.IletisimDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Emlak_Dapper_UI.ViewComponents.KontrolPaneli
{
    public class _KontrolPaneliSon4Iletisim:ViewComponent
    {
            private readonly IHttpClientFactory _httpClientFactory;
            public _KontrolPaneliSon4Iletisim(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            public async Task<IViewComponentResult> InvokeAsync()
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:44378/api/Iletisimler/Son4Iletisim");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<Son4IletisimDto>>(jsonData);
                    return View(values);

                }
                return View();
            }
        }

    }
