using DataAccess.Abstract;

namespace Business.BusinessRules;

public class UserBusinessRules
{
    private readonly IUserDal _usersDal;

    public UserBusinessRules(IUserDal usersDal)
    {
        _usersDal = usersDal;
    }

}