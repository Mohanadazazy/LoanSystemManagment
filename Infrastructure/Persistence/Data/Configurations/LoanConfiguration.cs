using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasOne(L => L.Borrower)
                   .WithMany(U => U.LoansBorrowed)
                   .HasForeignKey(L => L.BorrowerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(L => L.Lender)
                   .WithMany(U => U.LoansLent)
                   .HasForeignKey(L => L.LenderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(L => L.Amount)
                   .HasColumnType("decimal(18,2)");

            builder.Property(L => L.PaidAmount)
                   .HasColumnType("decimal(18,2)");
        }
    }
}
