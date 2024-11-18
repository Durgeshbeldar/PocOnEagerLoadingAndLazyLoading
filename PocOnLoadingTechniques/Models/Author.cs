using System.ComponentModel.DataAnnotations;

namespace PocOnLoadingTechniques.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
