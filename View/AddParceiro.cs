using VistoriaZN.Entidades;
using VistoriaZN.Metodos;

namespace VistoriaZN
{
    public partial class AddParceiro : Form
    {
        private Fornecedor Parceiro = new();
        public AddParceiro()
        {
            InitializeComponent();
            IniciarFornecedor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var parceiro = new Fornecedor(this.txtNome.Text, this.txtTelefone.Text);
            CriarParceiro(parceiro);
        }

        private void CriarParceiro(Fornecedor parceiro)
        {
            if (parceiro.Telefone == "" || parceiro.Nome == "")
            {
                MessageBox.Show(
                    $"Campos obrigatorios",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            Metodos.Metodos.AdicionarParceiro(parceiro);
            IniciarFornecedor(true);
        }

        #region Data Grid

        private async void IniciarFornecedor(bool atualizar = false)
        {
            bool inativos = checkInativos.Checked;
            txtNome.Text = "";
            txtTelefone.Text = "";

            btnEditar.Visible = false;
            btnExcluir.Visible = false;

            btnAtivar.Visible = false;
            btnAtivar.Enabled = false;

            btnCriar.Visible = true;
            btnCriar.Enabled = true;
            dataGridParceiro.CellClick += dataGridParceiro_CellClick;
            dataGridParceiro.CurrentCellDirtyStateChanged += dataGridParceiro_CurrentCellDirtyStateChanged;
            if (atualizar)
            {
                dataGridParceiro.Rows.Clear();
                dataGridParceiro.Columns.Clear();
            }
            dataGridParceiro.Columns.Add("ID", "ID");
            dataGridParceiro.Columns.Add("Nome", "Nome");
            dataGridParceiro.Columns.Add("Telefone", "Telefone");
            List<Fornecedor> ListaParceiros = Metodos.Metodos.GetListFornecedor(!inativos);

            foreach (var fornecedor in ListaParceiros)
            {
                dataGridParceiro.Rows.Add(fornecedor.Id, fornecedor.Nome, fornecedor.Telefone);
            }
            dataGridParceiro.RowHeadersVisible = false;
            dataGridParceiro.ReadOnly = true;

            dataGridParceiro.AllowUserToAddRows = false;
            dataGridParceiro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridParceiro.Columns["ID"].FillWeight = 10;
            dataGridParceiro.Columns["Nome"].FillWeight = 40;
            dataGridParceiro.Columns["Telefone"].FillWeight = 40;
        }

        private void dataGridParceiro_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridParceiro.IsCurrentCellDirty)
            {
                dataGridParceiro.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridParceiro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int parceiroId = dataGridParceiro.Rows[e.RowIndex].Cells[(int)EnumTableParceiro.Id].Value.ToString().ToInt();
                var BuscarFornecedor = Metodos.Metodos.GetFornecedor(parceiroId);

                atualizarValor(BuscarFornecedor);

                btnCriar.Visible = false;

                if (!BuscarFornecedor.Ativo)
                {
                    btnAtivar.Visible = true;
                    btnAtivar.Enabled = true;
                }
                else
                {
                    btnEditar.Visible = true;
                    btnEditar.Enabled = true;
                    btnExcluir.Visible = true;
                    btnExcluir.Enabled = true;
                }
            }
        }

        private void dataGridParceiro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private enum EnumTableParceiro
        {
            Id = 0,
            Nome = 1,
            Telefone = 2
        }
        #endregion

        private void atualizarValor(Fornecedor parceiro)
        {
            this.Parceiro.Id = parceiro.Id;
            txtNome.Text = parceiro.Nome;
            txtTelefone.Text = parceiro.Telefone;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Fornecedor ParceiroAtualizar = new Fornecedor(this.Parceiro.Id, txtNome.Text, txtTelefone.Text, true);

            Metodos.Metodos.AtualizarParceiro(ParceiroAtualizar);
            IniciarFornecedor(true);
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            Fornecedor ParceiroAtualizar = new Fornecedor(this.Parceiro.Id, txtNome.Text, txtTelefone.Text, false);

            Metodos.Metodos.AtualizarParceiro(ParceiroAtualizar);
            IniciarFornecedor(true);
        }

        private void checkInativos_CheckedChanged(object sender, EventArgs e)
        {
            IniciarFornecedor(true);
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            Fornecedor ParceiroAtualizar = new Fornecedor(this.Parceiro.Id, txtNome.Text, txtTelefone.Text, true);

            Metodos.Metodos.AtualizarParceiro(ParceiroAtualizar);
            IniciarFornecedor(true);
        }
    }
}
