
using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TRIMAPAPI.Repositories.Interfaces;

namespace TRIMAPAPI.Repositories
{
    /*CAMADA ENTRE O DBCONTEXT E OS CONTROLLERS, AQUI FICAM ARMAZENADOS AS INTERFACES E SEPARAÇÃO
      ENTRE LÓGICA DE DADOS E LÓGICA DE NEGÓCIOS.
    */
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
       

        public async Task<Contato> GetByNameAsync(string nome)
        {
        return await _context.Contatos.FirstOrDefaultAsync(c => c.Nome == nome);
        }
    }
}