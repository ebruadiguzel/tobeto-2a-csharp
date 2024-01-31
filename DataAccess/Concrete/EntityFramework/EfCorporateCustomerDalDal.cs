using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfCorporateCustomerDalDal : ICorporateCustomerDal
{
    private readonly RentACarContext _context;

    public EfCorporateCustomerDalDal(RentACarContext context)
    {
        _context = context;
    }
    public IList<CorporateCustomer> GetList(Func<CorporateCustomer, bool> predicate = null)
    {
        IQueryable<CorporateCustomer> query = _context.Set<CorporateCustomer>();

        if (predicate != null)
            query = query.Where(predicate).AsQueryable();

        return query.ToList();
    }

    public CorporateCustomer Get(Func<CorporateCustomer, bool> predicate)
    {
        CorporateCustomer? corporateCustomer = _context.CorporateCustomer.FirstOrDefault(predicate);
        
        return corporateCustomer;
    }

    public CorporateCustomer Add(CorporateCustomer entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        _context.CorporateCustomer.Add(entity);
        _context.SaveChanges();

        return entity;
    }

    public CorporateCustomer Update(CorporateCustomer entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        _context.CorporateCustomer.Update(entity);
        _context.SaveChanges();

        return entity;
    }

    public CorporateCustomer Delete(CorporateCustomer entity, bool isSoftDelete = true)
    {
        entity.DeletedAt = DateTime.UtcNow;

        if (!isSoftDelete)
            _context.CorporateCustomer.Remove(entity);

        _context.SaveChanges();

        return entity;
    }
}