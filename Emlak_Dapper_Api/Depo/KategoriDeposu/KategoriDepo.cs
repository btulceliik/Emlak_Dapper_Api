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

    }
}
