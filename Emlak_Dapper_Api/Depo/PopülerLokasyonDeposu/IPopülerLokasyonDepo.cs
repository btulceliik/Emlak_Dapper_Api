using Emlak_Dapper_Api.Dtos.PopülerLokasyonDtos;

namespace Emlak_Dapper_Api.Depo.PopülerLokasyonDeposu
{
	public interface IPopülerLokasyonDepo
	{ 
		Task<List<PopülerLokasyonSonucDto>> GetAllPopülerLokasyonAsync();

		void PopülerLokasyonOlustur(PopülerLokasyonOlusturDto popülerLokasyonOlusturDto);

		void PopülerLokasyonSil(int id);
		void PopülerLokasyonGuncelle(PopülerLokasyonGuncelleDto popülerLokasyonGuncelleDto);
		Task<PopülerLokasyonIDGetirDto> PopülerLokasyonGetir(int id);

	}
}
