using DailyExpenseTracker.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyExpenseTracker.Infrastructure.Persistence.Configurations
{
    public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
    {
        public void Configure(EntityTypeBuilder<Budget> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.LimitAmount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(b => b.StartDate)
                   .IsRequired();

            builder.Property(b => b.EndDate)
                   .IsRequired();

            builder.Property(b => b.CreatedAt)
                   .IsRequired();
        }
    }
}
