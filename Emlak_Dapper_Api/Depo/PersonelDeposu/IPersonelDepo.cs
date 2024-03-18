using Emlak_Dapper_Api.Dtos.PersonelDtos;

namespace Emlak_Dapper_Api.Depo.PersonelDeposu
{
	public interface IPersonelDepo
	{
		Task<List<PersonelSonucDto>> GetAllPersonelAsync();

		void PersonelOlustur(PersonelOlusturDto personellDto);

		void PersonelSil(int id);
		void PersonelGuncelle(PersonelGuncelleDto personellDto);
		Task<PersonelIDGetirDto> PersonelGetir(int id);







	}
}
