using System.Linq.Expressions;
using LibraryApp.Business.Abstract;
using LibraryApp.DataAccess;
using LibraryApp.DataAccess.Abstract;
using LibraryApp.Entities;

namespace LibraryApp.Business.Concrete
{
    //  The Service layer (Business) will communicate with the controller in the API. 
    public class AuthorManager : Manager<Author>, IAuthorService
    {
        public AuthorManager(IUnitOfWork unitOfWork, IRepository<Author> repository) : base(unitOfWork, repository)
        {
        }
        public async Task<Author> GetWithBooksByIdAsync(int authorId)
        {
            return await _unitOfWork.Authors.GetWithBooksByIdAsync(authorId);
        }
    }
}