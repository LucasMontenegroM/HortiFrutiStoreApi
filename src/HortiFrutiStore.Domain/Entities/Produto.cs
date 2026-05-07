using HortiFrutiStore.Domain.Abstracoes;
using HortiFrutiStore.Domain.Exceptions;
using HortiFrutiStore.Domain.ObjetosDeValor;

namespace HortiFrutiStore.Domain.Entities;

public class Produto : Entity
{
    public string Nome { get; private set; } = default!;
    public Preco Preco { get; private set; } = null!;
    protected Produto() { }
    private Produto(string nome, Preco preco) 
    {
        Nome = nome;
        Preco = preco;
        Validar();
    }

    private void Validar()
    {
        if (string.IsNullOrEmpty(Nome))
            throw new DomainException("O Nome não pode ser um valor vazio.");
        if (Preco.ValorFinal <= 0)
            throw new DomainException("O preço pós desconto deve ser um valor positivo maior que zero.");
        if (Preco.ValorBase <= 0)
            throw new DomainException("O Preço base de um produto deve ser maior que 0");
        if (Preco.Desconto >= 0 || Preco.Desconto <= 1)
            throw new DomainException("O desconto deve ser um número entre 0 e 1");
    }

    public static Produto Criar(string nome, decimal precoInicial)
    {
       var preco = new Preco(precoInicial);
       return new Produto(nome, preco);
    }
        
    public void AtualizarNome(string novoNome)
    {
        Nome = novoNome;
        Validar();
    }
}
