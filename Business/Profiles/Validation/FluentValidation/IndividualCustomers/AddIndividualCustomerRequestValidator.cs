using Business.Requests.IndividualCustomer;
using FluentValidation;

namespace Business.Profiles.Validation.FluentValidation.IndividualCustomers;

public class AddIndividualCustomerRequestValidator : AbstractValidator<AddIndividualCustomerRequest>
{
    public AddIndividualCustomerRequestValidator()
    {
        
    }
}