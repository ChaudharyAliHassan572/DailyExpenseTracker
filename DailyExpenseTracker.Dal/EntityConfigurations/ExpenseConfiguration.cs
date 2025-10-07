using DailyExpenseTracker.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyExpenseTracker.Dal.EntityConfigurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(e => e.Notes)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(e => e.ExpenseDate)
                   .IsRequired();

            builder.Property(e => e.CreatedAt)
                   .IsRequired();

            builder.HasMany(e => e.ExpenseTags)
                   .WithOne(et => et.Expense)
                   .HasForeignKey(et => et.ExpenseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
