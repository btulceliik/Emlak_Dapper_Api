using Dapper;
using Emlak_Dapper_Api.Dtos.ReferansDtos;
using Emlak_Dapper_Api.Models.DapperContext;

namespace Emlak_Dapper_Api.Depo.ReferansDeposu
{
    public class ReferansDepo: IReferansDepo
    {
        private readonly Context _context;
        public ReferansDepo(Context context)
        {
            _context = context;

        }
        public async Task<List<ReferansSonucDto>> GetAllReferansAsync()
        {
            string query = "Select * From Referans";
            using (var connection = _context.CreateConnection())
            {
                var values= await connection.QueryAsync<ReferansSonucDto>(query);
                return values.ToList();
            }
        }
    }
}
