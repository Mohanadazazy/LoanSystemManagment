using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LoanSystemDbContext _context;

        public LoanRepository(LoanSystemDbContext context)
        {
            _context = context;
        }
        public async Task<Loan?> AddLoanAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            var flag = await _context.SaveChangesAsync();
            if (flag <= 0) return null;
            return await GetLoanByIdAsync(loan.Id);
            
        }

        public async Task<IEnumerable<Loan>> GetBarrowedLoansByUserIdAsync(string userId)
        {
            return await _context.Loans.Where(L => L.BorrowerId == userId).Include(L => L.Borrower).Include(L => L.Lender).ToListAsync();
        }

        public async Task<IEnumerable<Loan>> GetLendedLoansByUserIdAsync(string userId)
        {
            return await _context.Loans.Where(L => L.LenderId == userId).Include(L => L.Borrower).Include(L => L.Lender).ToListAsync();
        }

        public async Task<Loan?> GetLoanByIdAsync(Guid id)
        {
            return await _context.Loans.Where(L => L.Id == id).Include(L => L.Borrower).Include(L => L.Lender).FirstOrDefaultAsync();
        }

        public async Task<int> GetPendingLoansCountByUserIdAsync(string userId)
        {
            return await _context.Loans.Where(U => ( U.BorrowerId == userId || U.LenderId == userId) && (U.Amount != U.PaidAmount)).CountAsync();
        }

        public async Task<decimal> GetTotalAmountOfBorrowedLoansByUserIdAsync(string userId)
        {
            return await _context.Loans.Where(U => U.BorrowerId == userId).SumAsync(U => U.Amount );
        }

        public async Task<decimal> GetTotalAmountOfLendedLoansByUserIdAsync(string userId)
        {
            return await _context.Loans.Where(U => U.LenderId == userId).SumAsync(U => U.Amount);
        }

        public async Task UpdateLoan(Loan loan)
        {
           _context.Loans.Update(loan);
           await _context.SaveChangesAsync();
        }
    }
}
