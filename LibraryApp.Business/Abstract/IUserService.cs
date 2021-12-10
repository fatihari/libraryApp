using LibraryApp.Entities;

namespace LibraryApp.Business.Abstract
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}