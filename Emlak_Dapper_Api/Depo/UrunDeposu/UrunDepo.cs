 using Dapper;
using Emlak_Dapper_Api.Dtos.UrunDtos;
using Emlak_Dapper_Api.Models.DapperContext;
namespace Emlak_Dapper_Api.Depo.UrunDeposu
{
    public class UrunDepo : IUrunDepo

    {
        private readonly Context _context;
        public UrunDepo(Context context)
        {
            _context = context;
        }

        public async Task<List<KategorilerleIlanListPersonelDto>> GetAllKategorilerleIlanListPersonelAsync(int id)
        {
            string query = "Select UrunID, Baslik, Fiyat, KapakGorsel, Sehir, Ilce, Adres, Tip,GununFirsatiMi, KategoriIsim From Urun " +
                 "inner join Kategori on Urun.UrunKategori= Kategori.KategoriID  Where PersonelID=@personelID ";
            var parameters = new DynamicParameters();
            parameters.Add("@personelID", id);
            // Entity Framework Context üzerinden bağlantı oluştur
            using (var connection = _context.CreateConnection())
            {
                // Hazırlanan SQL sorgusunu bağlantı üzerinden çalıştır. UrunSonucVeKategoriDto tipine uygun olarak dönüştür.
                var values = await connection.QueryAsync<KategorilerleIlanListPersonelDto>(query,parameters);

                // Alınan sonuçları bir liste olarak dön.
                return values.ToList();
            }
        }

        public async Task<List<Son5UrunVeKategoriSonucDto>> GetAllSon5UrunAsync()
        {

            string query = "Select Top (5) UrunID, Baslik, Fiyat, Sehir, Ilce, UrunKategori, KategoriIsim, IlanTarihi From Urun" +
                " Inner Join Kategori On Urun.UrunKategori=Kategori.KategoriID Where Tip='Kiralık' Order By UrunID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<Son5UrunVeKategoriSonucDto>(query);
                return values.ToList();
            }
        }



        //Ürün tablomdaki verileri çekmek i.in sorgum
        public async Task<List<UrunSonucDto>> GetAllUrunAsync()
        {
            string query = "Select * From Urun";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<UrunSonucDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<UrunSonucVeKategoriDto>> GetAllUrunVeKategoriAsync()
        {
            //Urun tablosundan UrunID, Baslik, Fiyat, Sehir, Ilce ve Kategori tablosundan KategoriIsim alanlarını içerecek şekilde
            //"UrunKategori" sütununun "KategoriID" sütunuyla eşleştiği her bir kaydı birleştirir. 
            string query = "Select UrunID, Baslik, Fiyat, KapakGorsel, Sehir, Ilce, Adres, Tip,GununFirsatiMi, KategoriIsim From Urun " +
                "inner join Kategori on Urun.UrunKategori= Kategori.KategoriID  ";

            // Entity Framework Context üzerinden bağlantı oluştur
            using (var connection = _context.CreateConnection())
            {
                // Hazırlanan SQL sorgusunu bağlantı üzerinden çalıştır. UrunSonucVeKategoriDto tipine uygun olarak dönüştür.
                var values = await connection.QueryAsync<UrunSonucVeKategoriDto>(query);

                // Alınan sonuçları bir liste olarak dön.
                return values.ToList();
            }
        }

        public async void UrunGununFirsati(int id)
        {
            string query = "Update Urun set GununFirsatiMi=1 Where UrunID=@urunID";

            var parameters = new DynamicParameters();
            parameters.Add("@urunID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
            }
        }

        public async void UrunGununFirsatiDegil(int id)
        {
            string query = "Update Urun set GununFirsatiMi=0 Where UrunID=@urunID";

            var parameters = new DynamicParameters();
            parameters.Add("@urunID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
            }


        }
    }
}
    

