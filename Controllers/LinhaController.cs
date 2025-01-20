using System.Net;
using Microsoft.AspNetCore.Mvc;
using TRIMAPAPI.Services;
using TRIMAPAPI.Entities;


namespace TRIMAPAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinhaController : ControllerBase
    {
    private readonly LinhaService _linhaService;
    public LinhaController(LinhaService linhaService)
    {
        _linhaService = linhaService;
    }

    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Linha))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    
    public async Task<IActionResult> CreateLinha(string nomelinha, Boolean ativolinha)
    {
        var linha = await _linhaService.CreateS(nomelinha,ativolinha);
        if(linha is null) return BadRequest("não deu");
        return Ok(linha);
        
    }

    [HttpGet("por_id/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Linha))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> GetLinha(int id)
    {
        try
        {
            var row = await _linhaService.GetTel(id);
            if(row is null) return NotFound();
            return Ok(row);
        } 
        catch(Exception ex)
        {
             return StatusCode((int)HttpStatusCode.InternalServerError, ex);

        }
    }

    [HttpDelete("por_id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Linha))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RemovePorId(int id)
    {
        var linha = await _linhaService.GetTel(id);
        if(linha is null) return BadRequest("o número está vazio");
        await _linhaService.DeletePorId(linha.Id);

        return Ok(linha);
    }

    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Linha))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> ListaLinha()
    {
        var allrow = await _linhaService.ListaLinha();
        return Ok(allrow);
    }

    [HttpGet("por_id_existencial")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Linha))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> LinhaAtivadaC(int id)
    {
        try
        {
            var linha = await _linhaService.AtivoLinhaVerify(id);
            return Ok(linha);
        } catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex);
        }
    }
    }
}