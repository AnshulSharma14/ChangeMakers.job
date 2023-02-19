using ChangeMakers.job.Data;
using Changemakers.job.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Changemakers.job.DataAccess.Repositories
{
    public class Repository<T>: IRepository<T> where T : class
    {
        public readonly ApplicationDbContext _context;
    internal DbSet<T> Dbset;
    public Repository(ApplicationDbContext context)
    {
        _context = context;
        this.Dbset = _context.Set<T>();
    }

    public void Add(T entity)
    {
        Dbset.Add(entity);
    }



    public T FirstORDefault(Expression<Func<T, bool>> Filter = null, string includeProperties = null)
    {

        IQueryable<T> query = Dbset;
        if (Filter != null)
        {
            query = query.Where(Filter);
        }
        if (includeProperties != null)
        {
            foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }
        return query.FirstOrDefault();
    }

    public T Get(int id)
    {
        return Dbset.Find(id);
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> Filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null, string IncludeProperties = null)
    {
        IQueryable<T> query = Dbset;
        if (Filter != null)
        {
            query = query.Where(Filter);
        }
        if (IncludeProperties != null)
        {
            foreach (var includeProp in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }
        if (OrderBy != null)
            return OrderBy(query).ToList();
        return query.ToList();
    }



    public void Remove(T entity)
    {
        Dbset.Remove(entity);
    }

    public void Remove(int id)
    {
        var entity = Dbset.Find(id);
        Dbset.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
        Dbset.RemoveRange(entity);
    }
}
}

