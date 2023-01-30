using MediatR;

namespace Project.Application.Common.Queries;

public interface IQueryHandler<in TRequest, TResponse> 
    : IRequestHandler<TRequest, TResponse> where TRequest : IQuery<TResponse>
{

}