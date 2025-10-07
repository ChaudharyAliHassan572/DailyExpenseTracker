using DailyExpenseTracker.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyExpenseTracker.Dal.EntityConfigurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.RegionCode)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(p => p.ContactNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(p => p.CreatedAt)
                   .IsRequired();

            builder.HasOne(p => p.Currency)
                   .WithMany(c => c.UserProfiles)
                   .HasForeignKey(p => p.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
