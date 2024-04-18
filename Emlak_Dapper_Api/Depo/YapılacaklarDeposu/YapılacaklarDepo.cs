using Dapper;
using Emlak_Dapper_Api.Dtos.YapılacaklarDtos;
using Emlak_Dapper_Api.Models.DapperContext;

namespace Emlak_Dapper_Api.Depo.YapılacaklarDeposu
{
    public class YapılacaklarDepo : IYapılacaklarDepo
    {
        private readonly Context _context; // Veritabanı bağlamını depoda kullanmak için bir alan tanımlanır
        public YapılacaklarDepo(Context context)
        {
            _context = context; // Dependency Injection ile gelen veritabanı bağlamı atanır
        }

        public async Task<List<YapılacaklarSonucDto>> GetAllYapılacaklarAsync()
        {
            string query = "Select * From Yapilacaklar";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<YapılacaklarSonucDto>(query);
                return values.ToList();
            }
        }

        public void YaplacaklarOlustur(YapılacaklarOlusturDto yapilacaklarDto)
        {
            throw new NotImplementedException();
        }

        public void YapılacaklarGuncelle(YapılacaklarGuncelleDto yapilacaklarDto)
        {
            throw new NotImplementedException();
        }

        public Task<YapılacaklarIDGetirDto> YapılacaklarIDGetir(int id)
        {
            throw new NotImplementedException();
        }

        public void YapılacaklarSil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
