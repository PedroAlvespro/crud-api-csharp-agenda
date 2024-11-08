using Entities;

namespace TRIMAPAPI.Repositories.Interfaces
{
    public interface IContatoRepository
    {
 
        public Task Create(Contato contato);
        public Task<Contato> Get(int id);
        public Task Delete(Contato contato);
        public Task<Contato> GetByNameAsync(string nome); 
        public Task<List<Contato>> GetListarTodosContatos();
        public Task<List<Contato>> GetListarTodosContatosLambda();
        
    }
}