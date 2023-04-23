using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeCadastroJogos.Model;

namespace SistemaDeCadastroJogos.Data.Map
{
    public class JogoMap : IEntityTypeConfiguration<JogoModel>
    {
        public void Configure(EntityTypeBuilder<JogoModel> builder)
        {
            builder.HasKey(x => x.IdJogo);
            builder.Property(x => x.NomeJogo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DescricaoJogo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DataLancamentoJogo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.GeneroJogo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DesenvJogo).IsRequired().HasMaxLength(100);

        }
    }
}
