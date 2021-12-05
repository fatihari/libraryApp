using System.Linq.Expressions;
using LibraryApp.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Concrete.EFCore
{
    // With "where" I provided the requirement that TEntity be a class.
    public class EfCoreRepository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        // When I implement it, all the following classes will be automatically inherited. 

        protected readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EfCoreRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        // async and await keyword are the basic 2 keywords in asynchronous programming 

        /*
        *   When you think of "async" programming, what comes to your mind is not the creation of new threads, 
        *   but the ability to continue other jobs that are not dependent on the outcome of a long job without waiting for the end of a long job.
        *   If there are jobs that are dependent on it, it should be able to add it to work in the continuation of the expected job.
        */

        // The concept of "Task" here represents a task with a state, but they have a more general representation.

        /* 
         * Commands that will run asynchronously in a method marked async are marked with await. 
         * The return type of the method marked async; It must be of void, Task or Task<T> return types. 
         * await; It can only be used on methods marked async. 
         * A method marked with async can use more than one await.
         * If you want to implement an asynchronous approach in your own methods with the async and await keywords, you should not forget the Task class..
         * Corresponds to the Task: void method in async.
        */
        
        /*
         * Insert task will be performed asynchronously. So if there is an idle Thread; task added to the queue(Task),
         * immediately starts working on the idle Thread.
         * If there is no empty Thread in the Threadpool, all threads in the thread pool are busy,
         * Tasks in the queue are applied and run on Threads whose job is finished last...
         */

        // Advantages of using Tasks:
         /*
         * CPU will be used efficiently and codes will not be blocked unnecessarily.
         * Transactions response times as transactions do not have to wait for each other,
         * or the working time of the methods will be shortened.
         */
        public async Task AddAsync(TEntity entity)
        {
           // await: We are saying wait on this line until the method I will write from now on is finished.
            await _dbSet.AddAsync(entity);
        }

        
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        //book.where(b=>b.name="book"
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public ValueTask<TEntity> GetByIdAsync(int id)
        {
            return _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        //  Predicate vs Function delegates and also events will be investigated  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Delegates point to methods, they don't say delegates for nothing. Delegates indicate what method structure it will have.
        // Give a method that returns an entity that returns bool.
        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.SingleOrDefaultAsync(predicate);
        }
        public TEntity Update(TEntity entity) 
        {
            _context.Entry(entity).State = EntityState.Modified;

            // If we want it to have some performance, it needs to be done one by one.
            // Disadvantage of the batch update above: while projecting a single property to the db, 
            // the sql query will be sending a query to update all columns.
            // This performance loss can be ignored rather than writing entire columns.

            // Or one by one:
            // entity.name = music.name
            // entity.ArtistId = music.ArtistId.

            return entity;
    
        }

        Task<TEntity> IRepository<TEntity>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}