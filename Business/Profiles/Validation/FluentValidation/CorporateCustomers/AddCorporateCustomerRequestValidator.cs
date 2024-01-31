using Business.Requests.CorporateCustomer;
using FluentValidation;

namespace Business.Profiles.Validation.FluentValidation.CorporateCustomers;

public class AddCorporateCustomerRequestValidator : AbstractValidator<AddCorporateCustomerRequest>
{
    public AddCorporateCustomerRequestValidator()
    {
    }
}