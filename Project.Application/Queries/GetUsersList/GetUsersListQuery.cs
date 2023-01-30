using Project.Application.Common.Models;
using Project.Application.Common.Queries;

namespace Project.Application.Queries.GetUsersList;

public class GetUsersListQuery : IQuery<IEnumerable<UserViewModel>>
{
}