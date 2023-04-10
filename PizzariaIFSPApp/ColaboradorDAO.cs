using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaIFSPApp
{
    internal class ColaboradorDAO
    {
        private Conexao Con { get; set; }
        private SqlCommand Cmd { get; set; }
        public ColaboradorDAO()
        {
            Con = new Conexao();
            Cmd = new SqlCommand();
        }
        public void Inserir(Colaborador colab)
        {
            Cmd.Connection = Con.ReturnConnection();
            Cmd.CommandText = @"INSERT INTO Colaborador VALUES (@nome, @tel, @senha)";

            Cmd.Parameters.AddWithValue("@nome", colab.Nome);
            Cmd.Parameters.AddWithValue("@tel", colab.Telefone);
            Cmd.Parameters.AddWithValue("@senha", colab.Senha);

            try
            {
                //Insere o cliente
                Cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao inserir colaborador no banco.\n"
                    + err.Message);
            }
            finally
            {
                Con.CloseConnection();
            }
        }
        public List<Colaborador> ListarColaboradores()
        {
            Cmd.Connection = Con.ReturnConnection();
            Cmd.CommandText = "SELECT * FROM Colaborador";

            List<Colaborador> listaDeColab = new List<Colaborador>(); //Instancio a list com o tamanho padrão.
            try
            {
                SqlDataReader rd = Cmd.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (rd.Read())
                {
                    Colaborador colab = new Colaborador((int)rd["Id"], (string)rd["Nome"], 
                        (string)rd["Telefone"], (string)rd["Senha"]);
                    listaDeColab.Add(colab);
                }
                rd.Close();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao realizar leitura no banco.\n" + err.Message);
            }
            finally
            {
                Con.CloseConnection();
            }

            return listaDeColab;
        }
    }
}
