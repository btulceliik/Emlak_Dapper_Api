using Dapper;
using Emlak_Dapper_Api.Dtos.AnaSayfaHizmetDtos;
using Emlak_Dapper_Api.Models.DapperContext;

namespace Emlak_Dapper_Api.Depo.AnaSayfaHizmetDeposu
{
    public class AnaSayfaHizmetDepo : IAnaSayfaHizmetDepo
    {
        private readonly Context _context;
        public AnaSayfaHizmetDepo(Context context)
        {
            _context = context;
        }

        //  Hizmet tablomdaki verileri çekmek için sorgum
        public async Task<List<AnaSayfaHizmetSonucDto>> GetAllAnaSayfaHizmetAsync()
        {
            string query = "Select * From Hizmet";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<AnaSayfaHizmetSonucDto>(query);
                return values.ToList();
            }
        }

        public async  void AnaSayfaHizmetGuncelle(AnaSayfaHizmetGuncelleDto hizmetGuncelleDto)
        {
            string query = " Update Hizmet Set Icon=@icon, Baslik=@baslik, Aciklama=@aciklama Where HizmetID= @hizmetID";
            // Belirli bir ID'ye sahip kategoriyi güncelleyen SQL sorgusu
            var parameters = new DynamicParameters();
            parameters.Add("@hizmetID", hizmetGuncelleDto.HizmetID);
            parameters.Add("@icon", hizmetGuncelleDto.Icon);
            parameters.Add("@baslik", hizmetGuncelleDto.Baslik);
            parameters.Add("@aciklama", hizmetGuncelleDto.Aciklama);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
            }
        }

        public async  void AnaSayfaHizmetOlustur(AnaSayfaHizmetOlusturDto hizmetOlusturDto)
        {
            string query = "insert into Hizmet (Icon,Baslik, Aciklama) values (@icon, @baslik,  @aciklama)";
            // Yeni kategori eklemek için SQL sorgusu
            var parameters = new DynamicParameters();
            // Parametreler eklenir
            parameters.Add("@icon", hizmetOlusturDto.Icon);
            parameters.Add("@baslik", hizmetOlusturDto.Baslik);
            parameters.Add("@aciklama", hizmetOlusturDto.Aciklama);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
            }
        }

        public async void AnaSayfaHizmetSil(int id)
        {
            string query = "Delete From Hizmet Where HizmetID= @hizmetID";
            // Belirli bir ID'ye sahip kategoriyi silen SQL sorgusu
            var parameters = new DynamicParameters();
            parameters.Add("@hizmetID", id); // Parametre eklenir
            using (var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
            }
        }

        public async Task<AnaSayfaHizmetGetirDto> AnaSayfaHizmetGetir(int id)
        {
            string query = "Select * From Hizmet Where HizmetID=@hizmetID";
            // Belirli bir ID'ye sahip kategoriyi getiren SQL sorgusu
            var parameters = new DynamicParameters();
            parameters.Add("@hizmetID", id);
            // Parametre eklenir
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<AnaSayfaHizmetGetirDto>(query, parameters);
                // Sorgu sonucunda dönen veriler alınır
                return values;
                // Veri geri döndürülür
            }
        }
    }
}
