﻿using Microsoft.EntityFrameworkCore;
using SistemaDeCadastroJogos.Data;
using SistemaDeCadastroJogos.Model;
using SistemaDeCadastroJogos.Repositorios.Interfaces;

namespace SistemaDeCadastroJogos.Repositorios
{

    

    public class JogoRepositorio : IJogoRepositorio
    {
        private readonly SistemaJogosDBContex _dbContext;
        public JogoRepositorio (SistemaJogosDBContex sistemaTarefasDBContex)
        {
            _dbContext = sistemaTarefasDBContex;
        }

        public async Task<JogoModel> BuscarPorId(int id)
        {
            return await _dbContext.Jogos.Include(x => x.GeneroJogo).FirstOrDefaultAsync(x => x.IdJogo == id);
        }

        public async Task<List<JogoModel>> BuscarTodosJogos()
        {
            return await _dbContext.Jogos.Include(x => x.GeneroJogo).ToListAsync();
        }
        public async Task<JogoModel> Adicionar(JogoModel jogo)
        {
            await _dbContext.Jogos.AddAsync(jogo);
            await _dbContext.SaveChangesAsync();

            return jogo;
        }

        public async Task<JogoModel> Atualizar(JogoModel jogo, int id)
        {
            JogoModel jogoPorId = await BuscarPorId(id);

            if(jogoPorId == null)
            {
                throw new Exception($"Jogo para ID: {id} nao encontrado.");
            }

            jogoPorId.NomeJogo = jogo.NomeJogo;
            jogoPorId.DescricaoJogo = jogo.DescricaoJogo;
            jogoPorId.DataLancamentoJogo = jogo.DataLancamentoJogo;           
            jogoPorId.GeneroJogoId = jogo.GeneroJogoId;
            jogoPorId.DesenvJogo = jogo.DesenvJogo;


            _dbContext.Jogos.Update(jogoPorId);
            await _dbContext.SaveChangesAsync();

            return jogoPorId;   
        }


        public async Task<bool> Apagar(int id)
        {
            JogoModel jogoPorId = await BuscarPorId(id);

            if (jogoPorId == null)
            {
                throw new Exception($"Jogo para ID: {id} nao encontrado.");
            }
            
            _dbContext.Jogos.Remove(jogoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        
        
    }
}
