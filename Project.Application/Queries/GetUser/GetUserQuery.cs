using Project.Application.Common.Models;
using Project.Application.Common.Queries;

namespace Project.Application.Queries.GetUser;

public class GetUserQuery : IQuery<UserViewModel>
{
    public Guid UserId { get; set; }
}