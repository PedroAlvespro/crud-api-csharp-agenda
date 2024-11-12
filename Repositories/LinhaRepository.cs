using Microsoft.EntityFrameworkCore;
using TRIMAPAPI.Context;
using TRIMAPAPI.Entities;

namespace TRIMAPAPI.Repositories.Interfaces
{
    public class LinhaRepository : ILinhaRepository
    {
        private readonly LinhaContext _contextLinha;
        public LinhaRepository (LinhaContext context)
        {
            _contextLinha = context; //chamada do contexto no construtor da classe
        }
        public async Task Create (Linha linha) //usa assícrono para thread
        {
            _contextLinha.Linha.Add(linha); //pegue do contexto o modelo linha e adicione uma linha
            await _contextLinha.SaveChangesAsync(); //pegue as infos adicionadas e espere para salva-las
        }

        public async Task<Linha> GetLinha(int id)
        {
           var linha = await _contextLinha.Linha.FindAsync(id);
           return linha;
        }

        public async Task<List<Linha>> GetListarLinha()
        {
           var linha  = await _contextLinha.Linha.ToListAsync();
           return linha;
        }

        public async Task RemoveLinha(Linha linha)
        {
              _contextLinha.Linha.Remove(linha);
            await _contextLinha.SaveChangesAsync();
        }
    }
}