using Coding_test.Models;

namespace Coding_test.Services
{
    public interface IUserDetailsService
    {
       void AddData(UserDetail UserData);
        IEnumerable<UserDetail> GetData();

        dynamic GetUserById(int id);
    }
}
