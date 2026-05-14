using FluentValidation;
using HortiFrutiStore.Application.DTOs;
using HortiFrutiStore.Application.Services.Interfaces;
using HortiFrutiStore.Domain.Entities;
using HortiFrutiStore.Domain.Exceptions;
using HortiFrutiStore.Domain.Interfaces;

namespace HortiFrutiStore.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<Produto> _validator;

    public ProdutoService(IProdutoRepository produtoRepository, IUnitOfWork unitOfWork, IValidator<Produto> validator)
    {
        _produtoRepository = produtoRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }
    public async Task AlterarNome(Guid id, string novoNome, CancellationToken ct)
    {
        var produtoEntity = await _produtoRepository.BuscarPor(p => p.Id == id, ct)
            ?? throw new NotFoundException("Produto não encontrado.");

        produtoEntity.AtualizarNome(novoNome);

        var resultado = _validator.Validate(produtoEntity);

        if (!resultado.IsValid)
            throw new DomainException(resultado.Errors.Select(e => e.ErrorMessage));

        _produtoRepository.Atualizar(produtoEntity);

        await _unitOfWork.CommitAsync(ct);
    }

    public async Task AlterarPreco(Guid id, decimal novoPreco, CancellationToken ct)
    {
        var entidade = await _produtoRepository.BuscarPor(p => p.Id == id, ct)
            ?? throw new DomainException("Produto não encontrado.");

        entidade.Preco.AtualizarValorBase(novoPreco);

        var resultado = _validator.Validate(entidade);

        if (!resultado.IsValid)
            throw new DomainException(resultado.Errors.Select(e => e.ErrorMessage));

        await _unitOfWork.CommitAsync(ct);
    }

    public async Task AplicarDesconto(Guid id, decimal novoDesconto, CancellationToken ct)
    {
        var entidade = await _produtoRepository.BuscarPor(p => p.Id == id, ct)
            ?? throw new NotFoundException("Produto não encontrado.");

        entidade.Preco.AtualizarDesconto(novoDesconto);

        _produtoRepository.Atualizar(entidade);

        await _unitOfWork.CommitAsync(ct);
    }

    public async Task<ProdutoDto> BuscarPorId(Guid id, CancellationToken ct)
    {
        var entidade = await _produtoRepository.BuscarPor(p => p.Id == id, ct)
            ?? throw new NotFoundException("Produto não encontrado.");

        return (ProdutoDto)entidade;
    }

    public async Task<List<ProdutoDto>> BuscarTodos(int numPagina, int numExibidos, CancellationToken ct)
    {
        var produtosEntity = await _produtoRepository.BuscarTodos(numPagina, numExibidos, ct)
            ?? throw new NotFoundException("Nenhum produto encontrado.");

        return produtosEntity.Select(p => (ProdutoDto)p).ToList();  
    }

    public async Task<ProdutoDto> Criar(ProdutoDto produto, CancellationToken ct)
    {
        var novoProdutoEntity = Produto.Criar(produto.Nome, produto.PrecoBase, produto.Desconto);

        var resultado = _validator.Validate(novoProdutoEntity);

        if (!resultado.IsValid)
            throw new AppException(resultado.Errors.Select(e => e.ErrorMessage));

        _produtoRepository.Adicionar(novoProdutoEntity);

        await _unitOfWork.CommitAsync(ct);

        return (ProdutoDto)novoProdutoEntity;
    }

    public async Task Remover(Guid id, CancellationToken ct)
    {
        var produtoEntity = await _produtoRepository.BuscarPor(p => p.Id == id, ct)
            ?? throw new NotFoundException("Produto não encontrado.");

        _produtoRepository.Remover(produtoEntity);

        await _unitOfWork.CommitAsync(ct);
    }
}
