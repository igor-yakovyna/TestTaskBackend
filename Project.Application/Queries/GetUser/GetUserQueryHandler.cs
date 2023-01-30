using AutoMapper;
using Project.Application.Common.Models;
using Project.Application.Common.Queries;
using Project.Application.Contracts.Persistence;
using Project.Domain.Entities;

namespace Project.Application.Queries.GetUser;

public class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserViewModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        return _mapper.Map<User, UserViewModel>(user);
    }
}