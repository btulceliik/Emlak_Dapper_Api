using Dapper;
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
	}
}
