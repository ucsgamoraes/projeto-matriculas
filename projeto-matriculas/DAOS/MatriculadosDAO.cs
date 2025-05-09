using System;
using System.Collections.Generic;
using Npgsql;

namespace projeto_matriculas
{
    public class MatriculadosDAO
    {
        public void Inserir(Matriculados matriculado)
        {
            using var conn = Conexao.ObterConexao();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO Matriculados
                (Estado, Cidade, IES, Sigla, Organizacao, CategoriaAdministrativa,
                 NomeCurso, NomeDetalhadoCurso, Modalidade, Grau,
                 Matriculas2014, Matriculas2015, Matriculas2016, Matriculas2017,
                 Matriculas2018, Matriculas2019, Matriculas2020, Matriculas2021, Matriculas2022)
             VALUES
                (@Estado, @Cidade, @IES, @Sigla, @Organizacao, @CategoriaAdministrativa,
                 @NomeCurso, @NomeDetalhadoCurso, @Modalidade, @Grau,
                 @M2014, @M2015, @M2016, @M2017, @M2018, @M2019, @M2020, @M2021, @M2022);";
            cmd.Parameters.AddWithValue("@Estado", matriculado.Estado);
            cmd.Parameters.AddWithValue("@Cidade", matriculado.Cidade);
            cmd.Parameters.AddWithValue("@IES", matriculado.IES);
            cmd.Parameters.AddWithValue("@Sigla", (object)matriculado.Sigla ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Organizacao", (object)matriculado.Organizacao ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CategoriaAdministrativa", (object)matriculado.CategoriaAdministrativa ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@NomeCurso", matriculado.NomeCurso);
            cmd.Parameters.AddWithValue("@NomeDetalhadoCurso", (object)matriculado.NomeDetalhadoCurso ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Modalidade", matriculado.Modalidade);
            cmd.Parameters.AddWithValue("@Grau", matriculado.Grau);
            cmd.Parameters.AddWithValue("@M2014", (object)matriculado.Matriculas2014 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@M2015", (object)matriculado.Matriculas2015 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@M2016", (object)matriculado.Matriculas2016 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@M2017", (object)matriculado.Matriculas2017 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@M2018", (object)matriculado.Matriculas2018 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@M2019", (object)matriculado.Matriculas2019 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@M2020", (object)matriculado.Matriculas2020 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@M2021", (object)matriculado.Matriculas2021 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@M2022", (object)matriculado.Matriculas2022 ?? DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        //Total de alunos matriculados (no Brasil) por ano
        public TotaisAnuais ObterTotaisAnuais()
        {
            const string sql = @"
                SELECT
                  SUM(matriculas2014), SUM(matriculas2015), SUM(matriculas2016),
                  SUM(matriculas2017), SUM(matriculas2018), SUM(matriculas2019),
                  SUM(matriculas2020), SUM(matriculas2021), SUM(matriculas2022)
                FROM matriculados;";

            using var conn = Conexao.ObterConexao();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new TotaisAnuais
                {
                    Ano2014 = reader.IsDBNull(0) ? 0 : reader.GetInt64(0),
                    Ano2015 = reader.IsDBNull(1) ? 0 : reader.GetInt64(1),
                    Ano2016 = reader.IsDBNull(2) ? 0 : reader.GetInt64(2),
                    Ano2017 = reader.IsDBNull(3) ? 0 : reader.GetInt64(3),
                    Ano2018 = reader.IsDBNull(4) ? 0 : reader.GetInt64(4),
                    Ano2019 = reader.IsDBNull(5) ? 0 : reader.GetInt64(5),
                    Ano2020 = reader.IsDBNull(6) ? 0 : reader.GetInt64(6),
                    Ano2021 = reader.IsDBNull(7) ? 0 : reader.GetInt64(7),
                    Ano2022 = reader.IsDBNull(8) ? 0 : reader.GetInt64(8)
                };
            }
            return null;
        }

        //Total de alunos matriculados (no Brasil) por ano, com a possibilidade de escolher a modalidade (EaD ou Presencial)
        public TotaisAnuais ObterTotaisAnuaisPorModalidade(string modalidade)
        {
            const string sql = @"
                SELECT
                  SUM(matriculas2014), SUM(matriculas2015), SUM(matriculas2016),
                  SUM(matriculas2017), SUM(matriculas2018), SUM(matriculas2019),
                  SUM(matriculas2020), SUM(matriculas2021), SUM(matriculas2022)
                FROM matriculados
                WHERE modalidade = @Modalidade;";

            using var conn = Conexao.ObterConexao();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Modalidade", modalidade);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new TotaisAnuais
                {
                    Ano2014 = reader.IsDBNull(0) ? 0 : reader.GetInt64(0),
                    Ano2015 = reader.IsDBNull(1) ? 0 : reader.GetInt64(1),
                    Ano2016 = reader.IsDBNull(2) ? 0 : reader.GetInt64(2),
                    Ano2017 = reader.IsDBNull(3) ? 0 : reader.GetInt64(3),
                    Ano2018 = reader.IsDBNull(4) ? 0 : reader.GetInt64(4),
                    Ano2019 = reader.IsDBNull(5) ? 0 : reader.GetInt64(5),
                    Ano2020 = reader.IsDBNull(6) ? 0 : reader.GetInt64(6),
                    Ano2021 = reader.IsDBNull(7) ? 0 : reader.GetInt64(7),
                    Ano2022 = reader.IsDBNull(8) ? 0 : reader.GetInt64(8)
                };
            }
            return null;
        }

        //Ranking de cursos em 2022 (10 cursos com maior número de matrículas no Brasil)
        public List<CursoTotal> ObterTopCursos2022(int topN = 10)
        {
            const string sql = @"
                SELECT nomecurso, SUM(matriculas2022) AS total_2022
                FROM matriculados
                GROUP BY nomecurso
                ORDER BY total_2022 DESC
                LIMIT @TopN;";

            var lista = new List<CursoTotal>();
            using var conn = Conexao.ObterConexao();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@TopN", topN);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new CursoTotal
                {
                    NomeCurso = reader.GetString(0),
                    Total2022 = reader.IsDBNull(1) ? 0 : reader.GetInt64(1)
                });
            }
            return lista;
        }

