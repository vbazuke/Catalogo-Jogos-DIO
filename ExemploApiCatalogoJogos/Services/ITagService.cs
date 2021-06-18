using ExemploApiCatalogoJogos.InputModel;
using ExemploApiCatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Services
{
    public interface ITagService : IDisposable
    {
        Task<List<TagViewModel>> ObterTodos();
        Task<TagViewModel> Obter(Guid id);
        Task<TagViewModel> Inserir(TagInputModel jogo);
        Task Atualizar(Guid id, string nome);
        Task Remover(Guid id);
    }
}
