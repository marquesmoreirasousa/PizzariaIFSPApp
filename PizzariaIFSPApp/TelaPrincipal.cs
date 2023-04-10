using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzariaIFSPApp
{
    public partial class TelaPrincipal : Form
    {
        private string Nome;
        private string Telefone;

        
        public TelaPrincipal(string nome, string tel, int permissao)
        {
            InitializeComponent();
            Nome = nome;
            Telefone = tel;
            if(permissao == 1)
            {
                relatóriosToolStripMenuItem.Visible = false;
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string texto = textBox1.Text;
            //Form1 frmCadastro = new Form1(texto);
            //this.Visible = false;
            //frmCadastro.ShowDialog();
            //this.Visible = true;
        }
        
    }
}
