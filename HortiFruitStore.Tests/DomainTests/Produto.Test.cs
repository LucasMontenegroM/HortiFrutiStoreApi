using FluentValidation.TestHelper;
using HortiFrutiStore.Domain.Entities;
using static HortiFrutiStore.Domain.Entities.Produto;

// documentacao do fluentvalidation para os testes
// https://docs.fluentvalidation.net/en/latest/testing.html#using-testvalidate

// Se você está lendo esse arquivo eu não recomendo utilizar ele para aprender testes de unidade!

namespace HortiFruitStore.Tests.DomainTests;

[TestClass]
public class ProdutoDomainTestes()
{

    private readonly ProdutoValidator _validator = new();
    private readonly Produto _produtoExistente = Produto.Criar("Maçã", 20m, 0.5m);

    [TestMethod]
    public void CriarProdutoValido_DeveRetornarSucessoSemDesconto()
    {
        var produtoValido = Produto.Criar("Banana", 10.0m, null);

        var resultado = _validator.TestValidate(produtoValido);

        resultado.ShouldNotHaveAnyValidationErrors();
    }

    [TestMethod]
    public void CriarProdutoValido_DeveRetornarSucessoComDescontoValido()
    {
        var produtoValido = Produto.Criar("Banana", 10.0m, 0.5m);

        var resultado = _validator.TestValidate(produtoValido);

        resultado.ShouldNotHaveAnyValidationErrors();
    }

    [TestMethod]
    [DataRow("", 10.0, null)]
    [DataRow(" ", 10.0, null)]
    public void NomeVazio_DeveRetornarErro(string nome, double preco, decimal desconto)
    {
        var produto = Produto.Criar(nome, (decimal)preco, desconto);

        var resultado = _validator.TestValidate(produto);

        resultado.ShouldHaveValidationErrorFor(p => p.Nome);
    }

    [TestMethod]
    [DataRow("Banana", -1.0, null)]
    public void PrecoNegativo_DeveRetornarErro(string nome, double preco, decimal desconto)
    {
        var produto = Produto.Criar(nome, (decimal)preco, desconto);

        var resultado = _validator.TestValidate(produto);

        resultado.ShouldHaveValidationErrorFor(p => p.Preco.ValorBase);
    }

    [TestMethod]
    [DataRow("Banana", 1.1, 1.1)]
    public void DescontoAcimaDeUm_DeveRetornarErro(string nome, double preco, double desconto)
    {
        var produto = Produto.Criar("Banana", (decimal)preco, (decimal)desconto);

        var resultado = _validator.TestValidate(produto);

        resultado.ShouldHaveValidationErrorFor(p => p.Preco.Desconto);
    }

    [TestMethod]

    public void AtualizarComNomeValido_DeveRetornarSucesso()
    {
        var novoNome = "Laranja";

        _produtoExistente.AtualizarNome(novoNome);

        var resultado = _validator.TestValidate(_produtoExistente);

        resultado.ShouldNotHaveAnyValidationErrors();
    }

    [TestMethod]

    public void AtualizarComNomeVazio_DeveRetornarErro()
    {
        var novoNome = "";

        _produtoExistente.AtualizarNome(novoNome);

        var resultado = _validator.TestValidate(_produtoExistente);

        resultado.ShouldHaveValidationErrorFor(p => p.Nome);
    }

    [TestMethod]

    public void AtualizarPrecoDeProdutoValido_DeveRetornarPrecoCorreto()
    {
        var novoPreco = 10.0m;

        _produtoExistente.Preco.AtualizarValorBase(novoPreco);

        var resultado = _validator.TestValidate(_produtoExistente);

        resultado.ShouldNotHaveAnyValidationErrors();
    }

    [TestMethod]
    public void AtualizarPrecoDeProdutoInvalido_DeveRetornarErro()
    {
        var novoPreco = -10.0m;

        _produtoExistente.Preco.AtualizarValorBase(novoPreco);

        var resultado = _validator.TestValidate(_produtoExistente);

        resultado.ShouldHaveValidationErrorFor(p => p.Preco.ValorBase);
    }
}
