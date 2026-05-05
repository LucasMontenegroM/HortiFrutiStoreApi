using HortiFrutiStore.Domain.Entities;
using System.Reflection.Metadata.Ecma335;

namespace HortiFrutiStore.Application.DTOs;

public class ProdutoDto
{
    public string Nome { get; set; } = default!;
    public decimal PrecoFinal { get; set; }

    public void Map(ProdutoDto dto, Produto entidade)
    {
        dto.Nome = entidade.Nome;
        dto.PrecoFinal = entidade.Preco.ValorBase;
    }
}