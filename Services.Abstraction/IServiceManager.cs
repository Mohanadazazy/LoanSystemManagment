using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction
{
    public interface IServiceManager
    {
        public IAuthService AuthService { get; set; }
        public ILoanService LoanService { get; set; }
    }
}
