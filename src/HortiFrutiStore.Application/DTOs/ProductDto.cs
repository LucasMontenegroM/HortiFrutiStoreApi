using HortiFrutiStore.Domain.Entities;

namespace HortiFrutiStore.Application.DTOs;

public class ProdutoDto
{
    public string Nome { get; set; } = default!;
    public decimal PrecoFinal { get; set; }
    public decimal? Desconto { get; set; }

    public static implicit operator ProdutoDto (Produto entidade)
        => new ()
        {
            Nome = entidade.Nome,
            PrecoFinal = entidade.Preco.ValorFinal,
            Desconto = entidade.Preco.Desconto
        };
}