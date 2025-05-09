using projeto_matriculas.Controllers;
using projeto_matriculas.Interfaces;
using projeto_matriculas.Models;

namespace projeto_matriculas
{
    public partial class MainForm : Form
    {
        public MainFormController _controller { get; set; }
        private AbaArquivo _abaArquivo { get; set; }
        private AbaConsulta _abaConsulta { get; set; }
        private ImportarModel _importarModel { get; set; }
        private ConsultarModel _consultarModel { get; set; }

        public MainForm()
        {
            InitializeComponent();

            _abaArquivo = new AbaArquivo(txtArquivo);
            _abaConsulta = new AbaConsulta();
            _importarModel = new ImportarModel();
            _consultarModel = new ConsultarModel();

            _importarModel.RegistraObservador(_abaArquivo);
            _consultarModel.RegistraObservador(_abaConsulta);

            _controller = new MainFormController(_importarModel, _consultarModel);
        }

        private void binArquivo_Click(object sender, EventArgs e)
        {
            _controller.BuscarArquivoMatriculados();           
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {

        }
    }
    public class AbaArquivo : IObservador<ImportarModel>
    {
        public TextBox _txtArquivo { get; set; }
        public AbaArquivo(TextBox txtArquivo)
        {
            _txtArquivo = txtArquivo;
        }
        public void Atualizar(ImportarModel observavel)
        {
            _txtArquivo.Text = observavel.NomeArquivo;
        }
    }
    public class AbaConsulta : IObservador<ConsultarModel>
    {
        public void Atualizar(ConsultarModel observavel)
        {
            // Implementar lógica para atualizar a aba Consulta
        }
    }
}
