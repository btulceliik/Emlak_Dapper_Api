using Dapper;
using Emlak_Dapper_Api.Dtos.IletisimDtos;
using Emlak_Dapper_Api.Models.DapperContext;

namespace Emlak_Dapper_Api.Depo.IletisimDeposu
{
    public class IletisimDepo : IIletisimDepo
    {
        private readonly Context _context; // Veritabanı bağlamını depoda kullanmak için bir alan tanımlanır
        public IletisimDepo(Context context)
        {
            _context = context; // Dependency Injection ile gelen veritabanı bağlamı atanır
        }
        public Task<List<IletisimSonucDto>> GetAllIletisimAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IletisimIDGetirDto> IletisimGetir(int id)
        {
            throw new NotImplementedException();
        }

        public void IletisimOlustur(IletisimOlusturDto iletisimOlusturDto)
        {
            throw new NotImplementedException();
        }

        public void IletisimSil(int id)
        {
            throw new NotImplementedException();
        }

        public async  Task<List<Son4IletisimDto>> Son4Iletisim()
        {
            string query = "Select Top(4) * From Iletisim Order By IletisimID Desc"; // Tüm kategorileri getiren SQL sorgusu
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<Son4IletisimDto>(query);
                // Sorgu sonucunda dönen veriler alınır
                return values.ToList(); // Veriler List<KategoriSonucDto> olarak dönüştürülür ve geri döndürülür
            }
        }
    }
}
