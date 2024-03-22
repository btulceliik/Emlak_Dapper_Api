
using Dapper;
using Emlak_Dapper_Api.Models.DapperContext;

namespace Emlak_Dapper_Api.Depo.IstatistikDeposu

{
    public class IstatistikDepo : IIstatistikDepo
    {
        private readonly Context _context;
        public IstatistikDepo(Context context)
        {
            _context = context;
        }

        public int AktifKategoriSayısı()
        {
            string query = "Select Count(*) From Kategori where KategoriDurum=1";
            using(var connection = _context.CreateConnection())
            {
                var values =  connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int AktifPersonelSayısı()
        {
            string query = "Select Count(*) From Personel where Durum=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int DaireSayısı()
        {
            string query = "Select Count(*) From Urun where Baslik like '%Daire%' ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string EnEskiBina()
        {
            string query = "Select Top(1) YapımYili From UrunDetay order by YapımYili Asc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string EnYeniBina()
        {
            string query = "Select Top(1) YapımYili From UrunDetay order by YapımYili Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int FarklıSehirSayısı()
        {
            string query = "Select  Count(Distinct (Sehir)) From Urun";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

            public int KategoriSayısı()
        {
            string query = "Select Count(*) From Kategori";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

            public string MaxKategoriIsimSayısı()
        {
            string query = "Select top (1) KategoriIsim, Count (*) From Urun inner join Kategori On Urun.UrunKategori=Kategori.KategoriID Group By KategoriIsim order by Count(*) Desc ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string MaxPersonelIsimSayısı()
        {
            string query = "Select PersonelIsim,Count(*) 'ilan_Sayısı' From Urun inner join Personel on Urun.PersonelID=Personel.PersonelID Group By PersonelIsim Order By ilan_Sayısı Desc ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

            public string MaxSehirSayısı()
        {
            string query = "Select top(1) Sehir, Count(*) AS  'ilan_Sayısı' From Urun Group By Sehir order by ilan_Sayısı Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public decimal OrtalamaKiralıkUrunFiyat()
        {
            string query = "Select Avg(Fiyat) From Urun where Tip='Kiralık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public int OrtalamaOdaSayısı()
        {
            string query = "Select Avg(OdaSayisi) From UrunDetay";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public decimal OrtalamaSatılıkUrunFiyat()
        {
            string query = "Select Avg(Fiyat) From Urun where Tip='Satılık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public int PasifKategoriSayısı()
        {
            string query = "Select  Count(*) From Kategori Where KategoriDurum=0";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }

        }

        public decimal SonEklenenUrun()
        {
            string query = "Select Top(1) Fiyat From Urun Order By UrunID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public int UrunSayısı()
        {
            string query = "Select Count(*) From Urun";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
    }
}
