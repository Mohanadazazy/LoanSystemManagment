using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class AppUser : IdentityUser
    {
        public IEnumerable<Loan> LoansLent { get; set; }
        public IEnumerable<Loan> LoansBorrowed { get; set; }
    }
}
