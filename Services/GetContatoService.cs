using Entities;
using Microsoft.AspNetCore.Mvc;
using TRIMAPAPI.Entities.Dto;
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

        /*dto*/
        public async Task<ContatoDto> GetContatoDto(int id)
        {
            var contatoDto  = await _repository.GetDto(id);
            
            return contatoDto;
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

       public async Task<Contato> UpdateContato(int id, string nome, string telefone)
       {
        var atualizado = await _repository.Get(id);
        if(atualizado == null || atualizado is null) throw new KeyNotFoundException("Contato não encontrado.");
        atualizado.Nome = nome;
        atualizado.Telefone = telefone;

        await _repository.UpdateContato(atualizado);
        return atualizado;
       }

        public async Task<bool> Delete(int id)
        {
            var contato = await GetContato(id); 
            
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

       public async Task<List<Contato>> GetListarTodosContato()
        {
                var contatos = await _repository.GetListarTodosContatos() ?? new List<Contato>();


                //instanciando diretamente, coisa permitida, devido a classe ser estática.
                TRIMAPAPI.Log.Log.LogToFile(nameof(GetListarTodosContato), "Lista obtida com sucesso.");
                
                return contatos;

        }
        public async Task<List<Contato>> GetListarTodosContatosLambda()
        {
            var lista = await _repository.GetListarTodosContatosLambda();
            return lista;
        }

    }
}