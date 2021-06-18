using ExemploApiCatalogoJogos.Entities;
using ExemploApiCatalogoJogos.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Repositories
{
    public class JogoTagRepository
    {
        private static Dictionary<int, JogoTag> jogoTag = new Dictionary<int, JogoTag>()
        {
            {1, new JogoTag{ Id = 1,IdJogo = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"),IdTag = Guid.Parse("92a789c6-3877-4a12-9d93-52d34fdb8271")} }, //PES //Simulador
            {2, new JogoTag{ Id = 2,IdJogo = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"),IdTag = Guid.Parse("c49ace51-e36e-4222-a2ba-b21ee28f5b0d")} }, //PES //Esporte
            
            {3, new JogoTag{ Id = 3,IdJogo = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"),IdTag = Guid.Parse("92a789c6-3877-4a12-9d93-52d34fdb8271") } }, //The SIMS //Simulador
            {4, new JogoTag{ Id = 4,IdJogo = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"),IdTag = Guid.Parse("0e612219-6a38-44e2-916c-7af154b3bc5a") } }, //The SIMS //Família
            {5, new JogoTag{ Id = 5,IdJogo = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"),IdTag = Guid.Parse("8a8a7a6c-c71d-4987-9473-d8ddaa7d137c") } }, //The SIMS //Casual

            {6, new JogoTag{ Id = 6,IdJogo = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"),IdTag = Guid.Parse("1026a2db-fc32-41b3-8c03-72a99c87899d") } }, //World of Warcraft: Shadowlands //RPG
            {7, new JogoTag{ Id = 7,IdJogo = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"),IdTag = Guid.Parse("de51c9a1-a204-48f4-91e9-2a4f03e19c3a") } }, //World of Warcraft: Shadowlands //Multiplayer


            {8, new JogoTag{ Id = 8,IdJogo = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"),IdTag = Guid.Parse("8a8a7a6c-c71d-4987-9473-d8ddaa7d137c") } }, //AMONG US //Casual
            {9, new JogoTag{ Id = 9,IdJogo = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"),IdTag = Guid.Parse("de51c9a1-a204-48f4-91e9-2a4f03e19c3a")  } }, //AMONG US //Multiplayer

            {10, new JogoTag{ Id = 10,IdJogo = Guid.Parse("da033439-f352-4539-879f-515759312d53"),IdTag = Guid.Parse("dbadef71-8bef-40f9-9c65-f09ff1facc8a") } }, //VALORANT //FPS
            {11, new JogoTag{ Id = 11,IdJogo = Guid.Parse("da033439-f352-4539-879f-515759312d53"),IdTag = Guid.Parse("c2c5f784-f702-4b3e-b1fa-4ab8dc02c1a1") } }, //VALORANT //Ação
            {12, new JogoTag{ Id = 12,IdJogo = Guid.Parse("da033439-f352-4539-879f-515759312d53"),IdTag = Guid.Parse("de51c9a1-a204-48f4-91e9-2a4f03e19c3a") } }, //VALORANT //Multiplayer
            {13, new JogoTag{ Id = 13,IdJogo = Guid.Parse("da033439-f352-4539-879f-515759312d53"),IdTag = Guid.Parse("fa5862d1-6eae-4197-865e-eccbaad02418") } }, //VALORANT //Estratégia
            
            {14, new JogoTag{ Id = 14,IdJogo = Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"),IdTag = Guid.Parse("1026a2db-fc32-41b3-8c03-72a99c87899d") } }, //Diablo //RPG
            {15, new JogoTag{ Id = 15,IdJogo = Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"),IdTag = Guid.Parse("c2c5f784-f702-4b3e-b1fa-4ab8dc02c1a1") } }, //Diablo //Ação
        };

        public Task<List<JogoTag>> ObterTodos()
        {
            return Task.FromResult(jogoTag.Values.ToList());
        }

        public Task<JogoTag> Obter(int id)
        {
            if (!jogoTag.ContainsKey(id))
                return Task.FromResult<JogoTag>(null);

            return Task.FromResult(jogoTag[id]);
        }

        public Task<List<JogoTag>> ObterTagsDoJogo(Guid idJogo)
        {
            return Task.FromResult(jogoTag.Values.Where(tagJogo => tagJogo.IdJogo.Equals(idJogo)).ToList());
        }

        public Task Inserir(JogoTagInputModel jogo_tag)
        {
            JogoTag jogoTagNew = new JogoTag();

            var id = jogoTagNew.Id = jogoTag.Count() + 1;
            jogoTagNew.IdJogo = Guid.Parse(jogo_tag.idJogo);
            jogoTagNew.IdTag = Guid.Parse(jogo_tag.idTag);


            jogoTag.Add(id, jogoTagNew);
            return Task.CompletedTask;
        }

        public Task Remover(int id)
        {
            jogoTag.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco
        }
    }
}
