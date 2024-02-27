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
            string query = "Select UrunID, Baslik, Fiyat, Sehir, Ilce, KategoriIsim From Urun" +
                " inner join Kategori on Urun.UrunKategori= Kategori.KategoriID  ";

            using (var connection= _context.CreateConnection())
            {
                var values= await connection.QueryAsync <UrunSonucVeKategoriDto>(query);
                return values.ToList();
            }
        }

  
    }
}
