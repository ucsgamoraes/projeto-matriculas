using projeto_matriculas.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace projeto_matriculas.Models
{
    public class ImportarModel : IObservavel<ImportarModel>
    {
        private List<IObservador<ImportarModel>> _observadores;
        public string NomeArquivo { get; set; }

        public ImportarModel()
        {
            _observadores = new List<IObservador<ImportarModel>>();
        }

        public void NotificaObservadores()
        {
            foreach (IObservador<ImportarModel> item in _observadores)
            {
                item.Atualizar(this);
            }
        }

        public void RegistraObservador(IObservador<ImportarModel> o)
        {
            _observadores.Add(o);
        }

        public void RemoveObservador(IObservador<ImportarModel> o)
        {
            _observadores.Remove(o);
        }

        public void BuscarArquivoMatriculados()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\"; // Diretório inicial
                openFileDialog.Filter = "Todos os arquivos (*.*)|*.*|Arquivos de texto (*.txt)|*.txt";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    NomeArquivo = openFileDialog.FileName;
                }

                NotificaObservadores();
            }
        }
        public void ImportarArquivo()
        {
            if (string.IsNullOrEmpty(NomeArquivo))
            {
                MessageBox.Show("Selecione um arquivo para importar.");
                return;
            }

            var dados = File.ReadLines(NomeArquivo)
                      .Select(line => line.Split(';'))
                      .Select(data => LerDadosArquivo(data)).ToList();                      

            MatriculadosDAO DAO = new MatriculadosDAO();

            foreach (var item in dados)
            {
                DAO.Inserir(item);
            }
        }

        private Matriculado LerDadosArquivo(string[] data)
        {
            return new Matriculado
            {
                Estado = data[0],
                Cidade = data[1],
                IES = data[2],
                Sigla = data[3],
                Organizacao = data[4],
                CategoriaAdministrativa = data[5],
                NomeCurso = data[6],
                NomeDetalhadoCurso = data[7],
                Modalidade = data[8],
                Grau = data[9],
                Matriculas2014 = int.TryParse(data[10], out int matriculas2014) ? matriculas2014 : (int?)null,
                Matriculas2015 = int.TryParse(data[11], out int matriculas2015) ? matriculas2015 : (int?)null,
                Matriculas2016 = int.TryParse(data[12], out int matriculas2016) ? matriculas2016 : (int?)null,
                Matriculas2017 = int.TryParse(data[13], out int matriculas2017) ? matriculas2017 : (int?)null,
                Matriculas2018 = int.TryParse(data[14], out int matriculas2018) ? matriculas2018 : (int?)null,
                Matriculas2019 = int.TryParse(data[15], out int matriculas2019) ? matriculas2019 : (int?)null,
                Matriculas2020 = int.TryParse(data[16], out int matriculas2020) ? matriculas2020 : (int?)null,
                Matriculas2021 = int.TryParse(data[17], out int matriculas2021) ? matriculas2021 : (int?)null,
                Matriculas2022 = int.TryParse(data[18], out int matriculas2022) ? matriculas2022 : (int?)null
            };
        }
    }
}
