using projeto_matriculas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_matriculas.Controllers
{
    public class MainFormController
    {
        private ImportarModel _importarModel;
        private ConsultarModel _consultarModel;
        public MainFormController(ImportarModel importarModel, ConsultarModel consultarModel)
        {
            _importarModel = importarModel;
            _consultarModel = consultarModel;
        }
        public void BuscarArquivoMatriculados()
        {
            _importarModel.BuscarArquivoMatriculados();            
        }
        public void ImportarArquivo()
        {
            _importarModel.ImportarArquivo();
            _consultarModel.ConsultarAnosDisponiveis();
        }
    }
}
