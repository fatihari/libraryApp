using LibraryApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApp.DataAccess.Concrete.EFCore.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder
             .Property(m => m.Username)
             .IsRequired()
             .HasMaxLength(50);
            builder
                  .Property(m => m.LastName)
                 .IsRequired()
                 .HasMaxLength(50);
            builder
                .ToTable("Users");
        }
        
    }
}