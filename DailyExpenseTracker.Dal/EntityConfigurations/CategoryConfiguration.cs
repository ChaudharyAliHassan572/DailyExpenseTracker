using DailyExpenseTracker.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyExpenseTracker.Dal.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Description)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(c => c.CreatedAt)
                   .IsRequired();

            builder.HasMany(c => c.Expenses)
                   .WithOne(e => e.Category)
                   .HasForeignKey(e => e.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Budgets)
                   .WithOne(b => b.Category)
                   .HasForeignKey(b => b.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
