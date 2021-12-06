using LibraryApp.Entities;

namespace LibraryApp.Business.Abstract
{
    public interface IAuthorService : IService<Author> //   The part with the controlling methods is the services.
    {
        //  Let it list the "author" with that "id" and return the "books" of the author.        
        Task<Author> GetWithBooksByIdAsync(int authorId); //It can also be defined as  "Author GetWithBooksByIdAsync(int id);"
    }
}