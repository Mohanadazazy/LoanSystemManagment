using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Loan
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal Amount { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = LoanStatus.NotPaid.ToString();

        public string LenderId { get; set; }   // Foreign Key لـ User
        public AppUser Lender { get; set; }

        public string BorrowerId { get; set; } // Foreign Key لـ User
        public AppUser Borrower { get; set; }

        public decimal PaidAmount { get; set; } = 0;
    }
    public enum LoanStatus
    {
        NotPaid,
        PartiallyPaid,
        Paid,
        OverDue
    }
}
