using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastroJogos.Model;
using SistemaDeCadastroJogos.Repositorios.Interfaces;

namespace SistemaDeCadastroJogos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {


        private readonly IJogoRepositorio _jogoRepositorio;

        public JogoController(IJogoRepositorio jogoRepositorio)
        {
            _jogoRepositorio = jogoRepositorio;

        }
        [HttpGet] 
        public async Task<ActionResult<List<JogoModel>>> BuscarTodosJogos() 
        {
            List<JogoModel> jogos = await _jogoRepositorio.BuscarTodosJogos();
            return Ok(jogos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<JogoModel>>> BuscarPorId(int id)
        {
            JogoModel jogo = await _jogoRepositorio.BuscarPorId(id);
            return Ok(jogo);
        }

        [HttpPost]
        public async Task<ActionResult<List<JogoModel>>> Cadastrar([FromBody] JogoModel jogoModel)
        {
            JogoModel jogo = await _jogoRepositorio.Adicionar(jogoModel);
            return Ok(jogo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<JogoModel>>> Atualizar([FromBody] JogoModel jogoModel, int id)
        {
            jogoModel.IdJogo = id;
            JogoModel jogo = await _jogoRepositorio.Atualizar(jogoModel, id);
            return Ok(jogo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<JogoModel>>> Apagar(int id)
        {
            
            bool apagado  = await _jogoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
