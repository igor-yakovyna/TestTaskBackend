using AutoMapper;
using Project.Application.Common.Models;
using Project.Application.Common.Queries;
using Project.Application.Contracts.Persistence;
using Project.Domain.Entities;

namespace Project.Application.Queries.GetUsersList;

public class GetUsersListQueryHandler : IQueryHandler<GetUsersListQuery, IEnumerable<UserViewModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersListQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<UserViewModel>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
    {
        var usersList = await _userRepository.GetAllAsync(cancellationToken);

        return _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(usersList);
    }
}