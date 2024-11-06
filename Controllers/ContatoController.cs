using System.Net;
using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using TRIMAPAPI.Services;
/*Aqui fica a parte do CRUD, invocação de serviços, retorno de erros, rotas... etc*/
namespace TRIMAPAPI.Controllers
{

    [ApiController]
    [Route("contato")]
    public class ContatoController : ControllerBase
    {
        private readonly ContatoService _service; /*variáveis, por fins de segurança, privadas
        apenas de leitura, objetos de suas respectivas classes*/
        private readonly AgendaContext _context;

        public ContatoController(ContatoService service, AgendaContext context) /*Construtor da classe*/
        {
            _service = service;
            _context = context;
        }

       


        [HttpGet("{id:int}")] 
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Contato))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> Get(int id) 
        {
            try
            {
                var contato = await _service.GetContato(id);
                if (contato is null) NotFound();

                return Ok(contato);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("ObterPorNome")] /*verbo http*/
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Contato))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
       public async Task<ActionResult> GetByNameAsync(string nome)
       {
            if(nome is null) return NotFound();
            var contato = await _service.GetByNameAsync(nome);
            return Ok(contato);
       }

        [HttpPost("{nome}/{telefone}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Contato))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> Get(string nome, string telefone)
        {
            try
            {
                var contato = await _service.Create(nome, telefone);

                return Ok(contato);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Contato))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var deletado = await _service.Delete(id);
                if (!deletado) return NotFound(); //if sujo
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

    }


}