using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

namespace RepositoryDB
{
    public class RepositoryBase<T>  where T :DbContext,new()
    {
        private T _context;
        public virtual T DataContext
        {
            get { return _context ?? (_context = new T()); }
        }
        public virtual IQueryable<TEntity> GetList<TEntity>(Expression<Func<TEntity,bool>> predicate) where TEntity : class
        {
            return DataContext.Set<TEntity>().Where(predicate);
        }
       
    }
}
