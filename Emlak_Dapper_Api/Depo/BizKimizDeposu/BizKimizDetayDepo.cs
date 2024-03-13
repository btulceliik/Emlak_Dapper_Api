using Dapper;
using Emlak_Dapper_Api.Dtos.BizKimizDetayDtos;
using Emlak_Dapper_Api.Models.DapperContext;

namespace Emlak_Dapper_Api.Depo.BizKimizDeposu
{
    public class BizKimizDetayDepo : IBizKimizDetayDepo

    {
        private readonly Context _context;
        public  BizKimizDetayDepo (Context context)
        {
            _context = context;
        }
        
        public async Task<BizKimizDetayIDGetirDto> BizKimizDetayGetir(int id)
        {
            string query = "Select * From BizKimizDetay Where BizKimizDetayID=@bizKimizDetayID";
            // Belirli bir ID'ye sahip kategoriyi getiren SQL sorgusu
            var parameters = new DynamicParameters();
            parameters.Add("@bizKimizDetayID", id);
            // Parametre eklenir
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<BizKimizDetayIDGetirDto>(query, parameters);
                // Sorgu sonucunda dönen veriler alınır
                return values;
                // Veri geri döndürülür
            }
        }

        public async void BizKimizDetayGuncelle(BizKimizDetayGuncelleDto bizKimizDetayGuncelleDto)
        {
            string query = " Update BizKimizDetay Set Baslik=@baslik, AltBaslik= @altBaslik," +
                " Aciklama1=@aciklama1, Aciklama2=@aciklama2 Where BizKimizDetayID= @bizKimizDetayID";
            // Belirli bir ID'ye sahip kategoriyi güncelleyen SQL sorgusu
            var parameters = new DynamicParameters();
            parameters.Add("@bizKimizDetayID", bizKimizDetayGuncelleDto.BizKimizDetayID);
            parameters.Add("@baslik", bizKimizDetayGuncelleDto.Baslik);
            parameters.Add("@altBaslik", bizKimizDetayGuncelleDto.AltBaslik);
            parameters.Add("@aciklama1", bizKimizDetayGuncelleDto.Aciklama1);
            parameters.Add("@aciklama2", bizKimizDetayGuncelleDto.Aciklama2);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
            }
        }


        public async void BizKimizDetayOlustur(BizKimizDetayOlusturDto bizKimizDetayOlusturDto)
        {
        
            string query = "insert into BizKimizDetay (Baslik, AltBaslik, Aciklama1, Aciklama2) values (@baslik, @altBaslik, @aciklama1, @aciklama2)";
                // Yeni kategori eklemek için SQL sorgusu
                var parameters = new DynamicParameters();
                // Parametreler eklenir
                parameters.Add("@baslik", bizKimizDetayOlusturDto.Baslik);
                parameters.Add("@altBaslik", bizKimizDetayOlusturDto.AltBaslik);
                parameters.Add("@aciklama1", bizKimizDetayOlusturDto.Aciklama1);
                parameters.Add("@aciklama2", bizKimizDetayOlusturDto.Aciklama2);
                
               
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
                }
            }
        
        public async void BizKimizDetaySil(int id)
        {
            string query = "Delete From BizKimizDetay Where BizKimizDetayID= @bizKimizDetayID";
            // Belirli bir ID'ye sahip kategoriyi silen SQL sorgusu
            var parameters = new DynamicParameters();
            parameters.Add("@bizKimizDetayID", id); // Parametre eklenir
            using (var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parameters); // Sorgu çalıştırılır
            }
        }

        public async Task<List<BizKimizDetaySonucDto>> GetAllBizKimizDetayAsync()
        {
            string query = "Select * From BizKimizDetay"; // Tüm kategorileri getiren SQL sorgusu
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<BizKimizDetaySonucDto>(query);
                // Sorgu sonucunda dönen veriler alınır
                return values.ToList(); // Veriler List<KategoriSonucDto> olarak dönüştürülür ve geri döndürülür
            }
        }
    }
}