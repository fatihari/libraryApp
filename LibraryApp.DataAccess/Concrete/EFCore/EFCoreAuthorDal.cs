using LibraryApp.DataAccess.Abstract;
using LibraryApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Concrete.EFCore
{
    public class EFCoreAuthorDal : EfCoreRepository<Author>, IAuthorDal
    {
        private LibraryContext _libraryContext { get => _context as LibraryContext; }
        public EFCoreAuthorDal(LibraryContext context) : base(context)
        {
        }

        public async Task<Author> GetWithBooksByIdAsync(int authorId)
        {
            return await _libraryContext.Authors.Include(x => x.Books).SingleOrDefaultAsync(x => x.Id == authorId);
        }
    }
}