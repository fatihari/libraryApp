using LibraryApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApp.DataAccess.Concrete.EFCore.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(b => b.Id).UseIdentityColumn();

            builder.Property(b => b.Name).IsRequired().HasMaxLength(50);

            builder.ToTable("Authors");
        }
    
        
    }
}