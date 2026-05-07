namespace HortiFrutiStore.Domain.ObjetosDeValor;

public class Preco
{
    public decimal ValorFinal { get; private set; }
    public decimal ValorBase { get; private set; }
    public decimal? Desconto { get; private set; }

    protected Preco() { }

    public Preco(decimal valorBase, decimal? desconto = null)
    {
        ValorBase = valorBase;
        Desconto = desconto;
        ValorFinal = CalculaValorDesconto(valorBase, desconto);
    }

    protected static decimal CalculaValorDesconto(decimal valorBase, decimal? desconto)
    {
         return valorBase * (desconto ?? 1);       
    }

    public void AtualizarPreco(decimal novoValorBase)
        => ValorFinal = CalculaValorDesconto(novoValorBase, Desconto);

    public void AtualizarDesconto(decimal novoDesconto)
        => Desconto = novoDesconto;
}
