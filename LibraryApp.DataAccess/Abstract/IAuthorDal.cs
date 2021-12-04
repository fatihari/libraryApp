namespace LibraryApp.DataAccess.Abstract
{
    public interface IAuthorDal : IRepository<Author>
    {
        //  Let it list the "author" with that "id" and return the "books" of the author.        
        Task<Author> GetWithBooksByIdAsync(int id); //It can also be defined as  "Author GetWithBooksByIdAsync(int id);"
        Task<IEnumerable<Author>> GetAllWithBooksAsync();
        
    }
}