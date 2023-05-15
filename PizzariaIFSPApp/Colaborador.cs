using PizzariaIFSPApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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
            Nome = nome;
            Telefone = tel;
            Senha = senha;
        }

        public Colaborador(int id, string nome, string tel, string senha): this(nome, tel, senha)
        {
            Id = id;
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set {
                
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                    throw new Exception("O nome precisa ter ao menos 3 caracteres.");
                _nome = value; 
            }
        }
        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }
        public string Senha
        {
            get { return _senha; }
            set {
                if (!Seguranca.ValidarSenha(value))
                    throw new Exception("Senha não atende aos requisitos mínimos!");
                _senha = value; 
            }
        }
    }
}
