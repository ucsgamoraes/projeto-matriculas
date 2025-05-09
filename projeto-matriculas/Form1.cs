using System.Text;

namespace projeto_matriculas
{
    public partial class Form1 : Form
    {
        private readonly MatriculadosRepository _repository;
        public Form1()
        {
            InitializeComponent();

            _repository = new MatriculadosRepository();

            // Exemplo de itens estáticos
            comboBox1.Items.Add("Qualquer");
            comboBox1.Items.Add("EaD");
            comboBox1.Items.Add("Presencial");
            var modalidades = new List<string> { "Qualquer", "EaD", "Presencial" };
            comboBox1.DataSource = modalidades;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            // Popula comboBox2 com os estados em nome extenso e maiúsculas
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


            // Exemplo de itens estáticos
            comboBox3.Items.Add("Qualquer");
            comboBox3.Items.Add("EaD");
            comboBox3.Items.Add("Presencial");
            comboBox3.DataSource = modalidades;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.csv"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time

            MatriculadosImport import = new MatriculadosImport();

            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                String path = dialog.FileName; // get name of file
                import.ImportarDeCsv(path);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                // Escolhe método conforme seleção
                var selecionado = comboBox1.SelectedItem?.ToString();
                TotaisAnuais totais;
                if (string.Equals(selecionado, "Qualquer", StringComparison.OrdinalIgnoreCase))
                {
                    totais = _repository.ObterTotaisAnuais();
                }
                else
                {
                    totais = _repository.ObterTotaisAnuaisPorModalidade(selecionado);
                }

                // Preenche DataGridView
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
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter totais: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    // Escolhe método conforme seleção
                    var estado = comboBox2.SelectedItem?.ToString();
                    TotaisAnuais totais;
                    totais = _repository.ObterTotaisPorEstado(estado);

                    // Preenche DataGridView
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
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao obter totais: {ex.Message}",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Lê a modalidade selecionada no comboBox3
                var modalidade = comboBox3.SelectedItem?.ToString();
                List<CursoTotal> totais;

                // Se “Qualquer”, traz o top geral; senão, filtra pela modalidade
                if (string.Equals(modalidade, "Qualquer", StringComparison.OrdinalIgnoreCase))
                {
                    totais = _repository.ObterTopCursos2022();
                }
                else
                {
                    totais = _repository.ObterTopCursos2022PorModalidade(modalidade);
                }

                // Limpa e configura o DataGridView
                dataGridView2.Columns.Clear();
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Add("Nome", "Nome do Curso");
                dataGridView2.Columns.Add("Matriculados", "Total de Matrículas");

                // Preenche as linhas
                foreach (var item in totais)
                {
                    dataGridView2.Rows.Add(item.NomeCurso, item.Total2022);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter ranking de cursos: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
