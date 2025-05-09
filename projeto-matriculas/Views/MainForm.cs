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
            _abaConsulta = new AbaConsulta(cbAnoIni, cbAnoFim, rbTotalMatriculados, rbRanking, ckbPresencial, ckbEAD, dgvConsulta1, dgvConsulta2);
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
            _controller.ImportarArquivo();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            _controller.Consultar();
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
        public ComboBox _cbAnoIni { get; set; }
        public ComboBox _cbAnoFim { get; set; }
        public RadioButton _rbTotalMatriculados { get; set; }
        public RadioButton _rbRanking { get; set; }
        public CheckBox _ckbPresencial { get; set; }
        public CheckBox _ckbEAD { get; set; }
        DataGridView _dgvConsulta1 { get; set; }
        DataGridView _dgvConsulta2 { get; set; }
        public AbaConsulta(ComboBox cbAnoIni, ComboBox cbAnoFim, RadioButton rbTotalMatriculados, RadioButton rbRanking, CheckBox ckbPresencial, CheckBox ckbEAD, DataGridView dgvConsulta1, DataGridView dgvConsulta2)
        {
            _cbAnoIni = cbAnoIni;
            _cbAnoFim = cbAnoFim;
            _rbTotalMatriculados = rbTotalMatriculados;
            _rbRanking = rbRanking;
            _ckbPresencial = ckbPresencial;
            _ckbEAD = ckbEAD;
            _dgvConsulta1 = dgvConsulta1;
            _dgvConsulta2 = dgvConsulta2;
            
        }
        public void Atualizar(ConsultarModel observavel)
        {
            foreach (var ano in observavel.Filtros.AnosDisponiveis)
            {
                _cbAnoIni.Items.Add(ano);
                _cbAnoFim.Items.Add(ano);
            }
            if (observavel.Filtros.TipoConsulta == Enums.TipoConsulta.TotalAlunos)
            {
                _rbTotalMatriculados.Checked = true;
                _rbRanking.Checked = false;
            }
            else
            {
                _rbTotalMatriculados.Checked = false;
                _rbRanking.Checked = true;
            }
            if (observavel.Filtros.IsPresencial)
            {
                _ckbPresencial.Checked = true;
            }
            if (observavel.Filtros.IsEAD)
            {
                _ckbEAD.Checked = true;
            }

            _dgvConsulta1.DataSource = observavel.Consulta1;
            _dgvConsulta2.DataSource = observavel.Consulta2;
        }
    }
}
