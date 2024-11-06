using Entities;
using TRIMAPAPI.Repositories.Interfaces;
/*Aqui está a lógica, diferentemente do repository, que tem por objetivo
ter o contato direto com o banco de dado, o services tem os serviços
baseados no contato direto do repository. Então é mais uma camada de abstração.*/
namespace TRIMAPAPI.Services
{
    public class ContatoService
    {
        private readonly IContatoRepository _repository; /*objeto de Icontatorepository*/

        public ContatoService(IContatoRepository repository) /*construtor que recebe uma variável para instanciar
        as interfaces*/
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
    
    public async Task<Contato> GetByNameAsync(string nome)
    {
          if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome não pode ser nulo ou vazio.", nameof(nome));
        }
        var contato = await _repository.GetByNameAsync(nome);
        if (contato == null)
        {
            throw new KeyNotFoundException($"Contato com o nome '{nome}' não encontrado.");
        }
        return contato; 
    }


    }
}