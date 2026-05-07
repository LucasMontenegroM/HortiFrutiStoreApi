using HortiFrutiStore.Application.DTOs;
using HortiFrutiStore.Application.Services.Interfaces;
using HortiFrutiStore.Domain.Entities;
using HortiFrutiStore.Domain.Exceptions;
using HortiFrutiStore.Domain.Interfaces;

namespace HortiFrutiStore.Application.Services;

public class ProdutoService : IProdutoService, IUnitOfWork
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IUnitOfWork _unitOfWork;
    public ProdutoService(IProdutoRepository produtoRepository, IUnitOfWork unitOfWork)
    {
        _produtoRepository = produtoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AlterarNome(Guid id, string novoNome, CancellationToken ct)
    {
        var produtoEntity = await _produtoRepository.BuscarPorId(id, ct)
            ?? throw new NotFoundException("Houve um problema ao buscar o produto.");

        produtoEntity.AtualizarNome(novoNome);

        _produtoRepository.Atualizar(produtoEntity);

        await _unitOfWork.CommitAsync(ct);
    }

    public async Task AlterarPreco(Guid id, decimal novoPreco, CancellationToken ct)
    {
        var entidade = await _produtoRepository.BuscarPorId(id, ct) 
            ?? throw new NotFoundException("Houve um problema ao buscar o produto.");

        entidade.Preco.AtualizarPreco(novoPreco);
    }

    public async Task AplicarDesconto(Guid id, decimal novoDesconto, CancellationToken ct)
    {
        var entidade = await _produtoRepository.BuscarPorId(id, ct)
            ?? throw new NotFoundException("Houve um problema ao buscar o produto.");

        entidade.Preco.AtualizarDesconto(novoDesconto);

        _produtoRepository.Atualizar(entidade);

        await _unitOfWork.CommitAsync(ct);
    }

    public async Task<ProdutoDto> BuscarPorId(Guid id, CancellationToken ct)
    {
        try
        {
            Produto? entidade = await _produtoRepository.BuscarPorId(id)
                ?? throw new NotFoundException("Id do produto não foi encontrado");

            var dto = ProdutoDto.Map(entidade);

            return dto;
        }

        catch (Exception ex)
        {
            throw new Exception("Ocorreu um erro ao realizar a busca: " + ex.Message);
        }
    }

    public async Task<List<ProdutoDto>> BuscarTodos(CancellationToken ct)
    {
        var produtosEntity = await _produtoRepository.BuscarTodos()
            ?? throw new NotFoundException("Id do produto não foi encontrado");
        var listaDto = produtosEntity.Select(ProdutoDto.Map).ToList();

        return listaDto;
    }

    public Task CommitAsync(CancellationToken ct)
        => _unitOfWork.CommitAsync(ct);

    public async Task<ProdutoDto> Criar(ProdutoDto produto, CancellationToken ct)
    {
        var novoProdutoEntity = Produto.Criar(produto.Nome, produto.PrecoBase, produto.Desconto);

        var produtoDtoRetorno = ProdutoDto.Map(novoProdutoEntity);

        _produtoRepository.Adicionar(novoProdutoEntity);

        await _unitOfWork.CommitAsync(ct);

        return produtoDtoRetorno;
    }

    public async Task Remover(Guid id, CancellationToken ct)
    {
        var produtoEntity = await _produtoRepository.BuscarPorId(id)
            ?? throw new NotFoundException("Id do produto não foi encontrado");

            _produtoRepository.Remover(produtoEntity);

        await _unitOfWork.CommitAsync(ct);
    }
}
