using Entities;
using TRIMAPAPI.Repositories.Interfaces;

namespace TRIMAPAPI.Services
{
    public class CreateContatoService
    {
        private readonly IContatoRepository _repository;

        public CreateContatoService(IContatoRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateContato(int id, string nome, string telefone, bool ativo)
        {
            var contato = new Contato
            {
                Id = id,
                Nome = nome,
                Telefone = telefone,
                Ativo = ativo
            };

            await _repository.Create(contato);
        }
    }
}