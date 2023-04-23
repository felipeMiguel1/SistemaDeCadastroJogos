using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeCadastroJogos.Model;

namespace SistemaDeCadastroJogos.Data.Map
{
    public class GeneroMap : IEntityTypeConfiguration<GeneroModel>
    {
        public void Configure(EntityTypeBuilder<GeneroModel> builder)
        {
            builder.HasKey(x => x.IdGenero);
            builder.Property(x => x.NomeGenero).IsRequired().HasMaxLength(100);
            builder.Property(x => x.JogoId);

            builder.HasOne(x => x.Jogo);

        }
    }
}
