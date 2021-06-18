using ExemploApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Repositories
{
    public class TagRepository : ITagRepository
    {
        private static Dictionary<Guid, Tag> tags = new Dictionary<Guid, Tag>()
        {
            {Guid.Parse("c2c5f784-f702-4b3e-b1fa-4ab8dc02c1a1"), new Tag{ Id = Guid.Parse("c2c5f784-f702-4b3e-b1fa-4ab8dc02c1a1"), Nome = "Ação"}},
            {Guid.Parse("1026a2db-fc32-41b3-8c03-72a99c87899d"), new Tag{ Id = Guid.Parse("1026a2db-fc32-41b3-8c03-72a99c87899d"), Nome = "RPG"}},
            {Guid.Parse("dbadef71-8bef-40f9-9c65-f09ff1facc8a"), new Tag{ Id = Guid.Parse("dbadef71-8bef-40f9-9c65-f09ff1facc8a"), Nome = "FPS"}},
            {Guid.Parse("ee289ded-d338-4a98-8ad9-1f8700474243"), new Tag{ Id = Guid.Parse("ee289ded-d338-4a98-8ad9-1f8700474243"), Nome = "Aventura"}},   
            {Guid.Parse("de51c9a1-a204-48f4-91e9-2a4f03e19c3a"), new Tag{ Id = Guid.Parse("de51c9a1-a204-48f4-91e9-2a4f03e19c3a"), Nome = "Multiplayer"}},
            {Guid.Parse("fa5862d1-6eae-4197-865e-eccbaad02418"), new Tag{ Id = Guid.Parse("fa5862d1-6eae-4197-865e-eccbaad02418"), Nome = "Estratégia"}},
            {Guid.Parse("0e612219-6a38-44e2-916c-7af154b3bc5a"), new Tag{ Id = Guid.Parse("0e612219-6a38-44e2-916c-7af154b3bc5a"), Nome = "Família"}},
            {Guid.Parse("8a8a7a6c-c71d-4987-9473-d8ddaa7d137c"), new Tag{ Id = Guid.Parse("8a8a7a6c-c71d-4987-9473-d8ddaa7d137c"), Nome = "Casual"}},
            {Guid.Parse("ec947899-6652-4a51-b25f-28a63f4ac1a7"), new Tag{ Id = Guid.Parse("ec947899-6652-4a51-b25f-28a63f4ac1a7"), Nome = "Puzzle"}},
            {Guid.Parse("c49ace51-e36e-4222-a2ba-b21ee28f5b0d"), new Tag{ Id = Guid.Parse("c49ace51-e36e-4222-a2ba-b21ee28f5b0d"), Nome = "Esporte"}},
            {Guid.Parse("92a789c6-3877-4a12-9d93-52d34fdb8271"), new Tag{ Id = Guid.Parse("92a789c6-3877-4a12-9d93-52d34fdb8271"), Nome = "Simulador"}},
        };


        public Task<List<Tag>> ObterTodos()
        {
            return Task.FromResult(tags.Values.ToList());
        }
        public Task<List<Tag>> ObterPorNome(string nomeDaTag)
        {
            return Task.FromResult(tags.Values.Where(tag => tag.Nome.Equals(nomeDaTag)).ToList()); 
        }

        public Task<Tag> Obter(Guid id)
        {
            if (!tags.ContainsKey(id))
                return Task.FromResult<Tag>(null);

            return Task.FromResult(tags[id]);
        }


        public Task Inserir(Tag tag)
        {
            tags.Add(tag.Id, tag);
            return Task.CompletedTask;
        }

        public Task Atualizar(Tag tag)
        {
            tags[tag.Id] = tag;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            tags.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco
        }
    }
}
