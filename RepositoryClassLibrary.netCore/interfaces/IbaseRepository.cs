using RepositoryClassLibrary.netCore.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryClassLibrary.netCore.interfaces
{
    public interface IBaseRepository<T>  where T: class
    {
        T GetById(int id);
        Task< T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
         
        T Find(Expression<Func<T,bool>>match,string[] Includes =null);
        IEnumerable<T> FindAll(Expression<Func<T,bool>>match,string[] Includes =null);
        IEnumerable<T> FindAll(Expression<Func<T,bool>>match,int skip,int take);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? skip, int? take,
          Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);
        T Add(T entity);
        Task<T> AddAsync(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        T Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T>entities);
        void Attach(T entity);
        int count();
        int count(Expression<Func<T,bool>>match);




    }
}
