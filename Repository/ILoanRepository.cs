using LoanManagementSystem.Models;

namespace LoanManagementSystem.Repository
{
    public class ILoanRepository
    {
        Task<Loan> GetLoanByIdAsync(int loanId);
        Task<IEnumerable<Loan>> GetAllLoansAsync();
        Task<Loan> CreateLoanAsync(Loan loan);
        Task UpdateLoanAsync(Loan loan);
        Task DeleteLoanAsync(int loanId);

    }
}
