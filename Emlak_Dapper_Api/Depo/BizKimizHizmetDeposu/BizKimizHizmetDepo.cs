using Dapper;
using Emlak_Dapper_Api.Dtos.BizKimizHizmetDtos;
using Emlak_Dapper_Api.Models.DapperContext;

namespace Emlak_Dapper_Api.Depo.HizmetDeposu
{
    public class BizKimizHizmetDepo : IBizKimizHizmetDepo
    {
            private readonly Context _context; // Veritabanı bağlamını depoda kullanmak için bir alan tanımlanır
            public BizKimizHizmetDepo(Context context)
            {
                _context = context; // Dependency Injection ile gelen veritabanı bağlamı atanır
            }

        public async Task<List<BizKimizHizmetSonucDto>> GetAllHizmetAsync()
        {
            string query = "Select * From BizKimizHizmet"; // Tüm kategorileri getiren SQL sorgusu
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<BizKimizHizmetSonucDto>(query);
                // Sorgu sonucunda dönen veriler alınır
                return values.ToList(); // Veriler List<KategoriSonucDto> olarak dönüştürülür ve geri döndürülür
            }
        }

        public Task<BizKimizHizmetIDGetirDto> HizmetGetir(int id)
        {
            throw new NotImplementedException();
        }

        public void HizmetGuncelle(BizKimizHizmetGuncelleDto hizmetGuncelleDto)
        {
            throw new NotImplementedException();
        }

        public void HizmetOlustur(BizKimizHizmetOlusturDto hizmetOlusturDto)
        {
            throw new NotImplementedException();
        }

        public void HizmetSil(int id)
        {
            throw new NotImplementedException();
        }
    }
    

    }

