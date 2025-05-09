using System;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace projeto_matriculas
{
    /// <summary>
    /// Serviço para importar registros de Matriculados de um arquivo CSV usando MatriculadosRepository.
    /// </summary>
    public class MatriculadosImport
    {
        private readonly MatriculadosRepository _repository;

        public MatriculadosImport()
        {
            _repository = new MatriculadosRepository();
        }

        /// <summary>
        /// Importa todos os registros do CSV para o banco. Retorna o total importado.
        /// </summary>
        public int ImportarDeCsv(string caminhoCsv)
        {
            if (!File.Exists(caminhoCsv))
                throw new FileNotFoundException($"Arquivo não encontrado: {caminhoCsv}", caminhoCsv);

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

            int total = 0;
            foreach (var item in csv.GetRecords<Matriculados>())
            {
                _repository.Adicionar(item);
                total++;
            }
            return total;
        }
    }

    /// <summary>
    /// ClassMap para CsvHelper mapear colunas do CSV para a entidade Matriculados.
    /// </summary>
    public class MatriculadosMap : ClassMap<Matriculados>
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
}
