using DataAccess.Abstract;

namespace Business.BusinessRules;

public class UsersBusinessRules
{
    private readonly IUsersDal _usersDal;

    public UsersBusinessRules(IUsersDal usersDal)
    {
        _usersDal = usersDal;
    }

}