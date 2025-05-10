using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using Services.Abstraction;
using Shared;

namespace Services
{
    public class LoanService : ILoanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoanService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        

        public async Task<IEnumerable<LoanResultDto>> GetBorrowedLoansAsync(string userId)
        {
            var loans = await _unitOfWork.loanRepository.GetBarrowedLoansByUserIdAsync(userId);
            if (loans == null) return null;
            var loanResult = _mapper.Map<IEnumerable<LoanResultDto>>(loans);
            return loanResult;

        }

        public async Task<IEnumerable<LoanResultDto>> GetLendLoansAsync(string userId)
        {
            var loans = await _unitOfWork.loanRepository.GetLendedLoansByUserIdAsync(userId);
            if (loans == null) return null;
            var loanResult = _mapper.Map<IEnumerable<LoanResultDto>>(loans);
            return loanResult;
        }

        public async Task<LoanResultDto> GetLoanByIdAsync(Guid id)
        {
            var loan =  await _unitOfWork.loanRepository.GetLoanByIdAsync(id);
            if (loan is null) return null;
            var LoanResult = _mapper.Map<LoanResultDto>(loan);
            return LoanResult;
        }

        public async Task<LoanResultDto> AddLoanAsync(AddLoanDto loan)
        {
            var loanResult  = _mapper.Map<Loan>(loan);
            loanResult = await _unitOfWork.loanRepository.AddLoanAsync(loanResult);
            var result = _mapper.Map<LoanResultDto>(loanResult);
            return result;
            
        }

        public async Task UpdateLoan(UpdateDto loan)
        {
            var loanResult = _mapper.Map<Loan>(loan);
            await _unitOfWork.loanRepository.UpdateLoan(loanResult);
        }

        public async Task<decimal> GetTotalAmountBorrowedLoanAsync(string userId)
        {
             return await _unitOfWork.loanRepository.GetTotalAmountOfBorrowedLoansByUserIdAsync(userId);
        }

        public async Task<decimal> GetTotalAmountLendedLoanAsync(string userId)
        {
            return await _unitOfWork.loanRepository.GetTotalAmountOfLendedLoansByUserIdAsync(userId);
        }

        public async Task<int> GetPendingLoansCountAsync(string userId)
        {
            return await _unitOfWork.loanRepository.GetPendingLoansCountByUserIdAsync(userId);
        }
    }
}
