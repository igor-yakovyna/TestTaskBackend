namespace Project.Application.Common.Commands;

public abstract class Command<TResponse> : ICommand<TResponse>
{
    public Guid Id { get; }

    protected Command()
    {
        Id = Guid.NewGuid();
    }

    protected Command(Guid id)
    {
        Id = id;
    }
}