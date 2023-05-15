using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PizzariaIFSPApp
{
    public partial class Form1 : Form
    {
        private int id;
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

            Colaborador colab;
            
            

            try
            {
                if (txbSenha.Text != txbConfSenha.Text)
                {
                    MessageBox.Show("As senhas dever ser iguais!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbSenha.Focus();
                    return;
                }
                ColaboradorDAO colaboradorDAO = new ColaboradorDAO();
                if (btnMostrar.Text == "CADASTRAR")
                {
                    colab = new Colaborador(nome, telefone, senha);
                    colaboradorDAO.Inserir(colab);
                }
                else
                {
                    colab = new Colaborador(id, nome, telefone, senha);
                    colaboradorDAO.Atualizar(colab);
                }
                
                UpdateListView();
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClearFields();
        }
        private void ClearFields()
        {
            txbNome.Clear();
            txbTelefone.Clear();
            txbSenha.Clear();
            txbConfSenha.Clear();
            mktCpf.Clear();
            txbNome.Focus();
            ckbSenha.Checked = false;
            btnExcluir.Visible = false;
            btnMostrar.Text = "CADASTRAR";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }
        private void ltvColaboradores_MouseClick(object sender, MouseEventArgs e)
        {
            int index = ltvColaboradores.FocusedItem.Index;
            id = int.Parse(ltvColaboradores.Items[index].SubItems[0].Text);
            txbNome.Text = ltvColaboradores.Items[index].SubItems[1].Text;
            txbTelefone.Text = ltvColaboradores.Items[index].SubItems[2].Text;
            txbSenha.Text = ltvColaboradores.Items[index].SubItems[3].Text;

            btnMostrar.Text = "EDITAR";
            btnExcluir.Visible = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ColaboradorDAO colabDao = new ColaboradorDAO();

            try
            {
                colabDao.Excluir(id);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "AVISO DE ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateListView();
            ClearFields();
        }

        private void ckbSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSenha.Checked)
            {
                txbSenha.PasswordChar = '\0';
                txbConfSenha.PasswordChar = '\0';
            }
            else
            {
                txbSenha.PasswordChar = '*';
                txbConfSenha.PasswordChar = '*';
            }
        }

        private void txbSenha_MouseHover(object sender, EventArgs e)
        {
            ttpSenha.SetToolTip(txbSenha, "Deve conter: 8 caracteres," +
                " letra maiúscula e número!");
        }

        private void txbConfSenha_MouseHover(object sender, EventArgs e)
        {
            ttpSenha.SetToolTip(txbConfSenha, "Deve ser idêntico à senha!");
        }
    }
}
