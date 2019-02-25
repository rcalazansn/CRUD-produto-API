using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Data
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("tab_produtos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Codigo)
                            .IsRequired()
                            .HasMaxLength(5)
                            .HasColumnType("varchar(5)");

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnType("varchar(60)");

            builder.Property(x => x.Detalhes)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnType("money");
        }
    }
}