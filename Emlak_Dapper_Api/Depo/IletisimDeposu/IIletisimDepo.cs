using Emlak_Dapper_Api.Dtos.IletisimDtos;

namespace Emlak_Dapper_Api.Depo.IletisimDeposu
{
    public interface IIletisimDepo
    {
        Task<List<IletisimSonucDto>> GetAllIletisimAsync();
        Task<List<Son4IletisimDto>> Son4Iletisim();

        void IletisimOlustur(IletisimOlusturDto iletisimOlusturDto);

        void IletisimSil(int id);
        Task<IletisimIDGetirDto> IletisimGetir(int id);
    }
}
