using Microsoft.AspNetCore.Mvc;
using TRIMAPAPI.Services;

namespace TRIMAPAPI.Controllers
{
    [ApiController]
    [Route("contato")]
    public class ContatoController : ControllerBase
    {
        [HttpGet("{id:int}")]
        /*assíncrona, pois consumirá um bd, tendo em vista a finalidade da API*/
        public async Task<ActionResult> Get([FromServices] GetContatoService service, int id)
        {
            try
            {
                var contato = await service.GetContato(id);
                return Ok(contato);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}