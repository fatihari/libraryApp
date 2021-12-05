using LibraryApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApp.DataAccess.Concrete.EFCore.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder) //configure otomatik implement edilen method
        {
            //b = Book object

            builder.HasKey(b => b.Id); // haskey: has a primary key. Set the id of the entered book parameter to PK.

            builder.Property(b => b.Id).UseIdentityColumn(); // The id column will be added automatically. 

            builder.Property(b => b.Title).IsRequired().HasMaxLength(50); //name=column, isRequired()=not null

            builder.HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey(b => b.AuthorId); 

            builder.ToTable("Book"); //Table's name Book

        }
    }
}