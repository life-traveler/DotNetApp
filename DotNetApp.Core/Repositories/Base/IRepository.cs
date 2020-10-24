using DotNetApp.Core.Entities.Base;
using DotNetApp.Core.Specification.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotNetApp.Core.Repositories.Base
{
   public  interface IRepository<T> where T: Entity
    {
        //please explain
        Task<IReadOnlyList<T>> GetAllAsync();

        //predicate : passing specific lambda exp
        // x=>x.cat
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        string includeString = null,

                                        bool disableTracking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        List<Expression<Func<T, object>>> includes = null,
                                        bool disableTracking = true);

        //Task<IReadOnlyList<T>> GetAsync(ISpecification<T> spec);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);

        //why did not we use id , isnt T  class
        Task DeleteAsync(T entity);
        //Task<int> CountAsync(ISpecification<T> spec);

        //WHAT IS THE DIFFERENCE BETWEEN TASK<T> AND TASK

    }
}
