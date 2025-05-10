using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class AddLoanDto
    {
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }

        public string LenderId { get; set; }
        public string BorrowerId { get; set; }
    }
}
