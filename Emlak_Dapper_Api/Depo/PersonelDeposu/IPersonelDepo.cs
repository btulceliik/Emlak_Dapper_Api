using Emlak_Dapper_Api.Dtos.PersonelDtos;

namespace Emlak_Dapper_Api.Depo.PersonelDeposu
{
	public interface IPersonelDepo
	{
		Task<List<PersonelSonucDto>> GetAllPersonelAsync();

		void PersonelOlustur(PersonelOlusturDto personelOlusturDto);

		void PersonelSil(int id);
		void PersonelGuncelle(PersonelGuncelleDto personelGuncelleDto);
		Task<PersonelIDGetirDto> PersonelGetir(int id);







	}
}
