using Microsoft.EntityFrameworkCore;
using PocOnLoadingTechniques.Data;
using PocOnLoadingTechniques.Models;

namespace PocOnLoadingTechniques.Repositories
{
    public class Repository : IRepository
    {
        // Disclaimer : This is Only to Demonstrate Eager Loading And Lazy Loading
        // So Please Ignore That I Am Not Using Service Layer For Books and Authors
        // It Just Simple Demo of Concept of Loading Techniques

        private readonly LoadingContext _context;
        public Repository(LoadingContext context)
        {
            _context = context;
        }

        // The Below Function Will Used to Implement Eager and Lazy Loading Techniques In Author Controller
        public IQueryable<Author> GetAll()
        {
            return _context.Authors.AsQueryable();
        }

        // Used For For Lazy Load Technique to Retrieved Books For Each Author.
        public List<Book> GetBooksByAuthorId(int authorId)
        {
            return _context.Books.Where(book => book.AuthorId == authorId).ToList();
        }

    }
}
