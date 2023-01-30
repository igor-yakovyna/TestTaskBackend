using AutoMapper;
using MediatR;
using Project.Application.Common.Commands;
using Project.Application.Common.Models;
using Project.Application.Contracts.Persistence;
using Project.Domain.Entities;

namespace Project.Application.Commands.UpdateUser;

public class UpdateUsersCommandHandler : ICommandHandler<UpdateUsersCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUsersCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    /// <summary>
    /// Handle users update command.
    /// </summary>
    /// <param name="request">Update users data.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns><see cref="Unit"/> value witch represents a void type.</returns>
    /// <exception cref="Exception">Thrown when unexpected error occured while performing users save.</exception>
    public async Task<Unit> Handle(UpdateUsersCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userToSave = request.Users.ToList();

            var existingUsers = (await _userRepository.GetAllAsync(cancellationToken)).ToList();

            await HandleAddingNewUsers(userToSave);

            await HandleUpdateExistingUsers(userToSave, existingUsers);

            await HandleDeleteUsers(userToSave, existingUsers);

            return Unit.Value;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while handling users update.", e);
        }
    }

    private async Task HandleAddingNewUsers(List<UserViewModel> users)
    {
        if (users is null || !users.Any())
        {
            return;
        }

        var newUsers = users.Where(p => p.UserId == default).ToList();
        if (newUsers.Any())
        {
            var usersToAdd = _mapper.Map<IEnumerable<UserViewModel>, IEnumerable<User>>(newUsers);
            await _userRepository.AddRangeAsync(usersToAdd);
        }
    }

    private async Task HandleUpdateExistingUsers(List<UserViewModel> users, List<User> existingUsers)
    {
        if (users is null || !users.Any())
        {
            return;
        }

        var usersForUpdate = users.Where(p => p.UserId != default).ToList();
        if (!usersForUpdate.Any())
        {
            return;
        }

        foreach (var user in usersForUpdate)
        {
            var userToUpdate = existingUsers.FirstOrDefault(p => p.Id == user.UserId);
            if (userToUpdate is not null)
            {
                _mapper.Map(user, userToUpdate);
                await _userRepository.UpdateAsync(userToUpdate);
            }
        }
    }

    private async Task HandleDeleteUsers(List<UserViewModel> users, List<User> existingUsers)
    {
        if (existingUsers is null || !existingUsers.Any())
        {
            return;
        }

        var usersToDelete = existingUsers
            .ExceptBy(users
                .Where(p => p.UserId != default)
                .Select(s => s.UserId), s => s.Id)
            .ToList();

        if (usersToDelete.Any())
        {
            await _userRepository.DeleteRangeAsync(usersToDelete);
        }
    }
}