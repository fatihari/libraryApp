using System.Linq.Expressions;

namespace LibraryApp.Business.Abstract
{
    public interface IService<TEntity> where TEntity:class //   The part with the controlling methods is the services.
    {
        //  It is exactly the same as the methods in IRepository. 
        //  The reason we don't inherit is to change the "repository" interface when we switch from MSSQL to Oracle. 

        Task<TEntity> GetByIdAsync(int id); //  Returns the relevant one entity. It doesn't list models that depend on that entity!
        Task<IEnumerable<TEntity>> GetAllAsync();   //  list instance-s
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate); //    list instance-s by "where" condition i.e : 
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate); //list one instance by "where" condition i.e : Find(x=>x.title="..")
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity); // remove is not async, so it does not has "Task" class
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
    }
}