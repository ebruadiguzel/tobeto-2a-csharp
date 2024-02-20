using Business.Requests.Users;
using FluentValidation;

namespace Business.Profiles.Validation.FluentValidation.Users;

public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
{
    public AddUserRequestValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6).MaximumLength(15);
    }
}