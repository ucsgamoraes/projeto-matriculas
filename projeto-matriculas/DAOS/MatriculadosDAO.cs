using System.Collections.Generic;
using Npgsql;

namespace projeto_matriculas
{
    public class MatriculadosDAO
    {
        public void Inserir(Matriculado matriculado)
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
    }
}