using ExemploApiCatalogoJogos.Entities;
using ExemploApiCatalogoJogos.Exceptions;
using ExemploApiCatalogoJogos.InputModel;
using ExemploApiCatalogoJogos.Repositories;
using ExemploApiCatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<List<TagViewModel>> ObterTodos()
        {
            var tag = await _tagRepository.ObterTodos();

            return tag.Select(tag => new TagViewModel
            {
                Id = tag.Id,
                Nome = tag.Nome,
            })
                               .ToList();
        }    

    public async Task<TagViewModel> Obter(Guid id)
        {
            var tag = await _tagRepository.Obter(id);

            if (tag == null)
                return null;

            return new TagViewModel
            {
                Id = tag.Id,
                Nome = tag.Nome,
            };
        }

        public async Task<TagViewModel> Inserir(TagInputModel tag)
        {
            var entidadeTag = await _tagRepository.ObterPorNome(tag.Nome);

            if (entidadeTag.Count > 0)
                throw new TagJaCadastradoException();

            var tagInsert = new Tag
            {
                Id = Guid.NewGuid(),
                Nome = tag.Nome,
            };

            await _tagRepository.Inserir(tagInsert);

            return new TagViewModel
            {
                Id = tagInsert.Id,
                Nome = tag.Nome,
            };
        }


        public async Task Atualizar(Guid id, string nome)
        {
            var entidadetag = await _tagRepository.Obter(id);

            if (entidadetag == null)
                throw new TagNaoCadastradoException();

            entidadetag.Nome = nome;

            await _tagRepository.Atualizar(entidadetag);
        }

        public async Task Remover(Guid id)
        {
            var tag = await _tagRepository.Obter(id);

            if (tag == null)
                throw new TagNaoCadastradoException();

            await _tagRepository.Remover(id);
        }

        public void Dispose()
        {
            _tagRepository?.Dispose();
        }
    }
}
