using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfIndividualCustomerDalDal : IIndividualCustomerDal
{
    private readonly RentACarContext _context;

    public EfIndividualCustomerDalDal(RentACarContext context)
    {
        _context = context;
    }
    
    public IList<IndividualCustomer> GetList(Func<IndividualCustomer, bool> predicate = null)
    {
        IQueryable<IndividualCustomer> query = _context.Set<IndividualCustomer>();

        if (predicate != null)
            query = query.Where(predicate).AsQueryable();

        return query.ToList();
    }

    public IndividualCustomer Get(Func<IndividualCustomer, bool> predicate)
    {
        IndividualCustomer? individualCustomer = _context.IndividualCustomer.FirstOrDefault(predicate);
        
        return individualCustomer;
    }

    public IndividualCustomer Add(IndividualCustomer entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        _context.IndividualCustomer.Add(entity);
        _context.SaveChanges();

        return entity;
    }

    public IndividualCustomer Update(IndividualCustomer entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        _context.IndividualCustomer.Update(entity);
        _context.SaveChanges();

        return entity;
    }

    public IndividualCustomer Delete(IndividualCustomer entity, bool isSoftDelete = true)
    {
        entity.DeletedAt = DateTime.UtcNow;

        if (!isSoftDelete)
            _context.IndividualCustomer.Remove(entity);

        _context.SaveChanges();

        return entity;
    }
}