using System.Text;
using projeto_matriculas.Controllers;

namespace projeto_matriculas
{
    public partial class Form1 : Form
    {
        private readonly MatriculadosRepository _repository;
        private readonly MatriculadosController controller;
        public Form1()
        {
            InitializeComponent();

            _repository = new MatriculadosRepository();
            controller = new MatriculadosController();

            // Exemplo de itens est�ticos
            comboBox1.Items.Add("Qualquer");
            comboBox1.Items.Add("EaD");
            comboBox1.Items.Add("Presencial");
            var modalidades = new List<string> { "Qualquer", "EaD", "Presencial" };
            comboBox1.DataSource = modalidades;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            // Popula comboBox2 com os estados em nome extenso e mai�sculas
            var estados = new List<string>
            {
                "ACRE",
                "ALAGOAS",
                "AMAPÁ",
                "AMAZONAS",
                "BAHIA",
                "CEARÁ",
                "DISTRITO FEDERAL",
                "ESPÍRITO SANTO",
                "GOIÁS",
                "MARANHÃO",
                "MATO GROSSO",
                "MATO GROSSO DO SUL",
                "MINAS GERAIS",
                "PARÁ",
                "PARAÍBA",
                "PARANÁ",
                "PERNAMBUCO",
                "PIAUÍ",
                "RIO DE JANEIRO",
                "RIO GRANDE DO NORTE",
                "RIO GRANDE DO SUL",
                "RONDÔNIA",
                "RORAIMA",
                "SANTA CATARINA",
                "SÃO PAULO",
                "SERGIPE",
                "TOCANTINS"
            };

            comboBox2.DataSource = estados;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;


            // Exemplo de itens est�ticos
            comboBox3.Items.Add("Qualquer");
            comboBox3.Items.Add("EaD");
            comboBox3.Items.Add("Presencial");
            comboBox3.DataSource = modalidades;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.csv";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String caminho = dialog.FileName;
                controller.ImportarArquivoCSV(caminho);
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            var selecionado = comboBox1.SelectedItem?.ToString();
            controller.TodosMatriculadosPorModalidade(selecionado);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var estado = comboBox2.SelectedItem?.ToString();
            controller.TodosMatriculadosPorEstado(estado);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var modalidade = comboBox3.SelectedItem?.ToString();
            controller.RankingUniversidades(modalidade);
        }

        public void mostrarTotaisEmTabela(TotaisAnuais totais)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("Ano", "Ano");
            dataGridView1.Columns.Add("Total", "Total");

            dataGridView1.Rows.Add("2014", totais.Ano2014);
            dataGridView1.Rows.Add("2015", totais.Ano2015);
            dataGridView1.Rows.Add("2016", totais.Ano2016);
            dataGridView1.Rows.Add("2017", totais.Ano2017);
            dataGridView1.Rows.Add("2018", totais.Ano2018);
            dataGridView1.Rows.Add("2019", totais.Ano2019);
            dataGridView1.Rows.Add("2020", totais.Ano2020);
            dataGridView1.Rows.Add("2021", totais.Ano2021);
            dataGridView1.Rows.Add("2022", totais.Ano2022);
        }
        public void mostrarRankingEmTabela(List<CursoTotal> cursos)
        {
            // Limpa e configura o DataGridView
            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Add("Nome", "Nome do Curso");
            dataGridView2.Columns.Add("Matriculados", "Total de Matriculas");

            // Preenche as linhas
            foreach (var curso in cursos)
            {
                dataGridView2.Rows.Add(curso.NomeCurso, curso.Total2022);
            }
        }
    }
}
