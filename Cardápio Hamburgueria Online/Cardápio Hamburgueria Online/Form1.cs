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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;
            SistemaPrincipal sist = new SistemaPrincipal();

            if (usuario == "BIGBOSS" && senha == "cardapioadm")
            {
                MessageBox.Show("Bem-Vindo " + usuario + "!");
                sist.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Acesso negado!");
            }
        }
    }
}
