﻿
namespace Emlak_Dapper_Api.Depo.IstatistikDeposu
{
    public interface IIstatistikDepo
    {
        int KategoriSayısı();
        int AktifKategoriSayısı();
        int PasifKategoriSayısı();
        int UrunSayısı();
        int DaireSayısı();
        string MaxPersonelIsimSayısı();
        string MaxKategoriIsimSayısı();
        decimal OrtalamaKiralıkUrunFiyat();
        decimal OrtalamaSatılıkUrunFiyat();
        string MaxSehirSayısı();
        int FarklıSehirSayısı();
        decimal SonEklenenUrun();
        string EnYeniBina();
        string EnEskiBina();
        int OrtalamaOdaSayısı();
        int AktifPersonelSayısı();

    }
}
