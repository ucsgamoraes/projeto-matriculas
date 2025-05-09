using projeto_matriculas.Interfaces;
using System;
using System.Collections.Generic;
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

            // Lógica para importar o arquivo
            // Aqui você pode adicionar o código para processar o arquivo selecionado
            // e armazenar os dados no banco de dados.
        }
    }
}
