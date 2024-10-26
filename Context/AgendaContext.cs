using System; // Importa namespaces padrão
using System.Collections.Generic; // Para listas, se necessário
using System.Linq; // Para LINQ, se necessário
using System.Threading.Tasks; // Para tarefas assíncronas
using Entities; // Importa o namespace onde está a classe Contato
using Microsoft.EntityFrameworkCore; // Importa o Entity Framework Core

namespace Context // Namespace onde está sua classe AgendaContext
{
    public class AgendaContext : DbContext
    {
        // Construtor que aceita opções de configuração do DbContext
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {
        }

        // DbSet para a entidade Contato
        public DbSet<Contato> Contatos{ get; set; } //entidade -> classe do c# e bd ao mesmo tempo
    }
}
