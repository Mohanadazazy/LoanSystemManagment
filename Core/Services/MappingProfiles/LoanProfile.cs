using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Shared;

namespace Services.MappingProfiles
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan,LoanResultDto>()
                .ForMember(s => s.BorrowerName, d => d.MapFrom(l => l.Borrower.UserName))
                .ForMember(s => s.LenderName, d => d.MapFrom(l => l.Lender.UserName))
                .ReverseMap();

            CreateMap<Loan, AddLoanDto>().ReverseMap();

        }
    }
}
