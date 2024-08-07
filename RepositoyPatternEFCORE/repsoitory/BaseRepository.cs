using Microsoft.EntityFrameworkCore;
using RepositoryClassLibrary.netCore.Constants;
using RepositoryClassLibrary.netCore.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RepositoyPatternEFCORE.repsoitory
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        public BaseRepository(AppDbContext  appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public T Add(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
      
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
               await _appDbContext.Set<T>().AddAsync(entity);
                
            return  entity;

        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
              _appDbContext.Set<T>().AddRange(entities);

            return entities;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _appDbContext.Set<T>().AddRangeAsync(entities);

            return entities;
        }

        public void Attach(T entity)
        {
            _appDbContext.Set<T>().Attach(entity);
        }

        public int count()
        {
           return  _appDbContext.Set<T>().Count();
        }

        public int count(Expression<Func<T, bool>> match)
        {
            return _appDbContext.Set<T>().Count(match);
        }

        public void Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _appDbContext.Set<T>().RemoveRange(entities);
        }

        public T Find(Expression<Func<T, bool>> match)
        {
           return _appDbContext.Set<T>().SingleOrDefault(match);
        }

        public T Find(Expression<Func<T, bool>> match, string[] Includes = null)
        {
            IQueryable<T> query = _appDbContext.Set<T>();
            foreach(var include in Includes)
            {
                query.Include(include);
            }
            return query.SingleOrDefault(match);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] Includes = null)
        {
            IQueryable<T> quary = _appDbContext.Set<T>();
            foreach(var include in Includes)
            {
                quary.Include(include);
            }
            return quary.Where(match).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] Includes = null, int take = 0, int skip = 0)
        {
            IQueryable<T> quary = _appDbContext.Set<T>();
            foreach (var include in Includes)
            {
                quary.Include(include);
            }
            return quary.Where(match);

        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int skip, int take)
        {
            return _appDbContext.Set<T>().Where(match).Take(take).Skip(skip).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int? skip, int? take, Expression<Func<T, object>> orderBy = null
            , string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _appDbContext.Set<T>().Where(match);
            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return query.ToList();

        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? skip, int? take, Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query =  _appDbContext.Set<T>().Where(criteria);
            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }

        public IEnumerable<T> GetAll()
        {
             return _appDbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
             return _appDbContext.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
          return await _appDbContext.Set<T>().FindAsync(id);
        }

        public T Update(T entity)
        {
            _appDbContext.Update(entity);
            return entity;
        }
    }
}
