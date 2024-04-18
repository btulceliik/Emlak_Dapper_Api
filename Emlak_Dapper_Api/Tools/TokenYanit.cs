namespace Emlak_Dapper_Api.Tools
{
    public class TokenYanit
    {
        public TokenYanit(string token, DateTime tokenOmru)
        {
            Token = token;
            TokenOmru = tokenOmru;
        }

        public string Token { get; set; }
        public DateTime TokenOmru { get; set; }


    }
}
