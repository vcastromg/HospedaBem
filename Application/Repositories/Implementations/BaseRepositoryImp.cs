using Infra;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Implementations;

public class BaseRepositoryImp<T>: BaseRepository<T> where T: class
{
    private ApplicationDbContext _applicationDbContext;
    private DbSet<T> _table = null;
    
    public BaseRepositoryImp(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        _table = _applicationDbContext.Set<T>();
    }
    
    public IEnumerable<T> GetAll()
    {
        return _table.ToList();
    }

    public T? GetById(object id)
    {
        return _table.Find(id);
    }

    public void Add(T entity)
    {
        _table.Add(entity);
        _applicationDbContext.SaveChanges();
    }

    public void Update(T entity)
    {
        _table.Attach(entity);
        _applicationDbContext.Entry(entity).State = EntityState.Modified;
        _applicationDbContext.SaveChanges();
    }

    public void Delete(object id)
    {
        var entity = _table.Find(id);
        _applicationDbContext.Remove(entity);
        _applicationDbContext.SaveChanges();
    }

    public IQueryable<T> Query()
    {
        return _table.AsNoTracking().AsQueryable();
    }
}