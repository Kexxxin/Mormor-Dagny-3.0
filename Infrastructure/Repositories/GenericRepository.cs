using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenericRepository<T>(MormorDagnyContext context) : IGenericRepository<T> where T : BaseEntity
{
    public void Add(T entity)
    {
        context.Set<T>().Add(entity);
    }
    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
    {
        var query = context.Set<T>().AsQueryable();
        query = spec.ApplyPredicate(query);
        return await query.CountAsync();
    }


    public async Task<T?> FindAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<T?> FindByIdAsync(string id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void Update(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
    }
    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationValuator<T>.CreateQuery(context.Set<T>().AsQueryable(), spec);
    }
}
