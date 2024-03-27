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

        public async Task<BizKimizHizmetIDGetirDto> HizmetGetir(int id)
        {
			string query = "Select * From BizKimizHizmet Where HizmetID=@hizmetID";
			// Belirli bir ID'ye sahip kategoriyi getiren SQL sorgusu
			var parameters = new DynamicParameters();
			parameters.Add("@hizmetID", id);
			// Parametre eklenir
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<BizKimizHizmetIDGetirDto>(query, parameters);
				// Sorgu sonucunda dönen veriler alınır
				return values;
				// Veri geri döndürülür
			}
		}

        public async  void HizmetGuncelle(BizKimizHizmetGuncelleDto hizmetGuncelleDto)
        {
			string query = " Update BizKimizHizmet Set HizmetIsim=@hizmetIsim, HizmetDurum= @hizmetDurum Where HizmetID= @hizmetID";
			// Belirli bir ID'ye sahip kategoriyi güncelleyen SQL sorgusu
			var parameters = new DynamicParameters();
			parameters.Add("@hizmetID", hizmetGuncelleDto.HizmetID);
			parameters.Add("@hizmetIsim", hizmetGuncelleDto.HizmetIsim);
			parameters.Add("@hizmetDurum", hizmetGuncelleDto.HizmetDurum);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
			}
		}

        public async void HizmetOlustur(BizKimizHizmetOlusturDto hizmetOlusturDto)
        {
			string query = "insert into BizKimizHizmet (HizmetIsim, HizmetDurum) values (@hizmetIsim, @hizmetDurum)";
			// Yeni kategori eklemek için SQL sorgusu
			var parameters = new DynamicParameters();
			// Parametreler eklenir
			parameters.Add("@hizmetIsim", hizmetOlusturDto.HizmetIsim);
			parameters.Add("@hizmetDurum",true);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
			}
		}

        public async void HizmetSil(int id)
        {
			string query = "Delete From BizKimizHizmet Where HizmetID= @hizmetID";
			// Belirli bir ID'ye sahip kategoriyi silen SQL sorgusu
			var parameters = new DynamicParameters();
			parameters.Add("@hizmetID", id); // Parametre eklenir
			using (var connections = _context.CreateConnection())
			{
				await connections.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
			}
		}
    }
    

    }

