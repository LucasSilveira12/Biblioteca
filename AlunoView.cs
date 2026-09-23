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
        private int _colIni, _linIni, _colFin, _linFin;
        private List<string> _campos;

        // construtor
        public AlunoView()
        {
            this._campos = new List<string>();
            this._campos.Add("Matricula   :");
            this._campos.Add("Nome        :");
            this._campos.Add("Email       :");
            this._campos.Add("Telefone    :");

            this._colIni = 22;
            this._linIni = 2;
            this._colFin = _colIni + this._campos[0].Length + 1 + 30;
            // +1 para colocar o traçado vertical direito depois dos :
            // +30 para ter espaço para o usuário digitar os dados
            this._linFin = _linIni + this._campos.Count + 1 + 2;
            // +1 para colocar o traçado horizontal na linha após o último campo
            // +2 para podermos usar um Título e um espaço para perguntar
        }

        public void MostrarFormulario()
        {
            Tela tela = new Tela();
            tela.MontarMoldura(
                this._colIni, this._linIni,
                this._colFin, this._linFin,
                "Cadastro de Alunos"
            );

            int linha = this._linIni + 2;
            foreach (string campo in this._campos)
            {
                Console.SetCursorPosition(this._colIni + 1, linha);
                Console.Write(campo);
                linha++;
            }
        }

        public AlunoModel EntrarDados(string qual)
        {
            AlunoModel obj = new AlunoModel();

            if (qual == "PK")
            {
                Console.SetCursorPosition(
                    this._colIni + 1 + this._campos[0].Length,
                    this._linIni + 2);
                obj.Matricula = Console.ReadLine();
            }
            else
            {
                Console.SetCursorPosition(this._colIni + 1 + this._campos[0].Length, this._linIni + 2);
                obj.Matricula = Console.ReadLine();

                Console.SetCursorPosition(this._colIni + 1 + this._campos[0].Length, this._linIni + 3);
                obj.Nome = Console.ReadLine();

                Console.SetCursorPosition(this._colIni + 1 + this._campos[0].Length, this._linIni + 4);
                obj.Email = Console.ReadLine();

                Console.SetCursorPosition(this._colIni + 1 + this._campos[0].Length, this._linIni + 5);
                obj.Telefone = Convert.ToInt32(Console.ReadLine());
            }

                return obj;
        }
    }
}
