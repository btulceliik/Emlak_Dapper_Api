using Emlak_Dapper_Api.Dtos.KategoriDtos;

namespace Emlak_Dapper_Api.Depo.KategoriDeposu
{
    public interface IKategoriDepo
    {
        Task<List<KategoriSonucDto>> GetAllKategoriAsync();
        
    }
}