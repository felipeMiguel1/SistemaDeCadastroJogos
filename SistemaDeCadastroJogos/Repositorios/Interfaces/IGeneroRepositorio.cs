using SistemaDeCadastroJogos.Model;

namespace SistemaDeCadastroJogos.Repositorios.Interfaces
{
    public interface IGeneroRepositorio
    {
        Task<List<GeneroModel>> BuscarTodosGeneros();
        Task<GeneroModel> BuscarPorId(int id);
        Task<GeneroModel> Adicionar(GeneroModel genero);
        Task<GeneroModel> Atualizar(GeneroModel genero, int id);
        Task<bool> Apagar(int id);
    }
}
