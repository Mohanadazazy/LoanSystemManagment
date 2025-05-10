using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Persistence.Data;
using Persistence.Repositories;

namespace Persistence
{
    public class UnitOfWork(LoanSystemDbContext context) : IUnitOfWork
    {
        
        public ILoanRepository loanRepository { get ; set ; } = new LoanRepository(context);
    }
}
