using HortiFrutiStore.Domain.Entities;

namespace HortiFrutiStore.Application.DTOs;

public class ProdutoDto
{
    public string Nome { get; set; } = default!;
    public decimal PrecoFinal { get; set; }

    public static ProdutoDto Map(Produto entidade)
        => new ProdutoDto
        {
            Nome = entidade.Nome,
            PrecoFinal = entidade.Preco.ValorBase
        };
}