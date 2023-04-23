using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastroJogos.Model;
using SistemaDeCadastroJogos.Repositorios.Interfaces;

namespace SistemaDeCadastroJogos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {


        private readonly IGeneroRepositorio _generoRepositorio;

        public GeneroController(IGeneroRepositorio generoRepositorio)
        {
            _generoRepositorio = generoRepositorio;

        }
        [HttpGet] 
        public async Task<ActionResult<List<GeneroModel>>> BuscarTodosGeneros() 
        {
            List<GeneroModel> generos = await _generoRepositorio.BuscarTodosGeneros();
            return Ok(generos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<GeneroModel>>> BuscarPorId(int id)
        {
            GeneroModel genero = await _generoRepositorio.BuscarPorId(id);
            return Ok(genero);
        }

        [HttpPost]
        public async Task<ActionResult<List<GeneroModel>>> Cadastrar([FromBody] GeneroModel generoModel)
        {
            GeneroModel genero = await _generoRepositorio.Adicionar(generoModel);
            return Ok(genero);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<GeneroModel>>> Atualizar([FromBody] GeneroModel generoModel, int id)
        {
            generoModel.IdGenero = id;
            GeneroModel genero = await _generoRepositorio.Atualizar(generoModel, id);
            return Ok(genero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<GeneroModel>>> Apagar(int id)
        {
            
            bool apagado  = await _generoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
