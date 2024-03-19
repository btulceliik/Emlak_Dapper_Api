namespace Emlak_Dapper_UI.Dtos.PersonelDtos
{
	public class PersonelSonucDto
	{
		public int PersonelID { get; set; }
		public string PersonelIsim { get; set;}
		public string Baslik { get; set;}
		public string Mail { get; set; }
		public string Telefon { get; set; }
		public string GorselUrl { get; set; }
		public bool Durum { get; set; }
	}
}
