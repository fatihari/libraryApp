using LibraryApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApp.DataAccess.Concrete.EFCore.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(b => b.Id); // haskey: has a primary key. Set the id of the entered book parameter to PK.
            builder.Property(b => b.Id).UseIdentityColumn(); // The id column will be added automatically. 
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100); //name=column, isRequired()=not null
            builder.ToTable("Publisher"); //Table's name Book
        }
    }
}