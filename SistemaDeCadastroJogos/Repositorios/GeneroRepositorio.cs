using Microsoft.EntityFrameworkCore;
using SistemaDeCadastroJogos.Data;
using SistemaDeCadastroJogos.Model;
using SistemaDeCadastroJogos.Repositorios.Interfaces;

namespace SistemaDeCadastroJogos.Repositorios
{

    

    public class GeneroRepositorio : IGeneroRepositorio
    {
        private readonly SistemaJogosDBContex _dbContext;
        public GeneroRepositorio(SistemaJogosDBContex sistemaTarefasDBContex)
        {
            _dbContext = sistemaTarefasDBContex;
        }

        public async Task<GeneroModel> BuscarPorId(int id)
        {
            return await _dbContext.Generos.FirstOrDefaultAsync(x => x.IdGenero == id);
        }

        public async Task<List<GeneroModel>> BuscarTodosGeneros()
        {
            return await _dbContext.Generos.ToListAsync();
        }
        public async Task<GeneroModel> Adicionar(GeneroModel genero)
        {
            await _dbContext.Generos.AddAsync(genero);
            await _dbContext.SaveChangesAsync();

            return genero;
        }

        public async Task<GeneroModel> Atualizar(GeneroModel genero, int id)
        {
            GeneroModel generoPorId = await BuscarPorId(id);

            if(generoPorId == null)
            {
                throw new Exception($"Genero para ID: {id} nao encontrado.");
            }

            generoPorId.NomeGenero = genero.NomeGenero;





            _dbContext.Generos.Update(generoPorId);
            await _dbContext.SaveChangesAsync();

            return generoPorId;   
        }


        public async Task<bool> Apagar(int id)
        {
            GeneroModel generoPorId = await BuscarPorId(id);

            if (generoPorId == null)
            {
                throw new Exception($"Genero para ID: {id} nao encontrado.");
            }
            
            _dbContext.Generos.Remove(generoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        
        
    }
}
