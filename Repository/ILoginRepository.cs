using LoanManagementSystem.Models;

namespace LoanManagementSystem.Repository
{
    public interface ILoginRepository
    {
        Task<User> ValidateUser(string username, string password);
    }
}
