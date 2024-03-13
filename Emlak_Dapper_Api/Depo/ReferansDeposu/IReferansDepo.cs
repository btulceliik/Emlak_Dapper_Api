using Emlak_Dapper_Api.Dtos.ReferansDtos;

namespace Emlak_Dapper_Api.Depo.ReferansDeposu
{
    public interface IReferansDepo
    {
        Task<List<ReferansSonucDto>> GetAllReferansAsync();

    }

}

