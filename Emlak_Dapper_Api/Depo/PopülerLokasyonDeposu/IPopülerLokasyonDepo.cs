using Emlak_Dapper_Api.Dtos.PopülerLokasyonDtos;

namespace Emlak_Dapper_Api.Depo.PopülerLokasyonDeposu
{
	public interface IPopülerLokasyonDepo
	{ 
		Task<List<PopülerLokasyonSonucDto>> GetAllPopülerLokasyonAsync();

	}
}
