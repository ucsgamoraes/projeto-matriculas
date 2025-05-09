using System.Collections.Generic;
using Npgsql;
using projeto_matriculas.Models;

namespace projeto_matriculas
{
    public class MatriculadosDAO
    {
        public void Inserir(Matriculado matriculado)
        {
            using var conn = ConexaoDB.ObterConexao();
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
            cmd.Parameters.AddWithValue("@Sigla", (object)matriculado.Sigla ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@Organizacao", (object)matriculado.Organizacao ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@CategoriaAdministrativa", (object)matriculado.CategoriaAdministrativa ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@NomeCurso", matriculado.NomeCurso);
            cmd.Parameters.AddWithValue("@NomeDetalhadoCurso", (object)matriculado.NomeDetalhadoCurso ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@Modalidade", matriculado.Modalidade);
            cmd.Parameters.AddWithValue("@Grau", matriculado.Grau);
            cmd.Parameters.AddWithValue("@M2014", (object)matriculado.Matriculas2014 ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@M2015", (object)matriculado.Matriculas2015 ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@M2016", (object)matriculado.Matriculas2016 ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@M2017", (object)matriculado.Matriculas2017 ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@M2018", (object)matriculado.Matriculas2018 ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@M2019", (object)matriculado.Matriculas2019 ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@M2020", (object)matriculado.Matriculas2020 ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@M2021", (object)matriculado.Matriculas2021 ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@M2022", (object)matriculado.Matriculas2022 ?? System.DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public List<Matriculado> Consultar(FiltrosConsulta filtros)
        {
            using var conn = ConexaoDB.ObterConexao();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT * FROM Matriculados WHERE 1 = 1";

            if (filtros.AnoIni.HasValue)
            {
                cmd.CommandText = "AND Ano >= @AnoIni";
                cmd.Parameters.AddWithValue("@AnoIni", filtros.AnoIni.Value);
            }
            if (filtros.AnoFim.HasValue)
            {
                cmd.CommandText = "AND Ano <= @AnoFim";
                cmd.Parameters.AddWithValue("@AnoFim", filtros.AnoFim.Value);
            }
            if (!filtros.IsEAD)
            {
                cmd.CommandText = "AND Modalidade = 'Presencial'";

            }
            if (!filtros.IsPresencial)
            {
                cmd.CommandText = "AND Modalidade = 'EAD'";
            }
            //REVER
            //if (filtros.TipoConsulta == Enums.TipoConsulta.Ranking)
            //{
            //    cmd.CommandText = "ORDER BY Matriculas2014 DESC";
            //}

            List<Matriculado> matriculados = new List<Matriculado>();

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                matriculados.Add(new Matriculado()
                {
                    Id = reader.GetInt32(0),
                    Estado = reader.GetString(1),
                    Cidade = reader.GetString(2),
                    IES = reader.GetString(3),
                    Sigla = reader.GetString(4),
                    Organizacao = reader.GetString(5),
                    CategoriaAdministrativa = reader.GetString(6),
                    NomeCurso = reader.GetString(7),
                    NomeDetalhadoCurso = reader.GetString(8),
                    Modalidade = reader.GetString(9),
                    Grau = reader.GetString(10),
                    Matriculas2014 = reader.GetInt32(11),
                    Matriculas2015 = reader.GetInt32(12),
                    Matriculas2016 = reader.GetInt32(13),
                    Matriculas2017 = reader.GetInt32(14),
                    Matriculas2018 = reader.GetInt32(15),
                    Matriculas2019 = reader.GetInt32(16),
                    Matriculas2020 = reader.GetInt32(17),
                    Matriculas2021 = reader.GetInt32(18),
                    Matriculas2022 = reader.GetInt32(19),
                });
            }

            return matriculados;
        }
    }
}