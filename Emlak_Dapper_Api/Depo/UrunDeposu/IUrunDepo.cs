using Emlak_Dapper_Api.Dtos.UrunDtos;

namespace Emlak_Dapper_Api.Depo.UrunDeposu
{
    public interface IUrunDepo
    {
        Task<List<UrunSonucDto>> GetAllUrunAsync();
        Task<List<UrunSonucVeKategoriDto>> GetAllUrunVeKategoriAsync();

        //İlanları Günün Fırsatı Yapmak için
        void UrunGununFirsati(int id);
        void UrunGununFirsatiDegil(int id);
        Task<List<Son5UrunVeKategoriSonucDto>> GetAllSon5UrunAsync();

        Task<List<KategorilerleIlanListPersonelDto>> GetAllKategorilerleIlanListPersonelAsync(int id );



    }
}

