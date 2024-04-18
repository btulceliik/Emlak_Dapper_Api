using Microsoft.AspNetCore.SignalR;

namespace Emlak_Dapper_Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task KategoriSayısı()
        {
            // HTTP isteği yapmak için HttpClient nesnesi oluşturuluyor
            var client1 = _httpClientFactory.CreateClient();

            // Kategori sayısını almak için API'ye GET isteği gönderiliyor
            var responseMessage1 = await client1.GetAsync("https://localhost:44378/api/Istatistik/KategoriSayısı");

            // API'den gelen yanıt içeriği okunuyor
            var value1 = await responseMessage1.Content.ReadAsStringAsync();

            // Kategori sayısı, SignalR üzerinden tüm istemcilere iletiliyor
            await Clients.All.SendAsync("KategoriSayısınıAl", value1);
        }
    }
}
