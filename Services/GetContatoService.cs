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
            if(id < 0) throw new ArgumentException("o Id nao pode ser menor que 0");
            try
            {
               var contato = await _repository.Get(id);
               
               if(contato is null) Log.Log.LogToFile(nameof(GetContato), $"Erro, contato nulo");
                return contato;
            } 
            catch (Exception ex)
            {
                Log.Log.LogToFile(nameof(GetContato), $"Erro, contato não obtido, {ex.Message}");
                throw;
            }
        }

        /*dto*/
        public async Task<ContatoDto> GetContatoDto(int id)
        {
            if(id < 0) throw new ArgumentException("O id nao pode ser menor do que 0",nameof(id));
            try
            {
                var contato = await _repository.GetDto(id);
                if(contato is null || contato == null) Log.Log.LogToFile(nameof(GetContatoDto), "Lista não obtida.");
                return contato;
            }
            catch (Exception ex)
            {
                 Log.Log.LogToFile(nameof(GetContatoDto), $"Erro, lista nao obtida {ex.Message}");
                throw;
            }
        }

        public async Task<Contato> Create(string nome, string telefone)
        {
        try
        {
        var contato = new Contato()
        {
            Nome = nome,
            Telefone = telefone,
            Ativo = true
        };

        if(contato is null) throw new ArgumentException("Erro, contato nulo");

        Log.Log.LogToFile(nameof(Create),"Contato criado com sucesso !");

        await _repository.Create(contato);
        return contato;

        }
        catch (Exception ex)
        {
            Log.Log.LogToFile(nameof(Create), $" Erro, contato não criado,{ex.Message}");
            throw;
        }
        }

       public async Task<Contato> UpdateContato(int id, string nome, string telefone)
       {

        try 
        {
          
            var atualizado = await _repository.Get(id);
            
            if(atualizado is null)
            {
                Log.Log.LogToFile(nameof(UpdateContato), "Contato não atualizado ");
            }

            atualizado.Nome = nome;
            atualizado.Telefone = telefone;

            Log.Log.LogToFile(nameof(UpdateContato), "Contato Atualizado com sucesso");

            await _repository.UpdateContato(atualizado);

            return atualizado;
        }
        catch (Exception ex)
        {
            Log.Log.LogToFile(nameof(UpdateContato), $"Erro, Contato nao atualizado{ex.Message}");
            throw; //lança o erro
        }
       }
        public async Task<bool> Delete(int id)
        {
            if(id < 0) throw new ArgumentException("Erro, o id nao pode ser menor do que 0");
            try
            {
                var contato = await GetContato(id); 
            
                if(contato == null) Log.Log.LogToFile(nameof(Delete), "Erro, null");
                Log.Log.LogToFile(nameof(Delete), "Ok, Deletado com sucesso.");
            
                await _repository.Delete(contato);

                return true;
            }
            catch (Exception ex)
            {
                Log.Log.LogToFile(nameof(Delete), $"Erro, contato nao deletado {ex.Message}");
                throw;
            }
            
        }
        public async Task<Contato> GetByNameAsync(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("O nome não pode ser nulo ou vazio.", nameof(nome));
           
            try
            {
            var contato = await _repository.GetByNameAsync(nome);
            
            if (contato == null) Log.Log.LogToFile(nameof(GetByNameAsync), "Erro, contato nulo");
            
            Log.Log.LogToFile(nameof(GetByNameAsync), "Ok, Contato obtido com sucesso.");
            
            return contato; 
            } 
            catch (Exception ex)
            {
                Log.Log.LogToFile(nameof(GetByNameAsync), $"Erro, contato nao obtido{ex.Message}");
                throw;
            }   
            
        }

       public async Task<List<Contato>> GetListarTodosContato()
        {
            try
            {
                var contatos = await _repository.GetListarTodosContatos() ?? new List<Contato>();

                Log.Log.LogToFile(nameof(GetListarTodosContato), "Lista obtida com sucesso.");

                return contatos;
            }
            catch (Exception ex)
            {
                Log.Log.LogToFile(nameof(GetListarTodosContato), $"Erro, lista nao obtida, {ex.Message}");

                throw;
            }
        }
    }
}