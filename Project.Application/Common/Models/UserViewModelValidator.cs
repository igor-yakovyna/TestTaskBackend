using FluentValidation;

namespace Project.Application.Common.Models;

public class UserViewModelValidator: AbstractValidator<UserViewModel>
{
    public UserViewModelValidator()
    {
        RuleFor(e => e.FirstName)
            .NotNull()
            .NotEmpty();

        RuleFor(e => e.LastName)
            .NotNull()
            .NotEmpty();
        
        RuleFor(e => e.DateOfBirth)
            .NotEqual(DateOnly.FromDateTime(default))
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now));
        
        RuleFor(e => e.PhoneNumber)
            .NotNull()
            .NotEmpty();
        
        RuleFor(e => e.Street)
            .NotNull()
            .NotEmpty();
        
        RuleFor(e => e.HouseNumber)
            .NotNull()
            .NotEmpty();
        
        RuleFor(e => e.Town)
            .NotNull()
            .NotEmpty();
        
        RuleFor(e => e.PostalCode)
            .NotNull()
            .NotEmpty();
    }
}