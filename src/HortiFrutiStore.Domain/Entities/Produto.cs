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
        Validar();
        Nome = nome;
        Preco = preco;
    }

    private void Validar()
    {
        if (string.IsNullOrEmpty(Nome))
            throw new DomainException("O Nome não pode ser um valor vazio.");
        if (Preco.ValorFinal <= 0)
            throw new DomainException("O preço deve ser um valor positivo.");
    }

    public Produto Criar(string nome, Preco preco)
    {
       return new Produto(nome, preco);
    }
        
    public void AtualizarNome(string novoNome)
    {
        Nome = novoNome;
        Validar();
    }
}
