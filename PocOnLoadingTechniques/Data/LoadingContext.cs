using Microsoft.EntityFrameworkCore;
using PocOnLoadingTechniques.Models;

namespace PocOnLoadingTechniques.Data
{
    public class LoadingContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public LoadingContext(DbContextOptions<LoadingContext> options) : base(options)
        {
        }


    }
}
