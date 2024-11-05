using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new List<Book>()
            {
                new Book
            {
                Id = 1,
                Name = "The First Teacher",
                Author = "Chinghiz Aitmatov",
                Year = 1962
            },
            new Book
            {
                Id = 2,
                Name = "King Solomon's Mines",
                Author = "Rider Haggard",
                Year = 1885
            },
            new Book
            {
                Id = 3,
                Name = "Tom Sawyer",
                Author = "Mark Twain",
                Year = 1876
            }
            });
        }
    }
}
