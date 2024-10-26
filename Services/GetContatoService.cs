using Entities;
using TRIMAPAPI.Repositories.Interfaces;

namespace TRIMAPAPI.Services
{
    public class GetContatoService
    {
        private readonly IContatoRepository _repository;

        public GetContatoService(IContatoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Contato> GetContato(int id)
        {
            var contato = await _repository.Get(id) ?? throw new ArgumentException("Contato não encontrado");
            return contato;
        }
    }
}