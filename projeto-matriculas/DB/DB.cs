using Npgsql;

namespace projeto_matriculas
{
    public static class Db
    {
        public static void CriarTabelas()
        {
            using (var conn = Conexao.ObterConexao())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Matriculados (
                        Id SERIAL PRIMARY KEY,
                        Estado VARCHAR(50) NOT NULL,
                        Cidade VARCHAR(100) NOT NULL,
                        IES VARCHAR(255) NOT NULL,
                        Sigla VARCHAR(50),
                        Organizacao VARCHAR(100),
                        CategoriaAdministrativa VARCHAR(50),
                        NomeCurso VARCHAR(255) NOT NULL,
                        NomeDetalhadoCurso VARCHAR(255),
                        Modalidade VARCHAR(50) NOT NULL,
                        Grau VARCHAR(50) NOT NULL,
                        Matriculas2014 INT,
                        Matriculas2015 INT,
                        Matriculas2016 INT,
                        Matriculas2017 INT,
                        Matriculas2018 INT,
                        Matriculas2019 INT,
                        Matriculas2020 INT,
                        Matriculas2021 INT,
                        Matriculas2022 INT
                    );";
                cmd.ExecuteNonQuery();
            }
        }
    }
}