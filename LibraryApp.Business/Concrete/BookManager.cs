using System.Linq.Expressions;
using LibraryApp.Business.Abstract;
using LibraryApp.DataAccess;
using LibraryApp.DataAccess.Abstract;
using LibraryApp.Entities;

namespace LibraryApp.Business.Concrete
{
    public class BookManager : Manager<Book>, IBookService
    {
        public BookManager(IUnitOfWork unitOfWork, IRepository<Book> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Book> GetWithAuthorByIdAsync(int bookId)
        {
            return await _unitOfWork.Books.GetWithAuthorByIdAsync(bookId);
        }
    }
}