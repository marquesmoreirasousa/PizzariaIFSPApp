using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaIFSPApp
{
    internal class Colaborador
    {

        private int _id;
        private string _nome;
        private string _telefone;
        private string _senha;

        public Colaborador(string nome, string tel, string senha)
        {
            _nome = nome;
            _telefone = tel;
            _senha = senha;
        }

        public Colaborador(int id, string nome, string tel, string senha): this(nome, tel, senha)
        {
            _id = id;
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }
        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }
    }
}
