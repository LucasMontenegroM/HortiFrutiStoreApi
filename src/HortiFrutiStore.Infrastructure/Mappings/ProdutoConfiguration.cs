using HortiFrutiStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HortiFrutiStore.Infrastructure.Mappings;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome).IsRequired().HasMaxLength(255);

        builder.OwnsOne(p => p.Preco, preco =>
        {
            preco.Property(p => p.ValorBase).HasColumnName("ValorBase");
            preco.Property(p => p.Desconto).HasColumnName("Desconto");
            preco.Ignore(p => p.ValorFinal);
        });
    }
}