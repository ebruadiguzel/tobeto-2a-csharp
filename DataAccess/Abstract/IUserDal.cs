using Core.DataAccess;
using Core.Entities;

namespace DataAccess.Abstract;

public interface IUserDal : IEntityRepository<User, int>
{
    IEnumerable<UserRoles> GetUserRolesByUserId(int userId);

}