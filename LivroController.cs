using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class LivroController
    {
        // atributos
        private List<LivroModel> _colecaolivros;
        private LivroModel _livro;
        private int _posicao;
        private LivroView _livroView;

        // construtor
        public LivroController()
        {
            this._livroView = new LivroView();
            this._livro = new LivroModel();

            this._colecaolivros = new List<LivroModel>();
            this._colecaolivros.Add(
                new LivroModel(
                    "123", 
                    "Faca", 
                    "Jo Nesbo", 
                    "Policial", 
                    450)
                );

        }

        public void ExecutarCRUD()
        {
            this._livroView.MostrarFormulario();
            this._livro = this._livroView.EntrarDados("CADASTRO");

            this._colecaolivros.Add(this._livro);

            Console.ReadKey();
        }
    }
}
