using PocOnLoadingTechniques.Models;

namespace PocOnLoadingTechniques.Repositories
{
    public interface IRepository
    {
        public IQueryable<Author> GetAll();
        public List<Book> GetBooksByAuthorId(int authorId);
    }
}
