namespace HortiFrutiStore.Domain.ObjetosDeValor;

public class Preco
{
    public decimal ValorFinal => CalculaValorDesconto(ValorBase, Desconto);
    public decimal ValorBase { get; protected set; }
    public decimal? Desconto { get; protected set; }

    protected Preco() { }

    public Preco(decimal valorBase, decimal? desconto)
    {
        ValorBase = valorBase;
        Desconto = desconto;
    }

    public decimal CalculaValorDesconto(decimal valorBase, decimal? desconto)
    {
        decimal valorDesconto = (valorBase * desconto) ?? 0;
        return valorBase - valorDesconto;       
    }

    public void AtualizarValorBase(decimal novoValorBase)
        => ValorBase = novoValorBase;

    public void AtualizarDesconto(decimal novoDesconto)
        => Desconto = novoDesconto;
}
