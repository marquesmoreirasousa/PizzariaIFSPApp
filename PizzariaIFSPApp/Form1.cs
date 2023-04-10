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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void UpdateListView()
        {
            ltvColaboradores.Items.Clear();
            ColaboradorDAO colaboradorDAO = new ColaboradorDAO();

            List<Colaborador> colaboradores = colaboradorDAO.ListarColaboradores();
            if (colaboradores.Count > 0)
            {
                foreach (var colab in colaboradores)
                {
                    ListViewItem lv = new ListViewItem(colab.Id.ToString());
                    lv.SubItems.Add(colab.Nome);
                    lv.SubItems.Add(colab.Telefone);
                    lv.SubItems.Add(colab.Senha);
                    ltvColaboradores.Items.Add(lv);
                }
            }
            // Se não houver elementos, mesclar as colunas e exibir apenas um texto para o usuário.
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string nome = txbNome.Text;
            string telefone = txbTelefone.Text;
            string senha = txbSenha.Text;

            Colaborador colab = new Colaborador(nome, telefone, senha);

            try
            {
                ColaboradorDAO colaboradorDAO = new ColaboradorDAO();
                colaboradorDAO.Inserir(colab);
                UpdateListView();
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ClearFields();
        }
        private void ClearFields()
        {
            txbNome.Clear();
            txbTelefone.Clear();
            txbSenha.Clear();
            txbNome.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }
    }
}
