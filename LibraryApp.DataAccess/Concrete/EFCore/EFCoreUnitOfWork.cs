using LibraryApp.DataAccess.Abstract;

namespace LibraryApp.DataAccess.Concrete.EFCore
{
    public class EFCoreUnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;
        private IAuthorDal _iAuthorDal;
        private IBookDal _iBookDal;

        // IAuthorDal varsa => _iAuthorDal'yi ata ?? (Değilse) yeni bir IAuthorDal oluştur.
        public IAuthorDal Authors => _iAuthorDal = _iAuthorDal ?? new EFCoreAuthorDal(_context);
        public IBookDal Books => _iBookDal = _iBookDal ?? new EFCoreBookDal(_context);

        public EFCoreUnitOfWork(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsycnc()
        {
            await _context.SaveChangesAsync();
        }
    }
}