namespace SistemaDeCadastroJogos.Model
{
    public class JogoModel
    {
        public int IdJogo { get; set; }
        public string? NomeJogo { get; set; }
        public string? DescricaoJogo { get; set; }
        public string? DataLancamentoJogo { get; set; }      
        public string? DesenvJogo { get; set; }

        public int? GeneroJogoId { get; set; }
        public virtual GeneroModel? GeneroJogo { get; set; }
    }
}
