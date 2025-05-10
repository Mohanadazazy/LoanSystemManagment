using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Shared
{
    public class UpdateDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime DueDate { get; set; }




        public string Status
        {
            get
            {
                if (this.Amount == this.PaidAmount)
                {
                    return LoanStatus.Paid.ToString();
                }
                else if (PaidAmount > 0)
                {
                    return LoanStatus.PartiallyPaid.ToString();
                }
                else if (DueDate < DateTime.UtcNow)
                {
                    return LoanStatus.OverDue.ToString();
                }
                else
                {
                    return LoanStatus.NotPaid.ToString();
                }
            }
            // Remove setter completely or make it private if needed
        }


        public string LenderId { get; set; }

        public string? BorrowerId { get; set; }

       

        public decimal PaidAmount { get; set; } = 0;
    }
}
