using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserDal : EfEntityRepositoryBase<User, int, RentACarContext>, IUserDal
{
    private readonly RentACarContext _context;
    public EfUserDal(RentACarContext context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<UserRoles> GetUserRolesByUserId(int userId)
    {
        return _context.UserRoles
              .Include(a=> a.Role)
              .Where(a => a.UserId == userId);
    }
}