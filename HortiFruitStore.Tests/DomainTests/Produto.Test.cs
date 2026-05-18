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

    public static IEnumerable<object?[]> NomesInvalidos =>
    [
        ["", 10.0, null],
        [" ", 10.0, null],
        [new string('a', 256), 10.0, null],
        [new string('a', 300), 10.0, null],
    ];

    public static IEnumerable<object?[]> PrecosInvalidos =>
    [
        ["Banana", -1.0, null],
        ["Banana", 0.0, null],
    ];

    public static IEnumerable<object?[]> DescontosInvalidos =>
    [
        ["Banana", 10.0, 1.0],
        ["Banana", 10.0, 1.5],
        ["Banana", 10.0, -0.1],
    ];

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
    [DynamicData(nameof(NomesInvalidos))]
    public void CriarNomeInvalido_DeveRetornarErro(string nome, double preco, double? desconto)
    {
        var produto = Produto.Criar(nome, (decimal)preco, desconto.HasValue ? (decimal?)desconto : null);

        var resultado = _validator.TestValidate(produto);

        resultado.ShouldHaveValidationErrorFor(p => p.Nome);
    }

    [TestMethod]
    [DynamicData(nameof(PrecosInvalidos))]
    public void AtualizarPrecoInvalido_DeveRetornarErro(string nome, double preco, double? desconto)
    {
        var produto = Produto.Criar(nome, (decimal)preco, desconto.HasValue ? (decimal?)desconto : null);

        var resultado = _validator.TestValidate(produto);

        resultado.ShouldHaveValidationErrorFor(p => p.Preco.ValorBase);
    }

    [TestMethod]
    [DynamicData(nameof(DescontosInvalidos))]
    public void AtualizarDescontoAcimaDeUmOuAbaixoDeZero_DeveRetornarErro(string nome, double preco, double desconto)
    {
        var produto = Produto.Criar(nome, (decimal)preco, (decimal)desconto);

        var resultado = _validator.TestValidate(produto);

        resultado.ShouldHaveValidationErrorFor(p => p.Preco.Desconto);
    }

    [TestMethod]
    public void AtualizarComNomeValido_DeveRetornarSucesso()
    {
        var produto = Produto.Criar("Maçã", 20m, 0.5m);
        produto.AtualizarNome("Laranja");

        var resultado = _validator.TestValidate(produto);

        resultado.ShouldNotHaveAnyValidationErrors();
    }

    [TestMethod]
    public void AtualizarPrecoDeProdutoValido_DeveRetornarPrecoCorreto()
    {
        var produto = Produto.Criar("Maçã", 20m, 0.5m);
        produto.Preco.AtualizarValorBase(10.0m);

        var resultado = _validator.TestValidate(produto);

        resultado.ShouldNotHaveAnyValidationErrors();
    }
}
