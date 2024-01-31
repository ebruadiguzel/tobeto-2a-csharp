namespace Business.Requests.IndividualCustomer;

public class UpdateIndividualCustomerRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }
}