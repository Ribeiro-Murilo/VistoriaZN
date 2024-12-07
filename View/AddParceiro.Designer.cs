namespace VistoriaZN
{
    partial class AddParceiro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridParceiro = new DataGridView();
            groupBox1 = new GroupBox();
            btnExcluir = new Button();
            btnEditar = new Button();
            btnCriar = new Button();
            label2 = new Label();
            label1 = new Label();
            txtTelefone = new TextBox();
            txtNome = new TextBox();
            checkInativos = new CheckBox();
            btnAtivar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridParceiro).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridParceiro
            // 
            dataGridParceiro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridParceiro.Location = new Point(38, 60);
            dataGridParceiro.Name = "dataGridParceiro";
            dataGridParceiro.RowHeadersWidth = 51;
            dataGridParceiro.Size = new Size(716, 1253);
            dataGridParceiro.TabIndex = 0;
            dataGridParceiro.CellContentClick += dataGridParceiro_CellContentClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAtivar);
            groupBox1.Controls.Add(btnExcluir);
            groupBox1.Controls.Add(btnEditar);
            groupBox1.Controls.Add(btnCriar);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtTelefone);
            groupBox1.Controls.Add(txtNome);
            groupBox1.Location = new Point(990, 165);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(413, 350);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Fornecedor";
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(23, 305);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(94, 29);
            btnExcluir.TabIndex = 6;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Visible = false;
            btnExcluir.Click += btnExcluir_Click_1;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(23, 270);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Visible = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnCriar
            // 
            btnCriar.Location = new Point(292, 305);
            btnCriar.Name = "btnCriar";
            btnCriar.Size = new Size(94, 29);
            btnCriar.TabIndex = 4;
            btnCriar.Text = "Criar";
            btnCriar.UseVisualStyleBackColor = true;
            btnCriar.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 145);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 3;
            label2.Text = "Telefone";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 84);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 2;
            label1.Text = "Nome";
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(120, 142);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(266, 27);
            txtTelefone.TabIndex = 1;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(120, 81);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(266, 27);
            txtNome.TabIndex = 0;
            // 
            // checkInativos
            // 
            checkInativos.AutoSize = true;
            checkInativos.Location = new Point(38, 30);
            checkInativos.Name = "checkInativos";
            checkInativos.Size = new Size(99, 24);
            checkInativos.TabIndex = 2;
            checkInativos.Text = "Inativados";
            checkInativos.UseVisualStyleBackColor = true;
            checkInativos.CheckedChanged += checkInativos_CheckedChanged;
            // 
            // btnAtivar
            // 
            btnAtivar.Location = new Point(123, 305);
            btnAtivar.Name = "btnAtivar";
            btnAtivar.Size = new Size(94, 29);
            btnAtivar.TabIndex = 3;
            btnAtivar.Text = "Ativar";
            btnAtivar.UseVisualStyleBackColor = true;
            btnAtivar.Click += btnAtivar_Click;
            // 
            // AddParceiro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1682, 1340);
            Controls.Add(checkInativos);
            Controls.Add(groupBox1);
            Controls.Add(dataGridParceiro);
            Name = "AddParceiro";
            Text = "AddParceiro";
            ((System.ComponentModel.ISupportInitialize)dataGridParceiro).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridParceiro;
        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private TextBox txtTelefone;
        private TextBox txtNome;
        private Button btnExcluir;
        private Button btnEditar;
        private Button btnCriar;
        private CheckBox checkInativos;
        private Button btnAtivar;
    }
}