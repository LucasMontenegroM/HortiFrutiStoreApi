namespace HortiFrutiStore.Domain.ObjetosDeValor;

public class Preco
{
    public decimal ValorFinal { get; protected set; }
    public decimal ValorBase { get; protected set; }
    public decimal? Desconto { get; protected set; }

    protected Preco() { }

    public Preco(decimal valorBase, decimal? desconto)
    {
        ValorBase = valorBase;
        Desconto = desconto;
        ValorFinal = CalculaValorDesconto(valorBase, desconto);
    }

    public decimal CalculaValorDesconto(decimal valorBase, decimal? desconto)
    {
        decimal valorDesconto = (valorBase * desconto) ?? 0;
        return valorBase - valorDesconto;       
    }

    public void AtualizarPreco(decimal novoValorBase)
        => ValorFinal = CalculaValorDesconto(novoValorBase, Desconto);

    public void AtualizarDesconto(decimal novoDesconto)
        => Desconto = novoDesconto;
}
