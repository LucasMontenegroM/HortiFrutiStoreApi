using FluentValidation;
using HortiFrutiStore.Domain.Abstracoes;
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
    }

    public static Produto Criar(string nome, decimal precoInicial, decimal? desconto)
    {
       var preco = new Preco(precoInicial, desconto);
       return new Produto(nome, preco);
    }
        
    public void AtualizarNome(string novoNome)
    {
        Nome = novoNome;
    }

    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotNull().WithMessage("O nome do produto é obrigatório.")
                .NotEmpty().WithMessage("O nome do produto não pode ser vazio.");

            RuleFor(p => p.Nome)
                .Length(1, 255).WithMessage("O nome do produto deve ter entre 1 e 255 caracteres.");

            RuleFor(p => p.Preco.ValorFinal)
                .NotNull().WithMessage("O valor final do produto é obrigatório.")
                .NotEmpty().WithMessage("O valor final do produto não pode ser vazio.")
                .GreaterThan(0).WithMessage("O valor final do produto deve ser maior que zero.");

            RuleFor(p => p.Preco.ValorBase)
                .NotNull().WithMessage("O valor base do produto é obrigatório.")
                .NotEmpty().WithMessage("O valor base do produto não pode ser vazio.")
                .GreaterThan(0).WithMessage("O valor base do produto deve ser maior que zero.");

            RuleFor(p => p.Preco.Desconto)
                .GreaterThanOrEqualTo(0).WithMessage("O desconto não pode ser negativo.")
                .LessThan(1).WithMessage("O desconto deve ser menor que 100% (0 até 1 em decimal).")
                .When(p => p.Preco.Desconto.HasValue);
        }
    }
}
