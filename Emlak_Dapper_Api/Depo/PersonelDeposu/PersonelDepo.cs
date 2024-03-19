using Dapper;
using Emlak_Dapper_Api.Dtos.PersonelDtos;
using Emlak_Dapper_Api.Models.DapperContext;

namespace Emlak_Dapper_Api.Depo.PersonelDeposu
{
	public class PersonelDepo : IPersonelDepo
	{
		private readonly Context _context; // Veritabanı bağlamını depoda kullanmak için bir alan tanımlanır
		public PersonelDepo(Context context)
		{
			_context = context; // Dependency Injection ile gelen veritabanı bağlamı atanır
		}

		public async Task<List<PersonelSonucDto>> GetAllPersonelAsync()
		{
			string query = "Select * From Personel"; // Tüm kategorileri getiren SQL sorgusu
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<PersonelSonucDto>(query);
				// Sorgu sonucunda dönen veriler alınır
				return values.ToList(); // Veriler List<KategoriSonucDto> olarak dönüştürülür ve geri döndürülür
			}
		}

		public async void PersonelOlustur(PersonelOlusturDto personelOlusturDto)
		{
			// Yeni kategori eklemek için SQL sorgusu
			string query = "insert into Personel (PersonelIsim, Baslik, Mail, Telefon, GorselUrl, Durum) " +
				"values (@isim, @baslik,@mail, @telefon, @gorselUrl, @durum)";

			var parameters = new DynamicParameters();
			parameters.Add("@isim", personelOlusturDto.PersonelIsim);
			parameters.Add("@baslik", personelOlusturDto.Baslik);
			parameters.Add("@mail", personelOlusturDto.Mail);
			parameters.Add("@telefon", personelOlusturDto.Telefon);
			parameters.Add("@gorselUrl", personelOlusturDto.GorselUrl);
			parameters.Add("@durum", true);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
			}
		}

		public async void PersonelGuncelle(PersonelGuncelleDto personelGuncelleDto)
		{
			string query = "update Personel set PersonelIsim=@isim, Baslik=@baslik, Mail=@mail, Telefon=@telefon, GorselUrl=@gorselUrl, Durum=@durum where PersonelID=@personelID";

			var parameters = new DynamicParameters();
			parameters.Add("@isim", personelGuncelleDto.PersonelIsim);
			parameters.Add("@baslik", personelGuncelleDto.Baslik);
			parameters.Add("@mail", personelGuncelleDto.Mail);
			parameters.Add("@telefon", personelGuncelleDto.Telefon);
			parameters.Add("@gorselUrl", personelGuncelleDto.GorselUrl);
			parameters.Add("@durum", personelGuncelleDto.Durum);
			parameters.Add("@personelID", personelGuncelleDto.PersonelID);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
			}
		}

		public async void  PersonelSil(int id)
		{
			string query = "Delete From Personel Where PersonelID= @personelID";
			// Belirli bir ID'ye sahip kategoriyi silen SQL sorgusu
			var parameters = new DynamicParameters();
			parameters.Add("@personelID", id); // Parametre eklenir
			using (var connections = _context.CreateConnection())
			{
				await connections.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
			}
		}
		public async Task<PersonelIDGetirDto> PersonelGetir(int id)
		{
			string query = "Select * From Personel Where PersonelID=@personelID";
			// Belirli bir ID'ye sahip kategoriyi getiren SQL sorgusu
			var parameters = new DynamicParameters();
			parameters.Add("@personelID", id);
			// Parametre eklenir
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<PersonelIDGetirDto>(query, parameters);
				// Sorgu sonucunda dönen veriler alınır
				return values;
				// Veri geri döndürülür
			}
		}
	}
}
