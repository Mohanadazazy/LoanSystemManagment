using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Shared;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController(IServiceManager serviceManager) : ControllerBase
    {
        
        [HttpGet("GetBorrowLoans/{userId}")]
        public async Task<IActionResult> GetBorrowedLoan(string userId)
        {
            var result = await serviceManager.LoanService.GetBorrowedLoansAsync(userId);
            return Ok(result);
        }

        [HttpGet("GetLendedLoans/{userId}")]
        public async Task<IActionResult> GetLendedLoan(string userId)
        {
            var result = await serviceManager.LoanService.GetLendLoansAsync(userId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanById(Guid id) 
        {
            var result = await serviceManager.LoanService.GetLoanByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddLoan(AddLoanDto addLoanDto)
        {
            var result = await serviceManager.LoanService.AddLoanAsync(addLoanDto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLoan(UpdateDto loanResultDto)
        {
            await serviceManager.LoanService.UpdateLoan(loanResultDto);
            return NoContent();
        }

        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetTotalBorrowedLoans(string userId)
        {
             var result = await serviceManager.LoanService.GetTotalAmountBorrowedLoanAsync(userId);
             return Ok(result);
        }

        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetTotalLendedLoans(string userId)
        {
            var result = await serviceManager.LoanService.GetTotalAmountLendedLoanAsync(userId);
            return Ok(result);
        }

        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetPendingLoansCount(string userId)
        {
            var result = await serviceManager.LoanService.GetPendingLoansCountAsync(userId);
            return Ok(result);
        }

    }
}
