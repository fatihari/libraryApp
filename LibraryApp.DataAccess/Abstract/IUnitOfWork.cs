namespace LibraryApp.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        /*  
        *   If we do not say commit or saveChange, it will not be sent to the database. 
        *   When we say commit, it is sent to the db! :) (As like GitHub)  
        *   If there is a problem in insert, update, we need to rollback all transactions.
        *   UnitOfWork provides great convenience to avoid this cost.   
        */
         public IAuthorDal Authors { get; } // Dependency Injection
         public IBookDal Books { get; }     // Dependency Injection
         Task CommitAsycnc();
         void Commit();
    }
}