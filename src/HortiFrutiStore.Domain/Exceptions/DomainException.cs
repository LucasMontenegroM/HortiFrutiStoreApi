namespace HortiFrutiStore.Domain.Exceptions;

public class DomainException : Exception
{
    public IReadOnlyList<string> Erros { get; }

    public DomainException(IEnumerable<string> erros)
        : base("Um ou mais erros de validação ocorreram.")
    {
        Erros = erros.ToList();
    }

    public DomainException(string erro)
        : base(erro)
    {
        Erros = [erro];
    }
}
