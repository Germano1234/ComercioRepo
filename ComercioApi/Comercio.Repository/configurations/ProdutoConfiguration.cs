using Comercio.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comercio.Repository.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos").HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id");
            
            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .IsRequired()
                .HasMaxLength(220);
            
            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .IsRequired()
                .HasMaxLength(500);
            
            builder.Property(x => x.Valor)
                .HasColumnName("Valor")
                .IsRequired()
                .HasPrecision(10,2);
        }
    }
}