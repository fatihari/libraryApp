using System.Linq.Expressions;

namespace LibraryApp.DataAccess
{
    //  Select, insert, update, delete from a central place once. 
    //  It is applied to all tables thanks to the generics structure. 
    public interface IRepository<TEntity> where TEntity:class
    {
        Task<TEntity> GetByIdAsync(int id); //  Returns the relevant one entity. It doesn't list models that depend on that entity!
        Task<IEnumerable<TEntity>> GetAllAsync();   //  list instance-s
        Task <IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate); //    list instance-s by "where" condition i.e : 
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate); //list one instance by "where" condition i.e : Find(x=>x.title="..")
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity); // remove is not async, so it does not has "Task" class
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
    }
}