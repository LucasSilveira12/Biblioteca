using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class AlunoModel
    {
        private string _matricula;
        private string _nome;
        private string _email;
        private int _telefone;

        public string Matricula {  get { return _matricula; } set { _matricula = value; }}
        public string Nome { get { return _nome; } set { _nome = value; }}
        public string Email { get { return _email; } set { _email = value; }}
        public int Telefone { get { return _telefone; } set { _telefone = value; }}

        public AlunoModel()
        {
            this.Matricula = "";
            this.Nome = "";
            this.Email = "";
            this.Telefone = 0;
        }

        public AlunoModel(string matricula, string nome, string email, int telefone)
        {
            this.Matricula = matricula;
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
        }
    }
}
