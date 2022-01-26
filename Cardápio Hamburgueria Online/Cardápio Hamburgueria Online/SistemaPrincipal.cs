using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cardápio_Hamburgueria_Online
{
    public partial class SistemaPrincipal : Form
    {
        public SistemaPrincipal()
        {
            InitializeComponent();
        }

        int idAlterar;

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void listaDGCardapio()
        {
            ConectaBanco con = new ConectaBanco();
            dgCardapio.DataSource = con.listaCardapio();
            lblmsg.Text = con.mensagem;
        }


        private void SistemaPrincipal_Load(object sender, EventArgs e)
        {
            listaDGCardapio();
        }
        void limpar()
        {
            txtNome.Clear();
            txtAcompanhamento.Clear();
            txtValor.Clear();
        }

        private void dgCardapio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnConfirmaCadastro_Click(object sender, EventArgs e)
        {
            Cardapio L = new Cardapio();
            L.Nome = txtNome.Text;
            L.Acompanhamento = txtAcompanhamento.Text;
            L.Valor = Convert.ToSingle(txtValor.Text);
            ConectaBanco conecta = new ConectaBanco();
            bool retorno = conecta.insereLanche(L);
            if(retorno == true)
            {
                MessageBox.Show("Sucesso!");
                listaDGCardapio();
                limpar();
                txtNome.Focus();
            }
            else
            {
                lblmsg.Text = conecta.mensagem;
            }
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            (dgCardapio.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("nomeproduto like '%{0}%'", txtBusca.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRemovelanche_Click(object sender, EventArgs e)
        {
            int linha = dgCardapio.CurrentRow.Index;
            int id = Convert.ToInt32(dgCardapio.Rows[linha].Cells["idproduto"].Value.ToString());
            DialogResult resposta = MessageBox.Show("Você confirma este procedimento?"
                ,"Remover Produto", MessageBoxButtons.OKCancel);
            if (resposta == DialogResult.OK)
            {
                ConectaBanco conecta = new ConectaBanco();
                bool retorno = conecta.deletaLanche(id);
                if (retorno == true)
                {
                    MessageBox.Show("Produto deletado com sucesso!");
                    listaDGCardapio();
                }
                else
                {
                    MessageBox.Show(conecta.mensagem);
                }
            }
            else
            {
                MessageBox.Show("O procedimento foi cancelado.");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtValorAltera_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAcompanhamentoAltera_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNomeAltera_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmaAltera_Click(object sender, EventArgs e)
        {
            Cardapio L = new Cardapio();
            L.Nome = txtNomeAltera.Text;
            L.Acompanhamento = txtAcompanhamentoAltera.Text;
            L.Valor = Convert.ToSingle(txtValorAltera.Text);
            ConectaBanco conecta = new ConectaBanco();
            bool retorno = conecta.alteraLanche(L, idAlterar);
            if (retorno == true)
            {
                MessageBox.Show("Lanche alterado!");
                listaDGCardapio();
                Grid.SelectedTab = tabBuscar;
            }
            else
            {
                MessageBox.Show(conecta.mensagem);
            }
        }

        private void tabAlterar_Click(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int linha = dgCardapio.CurrentRow.Index;
            idAlterar = Convert.ToInt32(
                dgCardapio.Rows[linha].Cells["idproduto"].Value.ToString());
            txtNomeAltera.Text = dgCardapio.Rows[linha].Cells["nomeproduto"].Value.ToString();
            txtAcompanhamentoAltera.Text = dgCardapio.Rows[linha].Cells["acompanhamento"].Value.ToString();
            txtValorAltera.Text = dgCardapio.Rows[linha].Cells["valor"].Value.ToString();
            Grid.SelectedTab = tabAlterar;
        }
    }
}
