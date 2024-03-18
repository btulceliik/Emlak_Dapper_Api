using Emlak_Dapper_Api.Dtos.PersonelDtos;

namespace Emlak_Dapper_Api.Depo.PersonelDeposu
{
	public class PersonelDepo : IPersonelDepo

	{
		public Task<List<PersonelSonucDto>> GetAllPersonelAsync()
		{
			throw new NotImplementedException();
		}

		public Task<PersonelIDGetirDto> PersonelGetir(int id)
		{
			throw new NotImplementedException();
		}

		public void PersonelGuncelle(PersonelGuncelleDto personellDto)
		{
			throw new NotImplementedException();
		}

		public void PersonelOlustur(PersonelOlusturDto personellDto)
		{
			throw new NotImplementedException();
		}

		public void PersonelSil(int id)
		{
			throw new NotImplementedException();
		}
	}
}
