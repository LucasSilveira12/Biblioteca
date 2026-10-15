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

        private int _posicao;
        // construtor
        public AlunoController()
        {
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
            AlunoModel aluno = new AlunoModel();
            AlunoView view = new AlunoView();
            string resp;

            view.MostrarFormulario();

            // perguntar o código
            view.EntrarDados("PK", aluno);

            // busca pelo codigo
            bool achei = this.Buscar(aluno.Matricula);

            // se o codigo NAO FOI encontrado
            if (!achei)
            {
                // informa que NAO EXISTE e pergunta se deseja cadastrar
                resp = view.Perguntar("Matricula não encontrada. Deseja cadastrar? (S/N): ");

                // se SIM
                if (resp.ToLower() == "s")
                {
                    // pergunta demais dados
                    view.EntrarDados("DT", aluno);

                    // pergunta se confirma o cadastro
                    resp = view.Perguntar("Confirma o cadastro? (S/N)");

                    // se SIM
                    if (resp.ToLower() == "s")
                    {
                        // adiciona o novo registro
                        this._colecaoalunos.Add(aluno);
                    }

                }
            }
            // se o codigo FOI encontrado
            else
            {
                // mostra os dados do registro encontrado
                view.MostrarDados(this._colecaoalunos[this._posicao]);

                // pergunta se deseja alterar/excluir/voltar
                resp = view.Perguntar("Deseja Alterar/Excluir/Voltar (A/E/V) : ");

                // se desejar ALTERAR
                if(resp.ToLower() == "a")
                {
                    // pergunta os novos dados
                    view.EntrarDados("DT", aluno);
                    // pergunta se confirma alteração
                    resp = view.Perguntar("Confirma a alteração? (S/N) : ");
                    // se SIM
                    if (resp.ToLower() == "s")
                    {
                        // atualiza dos dados do registro
                        this._colecaoalunos[this._posicao] = aluno;
                    }
                }

                // se deseja EXCLUIR
                else if (resp.ToLower() == "e")
                {
                    // pergunta se confirma exclusao
                    resp = view.Perguntar("Confirma a exclusão? (S/N) : ");
                    // se SIM
                    if (resp.ToLower() == "s")
                    {
                        // exclui o registro
                        this._colecaoalunos.RemoveAt(this._posicao);
                    }
                }
            }
        }
                
            

        private bool Buscar(string matricula)
        {
            bool encontrei = false;

            for(int i = 0; i < this._colecaoalunos.Count; i++)
            {
                if (this._colecaoalunos[i].Matricula == matricula)
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
