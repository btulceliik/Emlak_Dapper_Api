using Microsoft.Data.SqlClient; // SQL Server veritabanıyla iletişim kurmak için gerekli namespace
using System.Data; // ADO.NET'i kullanmak için gereken namespace

namespace Emlak_Dapper_Api.Models.DapperContext
{
    public class Context
    {
        private readonly IConfiguration _configuration; // IConfiguration türünde bir alan tanımlanır
        private readonly string _connectionString; // Bağlantı dizesini saklamak için bir alan tanımlanır

        // Yapıcı (Constructor) metod
        public Context(IConfiguration configuration)
        {
            _configuration = configuration; // Dependency Injection ile gelen IConfiguration nesnesi
                                            // _configuration alanına atanır
            _connectionString = _configuration.GetConnectionString("connection"); // Yapılandırma bilgilerinden "connection" adlı bağlantı dizesi alınır
        }

        // Bağlantı oluşturmak için genel (public) bir metot
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString); 
        // SqlConnection kullanılarak yeni bir bağlantı oluşturulur ve geri döndürülür
    }
}
