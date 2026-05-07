using HortiFrutiStore.Domain.Entities;

namespace HortiFrutiStore.Application.DTOs;

public class ProdutoDto
{
    public string Nome { get; set; } = default!;
    public decimal PrecoBase { get; set; }
    public decimal? Desconto { get; set; }

    public static ProdutoDto Map(Produto entidade)
        => new ProdutoDto
        {
            Nome = entidade.Nome,
            PrecoBase = entidade.Preco.ValorFinal,
            Desconto = entidade.Preco.Desconto
        };
}