
using TRIMAPAPI.Entities;
using TRIMAPAPI.Repositories.Interfaces;


namespace TRIMAPAPI.Services
{
    public class LinhaService
    {
        private readonly ILinhaRepository _linhaRepository;

        public LinhaService (ILinhaRepository linhaRepository)
        {
            _linhaRepository = linhaRepository;
        }

        public async Task<Linha> CreateS(string nomelinha, Boolean ativolinha)
        {
            var linha = new Linha ()
            {
              NomeLinha = nomelinha,
              AtivoLinha = true
            };
            await _linhaRepository.Create(linha);
            return linha;
        }

        public async Task<Linha> GetTel(int id)
        {
            var linha = await _linhaRepository.GetLinha(id);
            return linha;
        }

        public async Task<Linha> DeletePorId(int id)
        {
            var row = await _linhaRepository.GetLinha(id); /*espere, use o linhaservice para entrar no método getlinha
            use o método get linha para coletar o id, esse id vai ser removido.*/
            await _linhaRepository.RemoveLinha(row); // espere, o linhaservice tem o id, remova pelo id toda a tabela correpondente.
            return row;
        }

        public async Task<List<Linha>> ListaLinha()
        {
            var allrow = await _linhaRepository.GetListarLinha();
            return allrow;
        }        
    }
}