using MediatR;

namespace Project.Application.Common.Commands;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
    Guid Id { get; }
}