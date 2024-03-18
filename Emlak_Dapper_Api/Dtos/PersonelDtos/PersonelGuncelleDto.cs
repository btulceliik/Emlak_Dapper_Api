namespace Emlak_Dapper_Api.Dtos.PersonelDtos
{
	public class PersonelGuncelleDto
	{
		public int PersonelID { get; set; }
		public string PersonelIsim { get; set; }
		public string Baslik { get; set; }
		public string Mail { get; set; }
		public string Telefon { get; set; }
		public string GorselUrl { get; set; }
		public bool Durum { get; set; }
	}
}
