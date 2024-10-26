using Entities;
using TRIMAPAPI.Repositories.Interfaces;

namespace TRIMAPAPI.Services
{
    public class ContatoService
    {
        private readonly IContatoRepository _repository;

        public ContatoService(IContatoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Contato> GetContato(int id)
        {
            var contato = await _repository.Get(id);
            return contato;
        }

         public async Task<Contato> Create(string nome, string telefone)
        {
            var contato = new Contato()
            {
                Nome = nome,
                Telefone = telefone,
                Ativo = true
            };

            await _repository.Create(contato);

            return contato;
        }


          public async Task<bool> Delete(int id)
        {

            var contato = await GetContato(id);  //retonro de código await - task
            
            if(contato == null) return false;

            await _repository.Delete(contato);

            return true;
        }
    }
}