using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRIMAPAPI.Entities;

namespace TRIMAPAPI.Repositories.Interfaces
{
    public interface ILinhaRepository
    {
        public Task Create(Linha linha);
        public Task<List<Linha>> GetListarLinha();
        public Task<Linha> GetLinha(int id);
        public Task RemoveLinha(Linha linha);
    }
}