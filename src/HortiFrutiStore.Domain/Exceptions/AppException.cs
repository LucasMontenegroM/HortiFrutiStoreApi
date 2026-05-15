namespace HortiFrutiStore.Domain.Exceptions;

public class AppException : Exception
{
    public IReadOnlyList<string> Erros { get; }

    public AppException(IEnumerable<string> erros)
        : base("Um ou mais erros de validação ocorreram.")
    {
        Erros = erros.ToList();
    }

    public AppException(string erro)
        : base(erro)
    {
        Erros = [erro];
    }
}
