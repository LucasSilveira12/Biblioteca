using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class AlunoController
    {
        // atributos
        private List<AlunoModel> _colecaoalunos;
        private AlunoModel _alunos;
        private int _posicao;
        private AlunoView _alunoView;

        // construtor
        public AlunoController()
        {
            this._alunoView = new AlunoView();
            this._alunos = new AlunoModel();

            this._colecaoalunos = new List<AlunoModel>();
            this._colecaoalunos.Add(
                new AlunoModel(
                    "123",
                    "Lucas",
                    "lucas@gmail.com",
                    999999999)
                );

        }

        public void ExecutarCRUD()
        {
            this._alunoView.MostrarFormulario();
            this._alunos = this._alunoView.EntrarDados("CADASTRO");

            this._colecaoalunos.Add(this._alunos);
        }
    }
}
