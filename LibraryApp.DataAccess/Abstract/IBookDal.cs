namespace LibraryApp.DataAccess.Abstract
{
    public interface IBookDal : IRepository<Book>
    {
        //  Let it list the "book" with that "id" and return the "author" of the book.
         Task<Book> GetWithAuthorByIdAsync(int bookId); //It can also be defined as  "Book GetWithAuthorByIdAsync(int id);"
    }
}