using Emlak_Dapper_Api.Dtos.KategoriDtos;
using Emlak_Dapper_Api.Models.DapperContext;
using Dapper;


namespace Emlak_Dapper_Api.Depo.KategoriDeposu
{
    public class KategoriDepo : IKategoriDepo
    {
        private readonly Context _context; // Veritabanı bağlamını depoda kullanmak için bir alan tanımlanır
        public KategoriDepo(Context context)
        {
            _context = context; // Dependency Injection ile gelen veritabanı bağlamı atanır
        }

        // Tüm kategorileri asenkron olarak getiren metot
        public async Task<List<KategoriSonucDto>> GetAllKategoriAsync()
        {
            string query = "Select * From Kategori"; // Tüm kategorileri getiren SQL sorgusu
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<KategoriSonucDto>(query); // Sorgu sonucunda dönen veriler alınır
                return values.ToList(); // Veriler List<KategoriSonucDto> olarak dönüştürülür ve geri döndürülür
            }
        }

        // Yeni bir kategori oluşturan metot
        public async void KategoriOlustur(KategoriOlusturDto kategoriDto)
        {
            string query = "insert into Kategori (KategoriIsim, KategoriDurum) values (@kategoriIsim,@kategoriDurum)"; // Yeni kategori eklemek için SQL sorgusu
            var parameters = new DynamicParameters();
            parameters.Add("@kategoriIsim", kategoriDto.KategoriIsim); // Parametreler eklenir
            parameters.Add("@kategoriDurum", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
            }
        }

        // Bir kategoriyi silen metot
        public async void KategoriSil(int id)
        {
            string query = "Delete From Kategori Where KategoriID= @kategoriID"; // Belirli bir ID'ye sahip kategoriyi silen SQL sorgusu
            var parameters = new DynamicParameters();
            parameters.Add("@kategoriID", id); // Parametre eklenir
            using (var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
            }

        }

        // Bir kategoriyi güncelleyen metot
        public async void KategoriGuncelle(KategoriGuncelleDto kategoriDto)
        {
            string query = " Update Kategori Set KategoriIsim=@kategoriIsim, KategoriDurum= @kategoriDurum Where KategoriID= @kategoriID"; // Belirli bir ID'ye sahip kategoriyi güncelleyen SQL sorgusu
            var parameters = new DynamicParameters();
            parameters.Add("@kategoriIsim", kategoriDto.KategoriIsim); // Parametreler eklenir
            parameters.Add("@kategoriDurum", kategoriDto.KategoriDurum);
            parameters.Add("@kategoriID", kategoriDto.KategoriID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
            }
        }

        // Belirli bir ID'ye sahip kategoriyi getiren metot
        public async Task<KategoriIDGetirDto> KategoriGetir(int id)
        {
            string query = "Select * From Kategori Where KategoriID=@KategoriID"; // Belirli bir ID'ye sahip kategoriyi getiren SQL sorgusu
            var parameters = new DynamicParameters();
            parameters.Add("@KategoriID", id); // Parametre eklenir
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<KategoriIDGetirDto>(query, parameters); // Sorgu sonucunda dönen veriler alınır
                return values; // Veri geri döndürülür
            }
        }
    }
}


