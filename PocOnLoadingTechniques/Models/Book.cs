using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocOnLoadingTechniques.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public double BookPrice { get; set; }
        public string PublishDate { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        // Navigation Property For Author 
        public virtual Author Author { get; set; }
    }
}
