using System.Net;
using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using TRIMAPAPI.Services;

namespace TRIMAPAPI.Controllers
{
    [ApiController]
    [Route("contato")]
    public class ContatoController : ControllerBase
    {
        private readonly ContatoService _service;
        private readonly AgendaContext _context;

        public ContatoController(ContatoService service, AgendaContext context)
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
                if (!deletado) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete("delete2/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Contato))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> Delete2(int id)
        {
            try
            {
                var contato  = _context.Contatos.Find(id);
                if (contato is null ) return NotFound();
                _context.Contatos.Remove(contato);
                return NoContent();
            } 
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }


}