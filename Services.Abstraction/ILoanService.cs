using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Shared;

namespace Services.Abstraction
{
    public interface ILoanService
    {

        

        public Task<IEnumerable<LoanResultDto>> GetBorrowedLoansAsync(string userId);

        public Task<IEnumerable<LoanResultDto>> GetLendLoansAsync(string userId);

        public Task<LoanResultDto> GetLoanByIdAsync(Guid id);

        public Task<LoanResultDto> AddLoanAsync(AddLoanDto loan);

        public Task UpdateLoan(UpdateDto loan);

        public Task<decimal> GetTotalAmountBorrowedLoanAsync(string userId);
        public Task<decimal> GetTotalAmountLendedLoanAsync(string userId);

        public Task<int> GetPendingLoansCountAsync(string userId);
        
    }
}
