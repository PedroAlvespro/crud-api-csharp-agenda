
using TRIMAPAPI.Entities;
using TRIMAPAPI.Repositories.Interfaces;


namespace TRIMAPAPI.Services
{
    public class LinhaService
    {
        private readonly ILinhaRepository _linhaservice;

        public LinhaService (ILinhaRepository linhaService)
        {
            _linhaservice = linhaService;
        }

        public async Task<Linha> CreateS(string nomelinha, Boolean ativolinha)
        {
            var linha = new Linha ()
            {
              NomeLinha = nomelinha,
              AtivoLinha = true
            };
            await _linhaservice.Create(linha);
            return linha;
        }

        public async Task<Linha> GetTel(int id)
        {
            var linha = await _linhaservice.GetLinha(id);
            return linha;
        }

        public async Task<Linha> DeletePorId(int id)
        {
            var row = await _linhaservice.GetLinha(id); /*espere, use o linhaservice para entrar no método getlinha
            use o método get linha para coletar o id, esse id vai ser removido.*/
            await _linhaservice.RemoveLinha(row); // espere, o linhaservice tem o id, remova pelo id toda a tabela correpondente.
            return row;
        }

        public async Task<List<Linha>> ListaLinha()
        {
            var allrow = await _linhaservice.GetListarLinha();
            return allrow;
        }        
    }
}