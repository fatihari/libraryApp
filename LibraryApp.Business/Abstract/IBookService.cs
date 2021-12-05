using LibraryApp.Entities;

namespace LibraryApp.Business.Abstract
{
    public interface IBookService : IService<Book> //   The part with the controlling methods is the services.
    {
         //  Let it list the "book" with that "id" and return the "author" of the book.
         Task<Book> GetWithAuthorByIdAsync(int bookId); //It can also be defined as  "Book GetWithAuthorByIdAsync(int id);"
    }
}