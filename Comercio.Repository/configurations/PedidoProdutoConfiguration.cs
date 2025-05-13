using Comercio.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comercio.Repository.Configurations{
    public class PedidoProdutoConfiguration : IEntityTypeConfiguration<PedidoProduto>
    {
        public void Configure(EntityTypeBuilder<PedidoProduto> builder)
        {
            builder.ToTable("PedidosProdutos").HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id");
            
            builder.Property(x => x.PedidoId)
                .HasColumnName("PedidoId")
                .IsRequired();

            builder.Property(x => x.ProdutoId)
                .HasColumnName("ProdutoId")
                .IsRequired();
            
            builder.Property(x =>x.Quantidade)
                .HasColumnName("Quantidade")
                .HasDefaultValue(1);
            
            builder.HasOne(x => x.Pedido)
                .WithMany(x => x.PedidosProdutos)
                .HasForeignKey(x => x.PedidoId);
        }
    }
}