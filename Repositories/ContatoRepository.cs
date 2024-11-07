
using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TRIMAPAPI.Repositories.Interfaces;

namespace TRIMAPAPI.Repositories
{

    public class ContatoRepository : IContatoRepository
    {
        private readonly AgendaContext _context; 

        public ContatoRepository(AgendaContext context) 
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
        var contato = await _context.Contatos.FirstOrDefaultAsync(c => c.Nome == nome && c.Ativo == true);
        var contato2 = _context.Contatos.Where(c => c.Nome.Contains(nome) && c.Ativo == true).ToList();
        return contato;
        }
        
        public async Task<List<Contato>> GetListarTodosContatos()
        {
            var contato = await _context.Contatos.ToListAsync(); //ToListAsyn() retorna todos os contatos
            return contato;
        }

    }
}