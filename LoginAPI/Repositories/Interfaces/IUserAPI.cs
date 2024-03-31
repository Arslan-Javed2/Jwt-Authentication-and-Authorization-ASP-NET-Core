using LoginAPI.Models;

namespace LoginAPI.Repositories.Interfaces
{
    public interface IUserAPI:IDisposable
    {
        Task<string> GetName();
        Task<List<Users>> GetUsersData();
        Task<Users> GetUsersDataById(int id);
        Task<string> GetUsersDataByUserNameAndPassword(string userName,string password);
        Task<string> CreateUser(Users users);
    }
}
