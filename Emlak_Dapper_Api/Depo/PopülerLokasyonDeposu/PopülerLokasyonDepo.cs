using Dapper;
using Emlak_Dapper_Api.Dtos.PersonelDtos;
using Emlak_Dapper_Api.Dtos.PopülerLokasyonDtos;
using Emlak_Dapper_Api.Models.DapperContext;

namespace Emlak_Dapper_Api.Depo.PopülerLokasyonDeposu
{
	public class PopülerLokasyonDepo : IPopülerLokasyonDepo
	{
		private readonly Context _context;

		public PopülerLokasyonDepo(Context context)
		{
			this._context = context;
		}

		public async Task<List<PopülerLokasyonSonucDto>> GetAllPopülerLokasyonAsync()
		{
			string query = "Select * From PopulerLokasyon";
			using (var connection = _context.CreateConnection())
			
			{
				var values = await connection.QueryAsync<PopülerLokasyonSonucDto>(query);
				return values.ToList();
			}
		}

		public async Task<PopülerLokasyonIDGetirDto> PopülerLokasyonGetir(int id)
		{
			string query = "Select * From PopulerLokasyon Where LokasyonID=@lokasyonID";
			// Belirli bir ID'ye sahip kategoriyi getiren SQL sorgusu
			var parameters = new DynamicParameters();
			parameters.Add("@lokasyonID", id);
			// Parametre eklenir
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<PopülerLokasyonIDGetirDto>(query, parameters);
				// Sorgu sonucunda dönen veriler alınır
				return values;
				// Veri geri döndürülür
			}
		}

		public async void PopülerLokasyonGuncelle(PopülerLokasyonGuncelleDto popülerLokasyonGuncelleDto)
		{
			string query = "update PopulerLokasyon set SehirIsim=@sehirIsim, GorselUrl=@gorselUrl  where LokasyonID=@lokasyonID";

			var parameters = new DynamicParameters();
			parameters.Add("@lokasyonID", popülerLokasyonGuncelleDto.LokasyonID);
			parameters.Add("@sehirIsim", popülerLokasyonGuncelleDto.SehirIsim);
			parameters.Add("@gorselUrl", popülerLokasyonGuncelleDto.GorselUrl);
			

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
			}
		}

		public async void PopülerLokasyonOlustur(PopülerLokasyonOlusturDto popülerLokasyonOlusturDto)
		{
			string query = "insert into PopulerLokasyon (SehirIsim, GorselUrl) " +
				"values (@sehirIsim, @gorselUrl)";

			var parameters = new DynamicParameters();
			parameters.Add("@sehirIsim", popülerLokasyonOlusturDto.SehirIsim);
			parameters.Add("@gorselUrl", popülerLokasyonOlusturDto.GorselUrl);
	
		
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
			};
		}

		public async void PopülerLokasyonSil(int id)
		{
			string query = "Delete From PopulerLokasyon Where LokasyonID= @lokasyonID";
			// Belirli bir ID'ye sahip kategoriyi silen SQL sorgusu
			var parameters = new DynamicParameters();
			parameters.Add("@lokasyonID", id); // Parametre eklenir
			using (var connections = _context.CreateConnection())
			{
				await connections.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
			}
		}
	}
}
