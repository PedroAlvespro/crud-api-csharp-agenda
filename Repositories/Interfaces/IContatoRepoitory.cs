using Entities;

namespace TRIMAPAPI.Repositories.Interfaces
{
    public interface IContatoRepository
    {
        public Task Create(Contato contato);
        public Task<Contato> Get(int id);
    }
}