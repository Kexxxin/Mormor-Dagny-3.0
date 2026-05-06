using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class GenericRepository<T>(MormorDagnyContext context) : IGenericRepository<T> where T : BaseEntity
{
    public void add(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsync(ISpecification<T> spec)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T?> FindAsync(ISpecification<T> spec)
    {
        throw new NotImplementedException();
    }

    public Task<T?> FindByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveAllAsync()
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
