using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Services.Abstraction;

namespace Services
{
    public class ServiceManager(UserManager<AppUser> userManager, IMapper mapper,IUnitOfWork unitOfWork) : IServiceManager
    {
        
        public IAuthService AuthService { get; set; } = new AuthService(userManager, mapper);
        public ILoanService LoanService { get; set; } = new LoanService(unitOfWork, mapper);
    }
}
