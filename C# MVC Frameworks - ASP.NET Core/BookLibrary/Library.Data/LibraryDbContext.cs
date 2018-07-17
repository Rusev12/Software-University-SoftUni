namespace Library.Data
{
    using Library.Models;
    using Microsoft.EntityFrameworkCore;

    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Borrower> Borrowers { get; set; }

        public DbSet<BookHistory> BookHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-NB0RVEE\SQLEXPRESS; Database=LibraryDb; Integrated Security = true;");
            base.OnConfiguring(optionsBuilder); 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(a => a.AuthorId);

            builder.Entity<Book>()
              .HasOne(b => b.Borrower)
              .WithMany(a => a.Books)
              .HasForeignKey(a => a.BorrowerId);
        }

    }
}
