using Dapper;
using Emlak_Dapper_Api.Dtos.UrunDtos;
using Emlak_Dapper_Api.Models.DapperContext;
namespace Emlak_Dapper_Api.Depo.UrunDeposu
{
    public class UrunDepo : IUrunDepo

    {
        private readonly Context _context;
        public UrunDepo (Context context)
        {
          _context = context;
        }
        //Ürün tablomdaki verileri çekmek i.in sorgum
        public async Task<List<UrunSonucDto>> GetAllUrunAsync()
        {
            string query = "Select * From Urun";
            using (var connection= _context.CreateConnection())
            {
                var values= await connection.QueryAsync<UrunSonucDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<UrunSonucVeKategoriDto>> GetAllUrunVeKategoriAsync()
        {
            //Urun tablosundan UrunID, Baslik, Fiyat, Sehir, Ilce ve Kategori tablosundan KategoriIsim alanlarını içerecek şekilde
            //"UrunKategori" sütununun "KategoriID" sütunuyla eşleştiği her bir kaydı birleştirir. 
            string query = "Select UrunID, Baslik, Fiyat, KapakGorsel, Sehir, Ilce, Adres, Tip, KategoriIsim From Urun " +
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


    }
}
