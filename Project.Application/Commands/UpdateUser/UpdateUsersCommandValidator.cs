using FluentValidation;
using Project.Application.Common.Models;

namespace Project.Application.Commands.UpdateUser;

public class UpdateUsersCommandValidator : AbstractValidator<UpdateUsersCommand>
{
    public UpdateUsersCommandValidator()
    {
        RuleForEach(e => e.Users)
            .SetValidator(new UserViewModelValidator());
    }
}