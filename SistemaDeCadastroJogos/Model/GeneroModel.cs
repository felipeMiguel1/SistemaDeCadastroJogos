namespace SistemaDeCadastroJogos.Model
{
    public class GeneroModel
    {
        public int IdGenero { get; set; }     
        public string? NomeGenero { get; set; }
        public int? JogoId { get; set; }

        public virtual JogoModel? Jogo { get; set; }
    }

}
