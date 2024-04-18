using Emlak_Dapper_UI.Dtos.KategoriDtos;
using Emlak_Dapper_UI.Dtos.UrunDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Emlak_Dapper_UI.Controllers
{
    public class UrunController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UrunController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44378/api/Urunler/UrunListeVeKategori");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<UrunSonucDto>>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UrunOlustur()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44378/api/Kategoriler");
       
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<KategoriSonucDto>>(jsonData);

                List<SelectListItem> kategoriDegerleri = (from x in values.ToList()
                                                          select new SelectListItem
                                                          {
                                                              Text = x.KategoriIsim,
                                                              Value = x.KategoriID.ToString()
                                                          }).ToList();
                ViewBag.v = kategoriDegerleri;

                return View();
            }

            public async Task<IActionResult> UrunGununFirsatiDegil(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:44378/api/Urunler/UrunGununFirsatiDegil/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();

            }
 
            public async Task<IActionResult> UrunGununFirsati(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:44378/api/Urunler/UrunGununFirsati/" + id);
                 if (responseMessage.IsSuccessStatusCode)
                 {
                    return RedirectToAction("Index");
                 }
                 return View();

        }
    }

    } 

