using System.Net;
using Microsoft.AspNetCore.Mvc;
using TRIMAPAPI.Services;
using TRIMAPAPI.Context;
using TRIMAPAPI.Entities;


namespace TRIMAPAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinhaController : ControllerBase
    {

    private readonly LinhaContext _contextLinha;
    private readonly LinhaService _linhaservice;
    public LinhaController(LinhaContext contextlinha,LinhaService linhaservice )
    {
        _contextLinha = contextlinha;
        _linhaservice = linhaservice;
    }

    [HttpPost("postar linha")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Linha))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    
    public async Task<IActionResult> CreateLinha(string nomelinha, Boolean ativolinha)
    {
        var linha = await _linhaservice.CreateS(nomelinha,ativolinha);
        if(linha is null) return BadRequest("não deu");
        return Ok(linha);
        
    }

    [HttpGet("busca_linha")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Linha))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> GetLinha(int id)
    {
        try
        {
            var row = await _linhaservice.GetTel(id);
            if(row is null) return NotFound();
            return Ok(row);
        } 
        catch(Exception ex)
        {
             return StatusCode((int)HttpStatusCode.InternalServerError, ex);

        }
    }

    [HttpDelete("delete_por_id")]
    public async Task<IActionResult> RemovePorId(int id)
    {
        var linha = await _linhaservice.GetTel(id);
        if(linha is null) return BadRequest("o número está vazio");
        await _linhaservice.DeletePorId(linha.Id);

        return Ok(linha);
    }

    [HttpGet("listar_todas_as_linhas")]

    public async Task<IActionResult> ListaLinha()
    {
        var allrow = await _linhaservice.ListaLinha();
        return Ok(allrow);
    }






    }
}