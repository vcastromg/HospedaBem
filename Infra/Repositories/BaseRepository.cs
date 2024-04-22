namespace Infra.Repositories;

public interface BaseRepository<T> where T: class
{
    IEnumerable<T> GetAll();
    T? GetById(object id);
    void Add(T entity);
    void Update(T entity);
    void Delete(object id);
    IQueryable<T> Query();
}