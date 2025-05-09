using System.Globalization;
using projeto_matriculas.DB;
using CsvHelper.Configuration;
using CsvHelper;

namespace projeto_matriculas.Controllers
{
    internal class MatriculadosController
    {
        private readonly MatriculadosRepository _repository;

        public MatriculadosController()
        {
            _repository = new MatriculadosRepository();
        }

        public void TodosMatriculadosPorModalidade(string modalidade)
        {
            TotaisAnuais totais;

            if (string.Equals(modalidade, "Qualquer", StringComparison.OrdinalIgnoreCase))
            {
                totais = _repository.ObterTotaisAnuais();
            }
            else
            {
                totais = _repository.ObterTotaisAnuaisPorModalidade(modalidade);
            }

            Program.MainForm.mostrarTotaisEmTabela(totais);
        }

        public void TodosMatriculadosPorEstado(string estado)
        {
            TotaisAnuais totais;
            totais = _repository.ObterTotaisPorEstado(estado);
            Program.MainForm.mostrarTotaisEmTabela(totais);
        }
        public void RankingUniversidades(string modalidade)
        {
            List<CursoTotal> cursos;

            if (string.Equals(modalidade, "Qualquer", StringComparison.OrdinalIgnoreCase))
            {
                cursos = _repository.ObterTopCursos2022();
            }
            else
            {
                cursos = _repository.ObterTopCursos2022PorModalidade(modalidade);
            }

            Program.MainForm.mostrarRankingEmTabela(cursos);
        }
        private class MatriculadosMap : ClassMap<Matriculados>
        {
            public MatriculadosMap()
            {
                Map(m => m.Estado).Name("Estado");
                Map(m => m.Cidade).Name("Cidade");
                Map(m => m.IES).Name("IES");
                Map(m => m.Sigla).Name("Sigla");
                Map(m => m.Organizacao).Name("Organização");
                Map(m => m.CategoriaAdministrativa).Name("Categoria Administrativa");
                Map(m => m.NomeCurso).Name("Nome do Curso");
                Map(m => m.NomeDetalhadoCurso).Name("Nome Detalhado do Curso");
                Map(m => m.Modalidade).Name("Modalidade");
                Map(m => m.Grau).Name("Grau");
                Map(m => m.Matriculas2014).Name("2014").Optional();
                Map(m => m.Matriculas2015).Name("2015").Optional();
                Map(m => m.Matriculas2016).Name("2016").Optional();
                Map(m => m.Matriculas2017).Name("2017").Optional();
                Map(m => m.Matriculas2018).Name("2018").Optional();
                Map(m => m.Matriculas2019).Name("2019").Optional();
                Map(m => m.Matriculas2020).Name("2020").Optional();
                Map(m => m.Matriculas2021).Name("2021").Optional();
                Map(m => m.Matriculas2022).Name("2022").Optional();
            }
        }

        public void ImportarArquivoCSV(string caminhoCsv)
        {
            if (!File.Exists(caminhoCsv))
            {
                //mostrar na view nao existe
            }

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";",
                TrimOptions = TrimOptions.Trim,
                MissingFieldFound = null
            };

            using var reader = new StreamReader(caminhoCsv);
            using var csv = new CsvReader(reader, config);
            csv.Context.RegisterClassMap<MatriculadosMap>();

            foreach (var item in csv.GetRecords<Matriculados>())
            {
                _repository.Adicionar(item);
                //atualizar view a cada n registros
            }
        }
    }
}
