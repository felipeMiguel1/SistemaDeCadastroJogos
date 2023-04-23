using SistemaDeCadastroJogos.Model;

namespace SistemaDeCadastroJogos.Repositorios.Interfaces
{
    public interface IJogoRepositorio
    {
        Task<List<JogoModel>> BuscarTodosJogos();
        Task<JogoModel> BuscarPorId(int id);
        Task<JogoModel> Adicionar(JogoModel jogo);
        Task<JogoModel> Atualizar(JogoModel jogo, int id);
        Task<bool> Apagar(int id);
    }
}
