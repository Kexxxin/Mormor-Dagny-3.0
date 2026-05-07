using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class SpecificationValuator<T> where T : BaseEntity
{
    public static IQueryable<T> CreateQuery(IQueryable<T> query, ISpecification<T> spec)
    {
        if (spec.Predicate is not null)
        {
            query = query.Where(spec.Predicate);
        }

        if (spec.OrderByAscending is not null)
        {
            query = query.OrderBy(spec.OrderByAscending);
        }

        if (spec.OrderByDescending is not null)
        {
            query = query.OrderBy(spec.OrderByDescending);
        }

        if (spec.IsPaginationActivated)
        {
            query = query.Skip(spec.Skip).Take(spec.Take);
        }

        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

        query = spec.NestedIncludes.Aggregate(query, (current, include) =>
            current.Include(include));
        return query;
    }

}
