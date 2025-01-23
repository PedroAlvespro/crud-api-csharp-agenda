
using Microsoft.AspNetCore.Mvc;
using TRIMAPAPI.Entities;
using TRIMAPAPI.Services;

namespace TRIMAPAPI.Controllers
{
    [Route("api/[controller]")]
    public class CttAndRowController : Controller
    {
        /*Apenas mais um controller com uma rota diferente, para executar opreções utilizando os 
        2 context e os 2 services
        */
    private readonly ContatoService _service; 
    private readonly LinhaService _linhaservice;

    public CttAndRowController (ContatoService service, LinhaService linhaservice)
    {
        _service = service;
        _linhaservice = linhaservice;
    }

    
    }
}