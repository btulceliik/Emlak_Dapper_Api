
using Emlak_Dapper_Api.Dtos.KategoriDtos;



namespace Emlak_Dapper_Api.Depo.KategoriDeposu
{
    public interface IKategoriDepo
    {
        Task<List<KategoriSonucDto>> GetAllKategoriAsync();


        void KategoriOlustur(KategoriOlusturDto kategoriDto);

        void KategoriSil(int id);
        void KategoriGuncelle(KategoriGuncelleDto kategoriDto);
        Task<KategoriIDGetirDto> KategoriGetir(int id);


    }
}