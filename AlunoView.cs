using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class AlunoView
    {
        // atributos
        private int _colIni, _linIni, _colFin, _linFin, _colDados, _linDados;
        private List<string> _campos;

        // construtor
        public AlunoView()
        {
            this._campos = new List<string>();
            this._campos.Add("Matricula   :");
            this._campos.Add("Nome        :");
            this._campos.Add("Email       :");
            this._campos.Add("Telefone    :");

            this._colIni = 18;
            this._linIni = 4;
            this._colFin = _colIni + this._campos[0].Length + 1 + 30;
            // +1 para colocar o traçado vertical direito depois dos :
            // +30 para ter espaço para o usuário digitar os dados
            this._linFin = _linIni + this._campos.Count + 1 + 2;
            // +1 para colocar o traçado horizontal na linha após o último campo
            // +2 para podermos usar um Título e um espaço para perguntar
            this._colDados = this._colIni + this._campos[0].Length + 1;
            this._linDados = this._linIni + 2;
        }

        public void MostrarFormulario()
        {
            Tela tela = new Tela();
            tela.MontarMoldura(
                this._colIni, this._linIni,
                this._colFin, this._linFin,
                "Cadastro de Alunos"
            );

            int linha = this._linDados;
            foreach (string campo in this._campos)
            {
                Console.SetCursorPosition(this._colIni + 1, linha);
                Console.Write(campo);
                linha++;
            }
        }

        public void EntrarDados(string qual, AlunoModel aluno)
        {
            AlunoModel obj = new AlunoModel();

            if (qual == "PK")
            {
                Console.SetCursorPosition(this._colDados, this._linDados);
                aluno.Matricula = Console.ReadLine();
            }
            else if (qual == "DT")
            {
                Tela t = new Tela();
                t.LimparArea(_colDados, _linDados+1, _colFin-1, _linFin-1);

                Console.SetCursorPosition(this._colDados, this._linDados + 1);
                aluno.Nome = Console.ReadLine();

                Console.SetCursorPosition(this._colDados, this._linDados + 2);
                aluno.Email = Console.ReadLine();

                Console.SetCursorPosition(this._colDados, this._linDados + 3);
                aluno.Telefone = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void MostrarDados(AlunoModel aluno)
        {
          
            Console.SetCursorPosition(this._colDados, this._linDados);
            Console.Write(aluno.Matricula);

            Console.SetCursorPosition(this._colDados, this._linDados + 1);
            Console.Write(aluno.Nome);

            Console.SetCursorPosition(this._colDados, this._linDados + 2);
            Console.Write(aluno.Email);

            Console.SetCursorPosition(this._colDados, this._linDados + 3);
            Console.Write(aluno.Telefone);
        }

        public string Perguntar(string pergunta)
        {
            string resposta = "";

            Console.SetCursorPosition(this._colIni + 1, this._linFin - 1);
            Console.Write(pergunta);
            resposta = Console.ReadLine();

            return resposta;
        }
    }
}
