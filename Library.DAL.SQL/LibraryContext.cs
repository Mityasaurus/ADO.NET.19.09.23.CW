using Library.DAL.SQL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.SQL
{
    public class LibraryContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Lending> Lendings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LibraryExam;Integrated Security=True;Connect Timeout=30;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lending>()
                .HasOne(l => l.User)
                .WithMany(u => u.Lendings)
                .HasForeignKey(l => l.UserID);

            modelBuilder.Entity<Lending>()
                .HasOne(l => l.Book)
                .WithMany(b => b.Lendings)
                .HasForeignKey(l => l.BookID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
