using BlogAppMVC.Contracts;
using BlogAppMVC.Models;
using System.Linq.Expressions;

namespace BlogAppMVC.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected BlogPostMVCDbContext context;

        protected RepositoryBase(BlogPostMVCDbContext context)
        {
            this.context = context;
        }

        public void Create(T entity) => context.Set<T>().Add(entity);

        public void Delete(T entity) => context.Set<T>().Remove(entity);

        public IQueryable<T> FindAll() => context.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => context.Set<T>().Where(expression);

        public void Update(T entity) => context.Set<T>().Update(entity);
    }
}