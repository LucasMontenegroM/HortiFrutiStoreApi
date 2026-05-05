using HortiFrutiStore.Application.DTOs;
using HortiFrutiStore.Application.Services.Interfaces;
using HortiFrutiStore.Domain.Entities;
using HortiFrutiStore.Domain.Interfaces;
using System.Runtime.CompilerServices;

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
    public async Task<ProdutoDto> BuscarPorId(Guid id, CancellationToken ct)
    {
        Produto? entidade = await _produtoRepository.BuscarPorId(id);
        var dto = new ProdutoDto();

        if(entidade != null)
        {
            dto.Map(dto, entidade);
        }

        return dto;
    }

    public Task<List<ProdutoDto>> BuscarTodos(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task CommitAsync()
    {
        throw new NotImplementedException();
    }

    public void Criar(ProdutoDto produto)
    {
        throw new NotImplementedException();
    }

    public Task Remover(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
