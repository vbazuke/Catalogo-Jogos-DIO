using ExemploApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Repositories
{
    public interface ITagRepository : IDisposable
    {
        Task<Tag> Obter(Guid id);
        Task<List<Tag>> ObterTodos();
        Task<List<Tag>> ObterPorNome(string nomeDaTag);
        Task Inserir(Tag tag);
        Task Remover(Guid idDoTag);
        Task Atualizar(Tag tag);
    }
}
