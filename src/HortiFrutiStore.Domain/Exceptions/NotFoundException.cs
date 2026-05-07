namespace HortiFrutiStore.Domain.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}

public sealed class NotFoundException<Entity> : NotFoundException
{
    public NotFoundException(object id)
        : base($"~Entidade com id '{id}' não foi encontrada.")
    {
    }
}
