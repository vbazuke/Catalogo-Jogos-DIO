using ExemploApiCatalogoJogos.Exceptions;
using ExemploApiCatalogoJogos.InputModel;
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
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        /// <summary>
        /// Buscar todos os tags de forma paginada
        /// </summary>
        /// <remarks>
        /// Não é possível retornar os tags sem paginação
        /// </remarks>
        /// <response code="200">Retorna a lista de tags</response>
        /// <response code="204">Caso não haja tags</response>   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagViewModel>>> ObterTodos()
        {
            var tags = await _tagService.ObterTodos();

            if (tags.Count() == 0)
                return NoContent();

            return Ok(tags);
        }

        /// <summary>
        /// Buscar um tag pelo seu Id
        /// </summary>
        /// <param name="idTag">Id do tag buscado</param>
        /// <response code="200">Retorna o tag filtrado</response>
        /// <response code="204">Caso não haja tag com este id</response>   
        [HttpGet("{idTag:guid}")]
        public async Task<ActionResult<JogoViewModel>> Obter([FromRoute] Guid idTag)
        {
            var tag = await _tagService.Obter(idTag);

            if (tag == null)
                return NoContent();

            return Ok(tag);
        }

        /// <summary>
        /// Inserir um tag no catálogo
        /// </summary>
        /// <param name="tagInputModel">Dados do tag a ser inserido</param>
        /// <response code="200">Cao o tag seja inserido com sucesso</response>
        /// <response code="422">Caso já exista um tag com mesmo nome para a mesma produtora</response>   
        [HttpPost]
        public async Task<ActionResult<TagViewModel>> InserirTag([FromBody] TagInputModel tagInputModel)
        {
            try
            {
                var tag = await _tagService.Inserir(tagInputModel);
                return Ok(tag);
            }
            catch (TagJaCadastradoException ex)
            {
                return UnprocessableEntity("Já existe um tag com este nome");
            }
        }

        /// <summary>
        /// Atualizar o preço de um jogo
        /// </summary>
        /// /// <param name="idJogo">Id do jogo a ser atualizado</param>
        /// <param name="nome">Novo preço do jogo</param>
        /// <response code="200">Cao o preço seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um jogo com este Id</response>   
        [HttpPatch("{idJogo:guid}/nome/{nome}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromRoute] string nome)
        {
            try
            {
                await _tagService.Atualizar(idJogo, nome);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }

        /// <summary>
        /// Excluir um tag
        /// </summary>
        /// /// <param name="idTag">Id do tag a ser excluído</param>
        /// <response code="200">Caso o tag seja deletado com sucesso</response>
        /// <response code="404">Caso não exista um tag com este Id</response>   
        [HttpDelete("{idTag:guid}")]
        public async Task<ActionResult> ApagarTag([FromRoute] Guid idTag)
        {
            try
            {
                await _tagService.Remover(idTag);

                return Ok();
            }
            catch (TagNaoCadastradoException ex)
            {
                return NotFound("Não existe este tag");
            }
        }

    }
}
