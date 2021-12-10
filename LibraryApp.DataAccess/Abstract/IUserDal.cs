using LibraryApp.Entities;

namespace LibraryApp.DataAccess.Abstract
{
    public interface IUserDal
    {
        Task<User> Authenticate(string username, string password);
        Task<User> Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetWithUsersByIdAsync(int id);
    }
}