        //Ranking de cursos em 2022 (10 cursos com maior número de matrículas no Brasil), com a possibilidade de escolher a modalidade (EaD ou Presencial)
        public List<CursoTotal> ObterTopCursos2022PorModalidade(string modalidade, int topN = 10)
        {
            const string sql = @"
                SELECT nomecurso, SUM(matriculas2022) AS total_2022
                FROM matriculados
                WHERE modalidade = @Modalidade
                GROUP BY nomecurso
                ORDER BY total_2022 DESC
                LIMIT @TopN;";

            var lista = new List<CursoTotal>();
            using var conn = Conexao.ObterConexao();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Modalidade", modalidade);
            cmd.Parameters.AddWithValue("@TopN", topN);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new CursoTotal
                {
                    NomeCurso = reader.GetString(0),
                    Total2022 = reader.IsDBNull(1) ? 0 : reader.GetInt64(1)
                });
            }
            return lista;
        }

        public TotaisPorEstado ObterTotaisPorEstado(string estado)
        {
            const string sql = @"
                SELECT
                  SUM(matriculas2014), SUM(matriculas2015), SUM(matriculas2016),
                  SUM(matriculas2017), SUM(matriculas2018), SUM(matriculas2019),
                  SUM(matriculas2020), SUM(matriculas2021), SUM(matriculas2022)
                FROM matriculados
                WHERE estado = @Estado;";

            using var conn = Conexao.ObterConexao();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Estado", estado);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new TotaisPorEstado
                {
                    Estado = estado,
                    Ano2014 = reader.IsDBNull(0) ? 0 : reader.GetInt64(0),
                    Ano2015 = reader.IsDBNull(1) ? 0 : reader.GetInt64(1),
                    Ano2016 = reader.IsDBNull(2) ? 0 : reader.GetInt64(2),
                    Ano2017 = reader.IsDBNull(3) ? 0 : reader.GetInt64(3),
                    Ano2018 = reader.IsDBNull(4) ? 0 : reader.GetInt64(4),
                    Ano2019 = reader.IsDBNull(5) ? 0 : reader.GetInt64(5),
                    Ano2020 = reader.IsDBNull(6) ? 0 : reader.GetInt64(6),
                    Ano2021 = reader.IsDBNull(7) ? 0 : reader.GetInt64(7),
                    Ano2022 = reader.IsDBNull(8) ? 0 : reader.GetInt64(8)
                };
            }
            return null;
        }
    }

    // DTOs para retorno das consultas
    public class TotaisAnuais
    {
        public long Ano2014 { get; set; }
        public long Ano2015 { get; set; }
        public long Ano2016 { get; set; }
        public long Ano2017 { get; set; }
        public long Ano2018 { get; set; }
        public long Ano2019 { get; set; }
        public long Ano2020 { get; set; }
        public long Ano2021 { get; set; }
        public long Ano2022 { get; set; }
    }
    public class TotaisPorEstado : TotaisAnuais
    {
        public string Estado { get; set; }
    }

    public class CursoTotal
    {
        public string NomeCurso { get; set; }
        public long Total2022 { get; set; }
    }


}
