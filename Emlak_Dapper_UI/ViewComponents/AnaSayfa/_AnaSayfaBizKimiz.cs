using Emlak_Dapper_UI.Dtos.BizKimizDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Emlak_Dapper_UI.ViewComponents.AnaSayfa
{
    public class _AnaSayfaBizKimiz:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AnaSayfaBizKimiz(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client= _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44378/api/BizKimizDetaylar");
            var responseMessage2 = await client2.GetAsync("https://localhost:44378/api/BizKimizHizmetler");

            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode) 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<List<BizKimizDetaySonucDto>>(jsonData);
                var value2 = JsonConvert.DeserializeObject<List<BizKimizHizmetSonucDto>>(jsonData2);

                ViewBag.baslik = value.Select(x=>x.Baslik).FirstOrDefault();
                ViewBag.altbaslik = value.Select(x => x.AltBaslik).FirstOrDefault();
                ViewBag.aciklama1 = value.Select(x => x.Aciklama1).FirstOrDefault();
                ViewBag.aciklama2 = value.Select(x => x.Aciklama2).FirstOrDefault();

                return View(value2);
                
            }
            return View();
            
        }
    }
}
