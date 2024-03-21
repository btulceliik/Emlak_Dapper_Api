
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
            throw new NotImplementedException();
        }

        public string EnEskiBina()
        {
            throw new NotImplementedException();
        }

        public string EnYeniBina()
        {
            throw new NotImplementedException();
        }

        public int FarklıSehirSayısı()
        {
            throw new NotImplementedException();
        }

        public int KategoriSayısı()
        {
            throw new NotImplementedException();
        }

        public string MaxKategoriIsimSayısı()
        {
            throw new NotImplementedException();
        }

        public string MaxPersonelIsimSayısı()
        {
            throw new NotImplementedException();
        }

        public string MaxSehirSayısı()
        {
            throw new NotImplementedException();
        }

        public decimal OrtalamaKiralıkUrun()
        {
            throw new NotImplementedException();
        }

        public int OrtalamaOdaSayısı()
        {
            throw new NotImplementedException();
        }

        public decimal OrtalamaSatılıkUrun()
        {
            throw new NotImplementedException();
        }

        public int PasifKategoriSayısı()
        {
            throw new NotImplementedException();
        }

        public decimal SonEklenenUrun()
        {
            throw new NotImplementedException();
        }

        public int UrunSayısı()
        {
            throw new NotImplementedException();
        }
    }
}
