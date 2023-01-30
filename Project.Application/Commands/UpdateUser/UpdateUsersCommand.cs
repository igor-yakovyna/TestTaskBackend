using MediatR;
using Project.Application.Common.Commands;
using Project.Application.Common.Models;

namespace Project.Application.Commands.UpdateUser;

public class UpdateUsersCommand : Command<Unit>
{
    public IEnumerable<UserViewModel> Users { get; set; }
}