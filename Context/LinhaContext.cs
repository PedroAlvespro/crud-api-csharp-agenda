using Microsoft.EntityFrameworkCore;
using TRIMAPAPI.Entities;

namespace TRIMAPAPI.Context
{
    public class LinhaContext : DbContext
    {
        public LinhaContext (DbContextOptions<LinhaContext> options) : base(options)
        {
        }
        public DbSet<Linha> Linha {get;set;} //pega o modelo ou entitie e faz o bd conforme ele
    }
}