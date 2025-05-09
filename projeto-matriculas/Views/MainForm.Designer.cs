namespace projeto_matriculas
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            btnImportar = new Button();
            binArquivo = new Button();
            txtArquivo = new TextBox();
            lblArquivo = new Label();
            tabPage2 = new TabPage();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            dataGridView2 = new DataGridView();
            dataGridView1 = new DataGridView();
            grpModalidade = new GroupBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            cbAnoFim = new ComboBox();
            label4 = new Label();
            cbAnoIni = new ComboBox();
            label3 = new Label();
            gbTipoConsulta = new GroupBox();
            rbRanking = new RadioButton();
            rbTotalMatriculados = new RadioButton();
            btnConsultar = new Button();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            grpModalidade.SuspendLayout();
            gbTipoConsulta.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(702, 570);
            tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnImportar);
            tabPage1.Controls.Add(binArquivo);
            tabPage1.Controls.Add(txtArquivo);
            tabPage1.Controls.Add(lblArquivo);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(694, 542);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Leitura do arquivo";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnImportar
            // 
            btnImportar.Location = new Point(555, 27);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(133, 23);
            btnImportar.TabIndex = 3;
            btnImportar.Text = "Importar";
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Click += btnImportar_Click;
            // 
            // binArquivo
            // 
            binArquivo.Image = (Image)resources.GetObject("binArquivo.Image");
            binArquivo.Location = new Point(514, 27);
            binArquivo.Name = "binArquivo";
            binArquivo.Size = new Size(35, 23);
            binArquivo.TabIndex = 2;
            binArquivo.UseVisualStyleBackColor = true;
            binArquivo.Click += binArquivo_Click;
            // 
            // txtArquivo
            // 
            txtArquivo.Location = new Point(6, 27);
            txtArquivo.Name = "txtArquivo";
            txtArquivo.Size = new Size(502, 23);
            txtArquivo.TabIndex = 1;
            // 
            // lblArquivo
            // 
            lblArquivo.AutoSize = true;
            lblArquivo.Location = new Point(6, 9);
            lblArquivo.Name = "lblArquivo";
            lblArquivo.Size = new Size(49, 15);
            lblArquivo.TabIndex = 0;
            lblArquivo.Text = "Arquivo";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel1);
            tabPage2.Controls.Add(grpModalidade);
            tabPage2.Controls.Add(cbAnoFim);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(cbAnoIni);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(gbTipoConsulta);
            tabPage2.Controls.Add(btnConsultar);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(694, 542);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Consultas";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dataGridView2);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(6, 130);
            panel1.Name = "panel1";
            panel1.Size = new Size(678, 406);
            panel1.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 207);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 12;
            label2.Text = "Consulta 2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 9);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 11;
            label1.Text = "Consulta 1";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(10, 225);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(665, 177);
            dataGridView2.TabIndex = 10;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(10, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(665, 177);
            dataGridView1.TabIndex = 9;
            // 
            // grpModalidade
            // 
            grpModalidade.Controls.Add(checkBox2);
            grpModalidade.Controls.Add(checkBox1);
            grpModalidade.Location = new Point(484, 7);
            grpModalidade.Name = "grpModalidade";
            grpModalidade.Size = new Size(200, 70);
            grpModalidade.TabIndex = 15;
            grpModalidade.TabStop = false;
            grpModalidade.Text = "Modalidade";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(6, 45);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(48, 19);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "EAD";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 19);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(79, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Presencial";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // cbAnoFim
            // 
            cbAnoFim.FormattingEnabled = true;
            cbAnoFim.Location = new Point(153, 25);
            cbAnoFim.Name = "cbAnoFim";
            cbAnoFim.Size = new Size(121, 23);
            cbAnoFim.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(134, 28);
            label4.Name = "label4";
            label4.Size = new Size(13, 15);
            label4.TabIndex = 13;
            label4.Text = "a";
            // 
            // cbAnoIni
            // 
            cbAnoIni.FormattingEnabled = true;
            cbAnoIni.Location = new Point(6, 25);
            cbAnoIni.Name = "cbAnoIni";
            cbAnoIni.Size = new Size(121, 23);
            cbAnoIni.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 7);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 11;
            label3.Text = "Ano";
            // 
            // gbTipoConsulta
            // 
            gbTipoConsulta.Controls.Add(rbRanking);
            gbTipoConsulta.Controls.Add(rbTotalMatriculados);
            gbTipoConsulta.Location = new Point(278, 7);
            gbTipoConsulta.Name = "gbTipoConsulta";
            gbTipoConsulta.Size = new Size(200, 70);
            gbTipoConsulta.TabIndex = 10;
            gbTipoConsulta.TabStop = false;
            gbTipoConsulta.Text = "Tipo de Consulta";
            // 
            // rbRanking
            // 
            rbRanking.AutoSize = true;
            rbRanking.Location = new Point(10, 44);
            rbRanking.Name = "rbRanking";
            rbRanking.Size = new Size(121, 19);
            rbRanking.TabIndex = 1;
            rbRanking.TabStop = true;
            rbRanking.Text = "Ranking de cursos";
            rbRanking.UseVisualStyleBackColor = true;
            // 
            // rbTotalMatriculados
            // 
            rbTotalMatriculados.AutoSize = true;
            rbTotalMatriculados.Location = new Point(10, 19);
            rbTotalMatriculados.Name = "rbTotalMatriculados";
            rbTotalMatriculados.Size = new Size(177, 19);
            rbTotalMatriculados.TabIndex = 0;
            rbTotalMatriculados.TabStop = true;
            rbTotalMatriculados.Text = "Total de alunos matriculados";
            rbTotalMatriculados.UseVisualStyleBackColor = true;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(6, 83);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(678, 41);
            btnConsultar.TabIndex = 0;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 593);
            Controls.Add(tabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Matriculados Brasil";
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            grpModalidade.ResumeLayout(false);
            grpModalidade.PerformLayout();
            gbTipoConsulta.ResumeLayout(false);
            gbTipoConsulta.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox txtArquivo;
        private Label lblArquivo;
        private Button btnImportar;
        private Button binArquivo;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button btnConsultar;
        private GroupBox gbTipoConsulta;
        private RadioButton rbRanking;
        private RadioButton rbTotalMatriculados;
        private Label label3;
        private ComboBox cbAnoIni;
        private ComboBox cbAnoFim;
        private Label label4;
        private GroupBox grpModalidade;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView2;
        private DataGridView dataGridView1;
    }
}
