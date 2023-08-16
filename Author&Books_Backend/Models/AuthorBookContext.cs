using Author_Books_Backend.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Author_Books_Backend.Models
{
    public class AuthorBookContext:DbContext
    {
        public AuthorBookContext() { }
        public AuthorBookContext(DbContextOptions<AuthorBookContext> options):base(options) { }

        public DbSet<Book> Books { get; set;}
        public DbSet<Author>Authors { get; set;}
        public DbSet<AuthorBook>AuthorBooks { get; set;}
        [JsonIgnore]
        public DbSet<BooksDataDto> BooksDataDto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=PC0404\\MSSQL2019;Database=AuthorBookDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }
    }
}
