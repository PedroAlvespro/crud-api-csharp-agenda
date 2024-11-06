using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
using Entities; 
using Microsoft.EntityFrameworkCore; 
/*Aqui é onde está a conexão da API e o bd*/
namespace Context 
{
    public class AgendaContext : DbContext
    {
        
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)//constutor da classe
        {
        }
        public DbSet<Contato> Contatos{ get; set; } //entidade -> classe do c# e bd ao mesmo tempo
        /*AQUI FICA A CONEXÃP COM O BD, A PONTE ENTRE O SISTEMA E O BANCO DE DADOS*/
    }
}
