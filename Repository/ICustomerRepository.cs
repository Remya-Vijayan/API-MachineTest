using LoanManagementSystem.Models;

namespace LoanManagementSystem.Repository
{
    public interface ICustomerRepository
    {
        Task<Loan> ApplyForLoanAsync(Loan loan);

        Task<IEnumerable<Loan>> GetLoanRequestsByUserIdAsync(int userId);


        Task<IEnumerable<Help>> GetHelpSectionAsync();

        Task<Feedback> AddFeedbackAsync(Feedback feedback);
    }
}
