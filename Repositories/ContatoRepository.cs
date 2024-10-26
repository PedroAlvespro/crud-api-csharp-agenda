
using Context;
using Entities;
using TRIMAPAPI.Repositories.Interfaces;

namespace TRIMAPAPI.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly AgendaContext _context;

        public ContatoRepository(AgendaContext context) //injeção de dependencia
        {
            _context = context;
        }

        public async Task Create(Contato contato)
        {
            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();
        }

        public async Task<Contato> Get(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            return contato;
        }

        public async Task Delete(Contato contato)
        {
             _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();
        }
    }
}