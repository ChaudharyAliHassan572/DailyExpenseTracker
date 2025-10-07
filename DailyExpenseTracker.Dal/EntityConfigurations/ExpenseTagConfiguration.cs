using DailyExpenseTracker.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyExpenseTracker.Dal.EntityConfigurations
{
    public class ExpenseTagConfiguration : IEntityTypeConfiguration<ExpenseTag>
    {
        public void Configure(EntityTypeBuilder<ExpenseTag> builder)
        {
            builder.HasKey(et => new { et.ExpenseId, et.TagId });

            builder.Property(et => et.CreatedAt)
                   .IsRequired();

            builder.HasOne(et => et.Expense)
                   .WithMany(e => e.ExpenseTags)
                   .HasForeignKey(et => et.ExpenseId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(et => et.Tag)
                   .WithMany(t => t.ExpenseTags)
                   .HasForeignKey(et => et.TagId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
