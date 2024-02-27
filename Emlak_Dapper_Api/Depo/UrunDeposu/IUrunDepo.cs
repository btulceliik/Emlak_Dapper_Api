using Emlak_Dapper_Api.Dtos.UrunDtos;

namespace Emlak_Dapper_Api.Depo.UrunDeposu
{
    public interface IUrunDepo
    {
        Task<List<UrunSonucDto>> GetAllUrunAsync();
        Task<List<UrunSonucVeKategoriDto>> GetAllUrunVeKategoriAsync();
    
    }
}
