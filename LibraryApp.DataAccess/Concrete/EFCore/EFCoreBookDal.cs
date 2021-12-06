using LibraryApp.DataAccess.Abstract;
using LibraryApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Concrete.EFCore
{
    public class EFCoreBookDal : EfCoreRepository<Book>, IBookDal
    {
        private LibraryContext _libraryContext { get => _context as LibraryContext; }
        public EFCoreBookDal(LibraryContext context) : base(context)
        {
        }

        public async Task<Book> GetWithAuthorByIdAsync(int bookId)
        {
            return await _libraryContext.Books.Include(x => x.Author).SingleOrDefaultAsync(x => x.Id == bookId);
        }
    }
}