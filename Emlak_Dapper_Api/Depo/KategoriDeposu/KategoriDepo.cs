using Emlak_Dapper_Api.Dtos.KategoriDtos;
using Emlak_Dapper_Api.Models.DapperContext;
using Dapper;


namespace Emlak_Dapper_Api.Depo.KategoriDeposu
{
    public class KategoriDepo : IKategoriDepo
    {
        private readonly Context _context;
        public KategoriDepo(Context context)
        {
            _context = context;
        }

        public async Task<List<KategoriSonucDto>> GetAllKategoriAsync()
        {
            string query = "Select * From Kategori";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<KategoriSonucDto>(query);
                return values.ToList();
            }
        }



        //OlusturKategori metotu implemente edildi 
        //Kategori ekleme ilşlemim
        public async void KategoriOlustur(KategoriOlusturDto kategoriDto)
        {
            string query = "insert into Kategori (KategoriIsim, KategoriDurum) values (@kategoriIsim,@kategoriDurum)";
            var parameters = new DynamicParameters();
            parameters.Add("@kategoriIsim", kategoriDto.KategoriIsim);
            parameters.Add("@kategoriDurum", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);


            }
        }
        //OlusturKategori metotu implemente edildi 
        //Kategori ekleme ilşlemim
        public async void KategoriSil(int id)
        {
            string query = "Delete From Kategori Where KategoriID= @kategoriID";
            var parameters = new DynamicParameters();
            parameters.Add("@kategoriID", id);
            using (var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parameters);
            }


        }

        public async void KategoriGuncelle(KategoriGuncelleDto kategoriDto)
        {
            string query = " Update Kategori Set KategoriIsim=@kategoriIsim, KategoriDurum= @kategoriDurum Where KategoriID= @kategoriID";
            var parameters = new DynamicParameters();

            parameters.Add("@kategoriIsim", kategoriDto.KategoriIsim);
            parameters.Add("@kategoriDurum", kategoriDto.KategoriDurum);
            parameters.Add("@kategoriID", kategoriDto.KategoriID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }
        public async Task<KategoriIDGetirDto> KategoriGetir(int id)
        {
            string query = "Select * From Kategori Where KategoriID=@KategoriID";
            var parameters = new DynamicParameters();
            parameters.Add("@KategoriID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<KategoriIDGetirDto>(query, parameters);
                return values;
            }
        }
    }
}
        

