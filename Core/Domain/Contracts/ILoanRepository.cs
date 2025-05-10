using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Contracts
{
    public interface ILoanRepository
    {
        public Task<IEnumerable<Loan>> GetBarrowedLoansByUserIdAsync(string userId);

        public Task<IEnumerable<Loan>> GetLendedLoansByUserIdAsync(string userId);

        public Task<Loan?> GetLoanByIdAsync(Guid id); 
        public Task<Loan> AddLoanAsync(Loan loan);
        public Task UpdateLoan(Loan loan);

        public Task<decimal> GetTotalAmountOfBorrowedLoansByUserIdAsync(string userId);
        public Task<decimal> GetTotalAmountOfLendedLoansByUserIdAsync(string userId);

        public Task<int> GetPendingLoansCountByUserIdAsync(string userId);
    }
}
