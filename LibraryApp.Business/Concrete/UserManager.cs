using LibraryApp.Business.Abstract;
using LibraryApp.DataAccess.Abstract;
using LibraryApp.Entities;

namespace LibraryApp.Business.Concrete
{
    public class UserManager : IUserService
    {
        
        private readonly IUnitOfWork _unitOfWork;
        public UserManager(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            return await _unitOfWork.Users.Authenticate(username, password);
        }

        public async Task<User> Create(User user, string password)
        {
            await _unitOfWork.Users.Create(user, password);

            await _unitOfWork.CommitAsycnc();
            return user;
        }

        public void Delete(int id)
        {
            _unitOfWork.Users.Delete(id);
            _unitOfWork.CommitAsycnc();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _unitOfWork.Users.GetAllUserAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _unitOfWork.Users.GetWithUsersByIdAsync(id);
        }

        public void Update(User user, string password = null)
        {
            _unitOfWork.Users.Update(user, password);
            _unitOfWork.CommitAsycnc();
        }

    }
}