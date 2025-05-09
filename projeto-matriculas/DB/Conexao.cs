using System.Configuration;
using Npgsql;

namespace projeto_matriculas
{
    public static class Conexao
    {
        public static NpgsqlConnection ObterConexao()
        {
            var connString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ConnectionString;
            var conexao = new NpgsqlConnection(connString);
            conexao.Open();
            return conexao;
        }
    }
}