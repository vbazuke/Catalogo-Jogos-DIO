using ExemploApiCatalogoJogos.Entities;
using ExemploApiCatalogoJogos.Exceptions;
using ExemploApiCatalogoJogos.InputModel;
using ExemploApiCatalogoJogos.Repositories;
using ExemploApiCatalogoJogos.Services;
using ExemploApiCatalogoJogos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JogosTagsController : ControllerBase
    {
        private readonly JogoTagRepository _jogoTagRepository;

        public JogosTagsController(JogoTagRepository jogoTagRepository)
        {
            _jogoTagRepository = jogoTagRepository;
        }

        /// <summary>
        /// Buscar todas relações tag-jogo
        /// </summary>
        /// <remarks>
        /// Não é possível retornar os tags-jogo
        /// </remarks>
        /// <response code="200">Retorna a lista de tags-jogo</response>
        /// <response code="204">Caso não haja tags-jogo</response>   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoTag>>> ObterTodos()
        {
            var jogos_tags = await _jogoTagRepository.ObterTodos();

            if (jogos_tags.Count() == 0)
                return NoContent();

            return Ok(jogos_tags);
        }

        /// <summary>
        /// Buscar um tag-jogo pelo seu Id
        /// </summary>
        /// <param name="idTagJogo">Id do tag buscado</param>
        /// <response code="200">Retorna o tag-jogo  filtrado</response>
        /// <response code="204">Caso não haja tag-jogo  com este id</response>   
        [HttpGet("{idTagJogo:int}")]
        public async Task<ActionResult<JogoTagViewModel>> Obter([FromRoute] int idTagJogo)
        {
            var tag = await _jogoTagRepository.Obter(idTagJogo);

            if (tag == null)
                return NoContent();

            return Ok(tag);
        }

        /// <summary>
        /// Inserir uma relação jogo-tag
        /// </summary>
        /// <param name="jogoTag">Dados do jogo-tag a ser inserido</param>
        /// <response code="200">Cao o tag seja inserido com sucesso</response>
        /// <response code="422">Caso já exista um tag com mesmo nome para a mesma produtora</response>   
        [HttpPost]
        public async Task<ActionResult<JogoTagViewModel>> InserirTag([FromBody] JogoTagInputModel jogoTag)
        {
            try
            {
                await _jogoTagRepository.Inserir(jogoTag);
                return Ok(jogoTag);
            }
            catch (TagJaCadastradoException ex)
            {
                return UnprocessableEntity("Já existe um tag com este nome");
            }
        }

        /// <summary>
        /// Excluir uma relação tag-jogo
        /// </summary>
        /// /// <param name="idTagJogo">Id do tag-jogo a ser excluído</param>
        /// <response code="200">Caso o tag-jogo seja deletado com sucesso</response>
        /// <response code="404">Caso não exista um tag-jogo com este Id</response>   
        [HttpDelete("{idTagJogo:int}")]
        public async Task<ActionResult> ApagarTag([FromRoute] int idTagJogo)
        {
            try
            {
                await _jogoTagRepository.Remover(idTagJogo);
                return Ok();
            }
            catch (TagNaoCadastradoException ex)
            {
                return NotFound("Não existe este tag");
            }
        }

    }
}
