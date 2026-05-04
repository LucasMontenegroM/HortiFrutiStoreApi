namespace HortiFrutiStore.Domain.ObjetosDeValor;

public class Preco
{
    public decimal ValorFinal
    {
        get; private set => CalculaValorDesconto(ValorBase, Desconto);
    }
    public decimal ValorBase { get; private set; }
    public decimal? Desconto { get; private set; }

    private decimal CalculaValorDesconto(decimal valorBase, decimal? desconto)
    {
        if (desconto == null)
            return valorBase;
        var valorDescontado = valorBase / (decimal)desconto;
        return valorBase - valorDescontado;
    }

    public void AtualizarPreco(decimal novoValorBase)
        => ValorFinal = CalculaValorDesconto(novoValorBase, Desconto);
    

    public void AtualizarDesconto(decimal novoDesconto)
        => Desconto = novoDesconto;
}
