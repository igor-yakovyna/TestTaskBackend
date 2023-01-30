using MediatR;

namespace Project.Application.Common.Queries;

public interface IQuery<out TResponse> : IRequest<TResponse>
{

}