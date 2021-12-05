using LibraryApp.DataAccess.Concrete.EFCore.Configurations;
using LibraryApp.Entities;
using Microsoft.EntityFrameworkCore;


namespace LibraryApp.DataAccess.Concrete.EFCore
{
    /*  
    *   Since there will be database-related operations in this layer and 
    *   we will prefer the Code First approach, we use the DBContext object by making use of EFCore.
    *   DBContext in EF Core is the class corresponding to the database on the SQL Server side. 
    *   Then, inside this DBContext class, we will define DBSets that will correspond to the tables in the database.
    */
    public class LibraryContext : DbContext
    {
        // We will use these options in Program.cs by specifying the db type information. 
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        //  Create db tables.
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        //  The method that will run before the tables in the db are created..
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*
            * How will Author and book classes transform into tables? 
            * What will be the length of my attributes when they transform into columns in the table?
            * Will there be PK, identity col, where I will specify them will be in these config files.
            * And these processes will be run before the tables are created in the db, they will be ready. 

            But also:
            builder.Entity<Music>().Property(m=>m.Id).UseIdentityColumn() // I can code this way too.
            */
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new AuthorConfiguration());
        }

    }
}