using Business.Requests.Customers;
using FluentValidation;

namespace Business.Profiles.Validation.FluentValidation.Customers;

public class AddCustomersRequestValidator : AbstractValidator<AddCustomersRequest>
{
    public AddCustomersRequestValidator()
    {
        RuleFor(a => a.UserId).GreaterThan(0);
    }
}