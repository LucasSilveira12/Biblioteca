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

        private int _posicao;

        private LivroView _livroView;
        private LivroModel _livro;

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
            LivroModel livro = new LivroModel();
            LivroView view = new LivroView();
            string resp;

            view.MostrarFormulario();
            view.EntrarDados("PK", livro);

            bool achei = this.Buscar(livro.Isbn);

            if (!achei)
            {
                resp = view.Perguntar("ISBN não encontrado. Deseja cadastrar? (S/N): ");
                if (resp.ToLower() == "s")
                {
                    view.EntrarDados("DT", livro);

                    resp = view.Perguntar("Confirma o cadastro? (S/N)");

                    if (resp.ToLower() == "s")
                    {
                        this._colecaolivros.Add(livro);
                    }
                }
            }
            else
            {
                view.MostrarDados(this._colecaolivros[this._posicao]);

                resp = view.Perguntar("Deseja Alterar/Excluir/Voltar (A/E/V) : ");

                if (resp.ToLower() == "a")
                {
                    view.EntrarDados("DT", livro);

                    resp = view.Perguntar("Confirma a alteração? (S/N) : ");

                    if (resp.ToLower() == "s")
                    {
                        this._colecaolivros[this._posicao] = livro;
                    }
                }
                else if (resp.ToLower() == "e")
                {
                    resp = view.Perguntar("Confirma a exclusão? (S/N) : ");

                    if (resp.ToLower() == "s")
                    {
                        this._colecaolivros.RemoveAt(this._posicao);
                    }
                }
            }
        }

        private bool Buscar(string isbn)
        {
            bool encontrei = false;

            for (int i = 0; i < this._colecaolivros.Count; i++)
            {
                if (this._colecaolivros[i].Isbn == isbn)
                {
                    this._posicao = i;
                    encontrei = true;
                    break;
                }
            }
            return encontrei;
        }
    }
}
